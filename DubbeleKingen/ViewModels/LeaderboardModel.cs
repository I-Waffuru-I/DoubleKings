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
    public partial class LeaderboardModel : BaseViewModel
    {


        GameService _service;
        public LeaderboardModel(NavigationManager nav, GameService service, IConnectivity connectivity) : base(nav)
        {
            Title = "LEADERBOARD";
            this._service = service;
            this._connectivity = connectivity;

            GameHasBeenSelected = false;
        }

        #region PROPERTIES
        [ObservableProperty]
        int gameCount;
        [ObservableProperty]
        bool gameHasBeenSelected;
        [ObservableProperty]
        Game? currentSelectedGame;

        public ObservableCollection<Game> SelectedGame { get; } = new();
        public ObservableCollection<Game> AvailableGames { get; } = new();
        public ObservableCollection<LeaderboardPlayerScore> PlayerScores { get; } = new();

        IConnectivity _connectivity;
        #endregion

        #region COMMANDS

        #region INIT
        [RelayCommand]
        async Task GetAvailableGames()
        {
            if (_connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                await Shell.Current.DisplayAlert("No connectivity!", $"Please check internet and try again.", "OK");
                return;
            }

            try
            {
                var root = await _service.GetAllGames();

                if (root == null)
                    return;

                if (root.games.Count > 0)
                    AvailableGames.Clear();

                foreach (var game in root.games)
                    AvailableGames.Add(game);


            }
            catch (Exception ex) { await Shell.Current.DisplayAlert("Fout", ex.Message, "ok"); }
        }
        #endregion INIT

        #region EVENTS
        [RelayCommand]
        private async void ClickOnGame(Game game)
        {
            if (game == null) return;

            CurrentSelectedGame = game;
            for (int i = 0; i < game.PlayerCount; i++)
            {
                Player player = game.Players[i];
                PlayerScores.Add(new(game.Players[i].Name, game.Plus[player.Name], game.Min[player.Name]));
            }

            await GoToPage(nameof(ScoreLeaderboardPage), new Dictionary<string, object>
            {
                {"selectedGame", PlayerScores}
            });
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
        #endregion NAV

        #endregion
    }
}


