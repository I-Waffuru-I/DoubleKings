using CommunityToolkit.Mvvm.ComponentModel;
using DubbeleKingen.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DubbeleKingen.Models;
using DubbeleKingen.Services;
using CommunityToolkit.Mvvm.Input;
using DubbeleKingen.Pages;
using Microsoft.Maui.Networking;

namespace DubbeleKingen.ViewModels
{
    [QueryProperty(nameof(PlayerCount), "playerCount")]

    public partial class PlayerSelectModel : BaseViewModel
    {
        

        PlayerService _service;
        public PlayerSelectModel(NavigationManager nav, PlayerService service, IConnectivity connectivity) : base(nav)
        {
            Title = "SELECT PLAYERS";
            this._service= service;
            this._connectivity = connectivity;

            PlayerHasBeenSelected = false;
        }

        #region PROPERTIES
        [ObservableProperty]
        int playerCount;
        [ObservableProperty]
        bool playerHasBeenSelected;
        [ObservableProperty]
        Player? currentSelectedPlayer;

        public ObservableCollection<Player> SelectedPlayers { get; } = new();
        public ObservableCollection<Player> AvailablePlayers { get; } = new();

        IConnectivity _connectivity;
        #endregion

        #region COMMANDS

        #region INIT
        [RelayCommand]
        async Task GetAvailablePlayers()
        {
            if (_connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                await Shell.Current.DisplayAlert("No connectivity!", $"Please check internet and try again.", "OK");
                return;
            }

            try
            {
                var root = await _service.GetPlayers();

                if (root == null)
                    return;

                if (root.players.Count > 0)
                    AvailablePlayers.Clear();

                foreach (var player in root.players)
                    AvailablePlayers.Add(player);

                
            }
            catch(Exception ex){await Shell.Current.DisplayAlert("Fout", ex.Message, "ok");}
        }

        [RelayCommand]
        async Task ShowSelectedPlayersButtons()
        {
            try
            {
                SelectedPlayers.Clear();

                if (PlayerCount < 1)
                    return;

                var p = await _service.GetPlaceholderPlayers(PlayerCount);
                
                foreach(Player pl in p)
                {
                    SelectedPlayers.Add(pl);
                }
            }
            catch(Exception ex){await Shell.Current.DisplayAlert("Fout", ex.Message, "ok");
    }
}
#endregion INIT

        #region EVENTS
        [RelayCommand]
        private void ClickOnPlayerFromList(Player player)
        {
            if(player == null) return;

            CurrentSelectedPlayer = player;
            PlayerHasBeenSelected = true;
        }
        [RelayCommand]
        private void AddPlayerToSelection(Player player)
        {
            if(player==null || CurrentSelectedPlayer == null) return;

            foreach (Player pl in SelectedPlayers)
                if (pl == CurrentSelectedPlayer)
                    return;

            SelectedPlayers[SelectedPlayers.IndexOf(player)] = CurrentSelectedPlayer;

            PlayerHasBeenSelected = false;
        }
        #endregion EVENTS

        #region NAV

        [RelayCommand]
        async Task GoBackPage()
        {
            await GoBackPages(1);
        }
        [RelayCommand]
        async Task GoBackToMainPage()
        {
            await GoToMainMenu();
        }
        [RelayCommand]
        async Task CreateNewPlayer()
        {
            await GoToPage(nameof(CreateNewPlayerPage));
        }

        [RelayCommand]
        async Task GoToChooseName()
        {
            await GoToPage(nameof(ChooseNamePage), new Dictionary<string, object>
            {
                {"SelectedPlayers", SelectedPlayers.ToArray() }
            });
        }

        
        #endregion NAV
        
        #endregion
    }
}
