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
using DubbeleKingen.Managers;

namespace DubbeleKingen.ViewModels
{
    public partial class LoadGameModel : BaseViewModel
    {


        FirebaseGameService _service;
        public LoadGameModel(NavigationManager nav, KingGameManager game , FirebaseGameService service) : base(nav)
        {
            Title = "LOAD GAME";
            this._service = service;
            gameManager = game;

            GameHasBeenSelected = false;
        }

        #region PROPERTIES
        KingGameManager gameManager;

        [ObservableProperty]
        int gameCount;
        [ObservableProperty]
        bool gameHasBeenSelected;
        [ObservableProperty]
        Game? currentSelectedGame;

        public ObservableCollection<Game> SelectedGame { get; } = new();
        public ObservableCollection<Game> AvailableGames { get; } = new();
        public ObservableCollection<LeaderboardPlayerScore> PlayerScores { get; } = new();

        #endregion

        #region COMMANDS

        #region INIT
        [RelayCommand]
        async Task GetAvailableGames()
        {  
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

            gameManager.ContinueGameFromLoad(game);

            await GoToPage(nameof(ScoreLoadGamePage));
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


