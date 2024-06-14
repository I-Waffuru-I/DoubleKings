using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DubbeleKingen.Managers;
using DubbeleKingen.Models;
using DubbeleKingen.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DubbeleKingen.ViewModels
{
    public partial class GameRunningModel : BaseViewModel
    {
        public GameRunningModel(KingGameManager manager ,NavigationManager nav) : base(nav)
        {
            gameManager = manager;
            Title = $"{gameManager.GetCurrentPlayerName()}'s Choice!";
            gameType = gameManager.GetCurrentPickedGameInfo();
        }
        #region PROPERTIES
        KingGameManager gameManager;

        [ObservableProperty]
        GameScoreType gameType;

        [ObservableProperty]
        string selectedGameContent;

        #endregion

        #region COMMANDS
        [RelayCommand]
        async Task GoToMenu()
        {
            await GoToMainMenu();
        }

        [RelayCommand]
        async Task GoBackToPick()
        {
            await GoToGamePage((gameManager.GetIsPositive())?nameof(PickASuitPage):nameof(PickANegativePage));
        }

        [RelayCommand]
        async Task GoToScorePage()
        {
            await GoToGamePage(nameof(SimpleScorePage));   
        }
    

        [RelayCommand]
        void UpdateGameInfo()
        {
            Title = $"{gameManager.GetCurrentPlayerName()}'s Choice!";
            GameType = gameManager.GetCurrentPickedGameInfo();
        }
        #endregion

        #region METHODS

        private string GetGameDisplay()
        {
            var s = gameManager.GetCurrentPickedGameInfo();
            
            return "ok";
        }

        #endregion
    }
}
