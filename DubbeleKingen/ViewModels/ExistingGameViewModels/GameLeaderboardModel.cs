using CommunityToolkit.Mvvm.Input;
using DubbeleKingen.Managers;
using DubbeleKingen.Models;
using DubbeleKingen.Pages;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DubbeleKingen.ViewModels
{
    public partial class GameLeaderboardModel : BaseViewModel
    {
        public GameLeaderboardModel(KingGameManager manager ,NavigationManager nav) : base(nav)
        {
            gameManager = manager;
            Title = "Scores!";
        }

        #region PROPERTIES

        KingGameManager gameManager;
        public ObservableCollection<LeaderboardPlayerScore> PlayerScores { get; } = new();

        #endregion


        #region COMMANDS

        [RelayCommand]
        async Task GetLeaderboardInfo()
        {
            PlayerScores.Clear();
            gameManager.GetGameLeaderboard().ForEach(PlayerScores.Add);
        }

        [RelayCommand]
        async Task GoToNextTurn()
        {
            await gameManager.SaveGameToDb();
            gameManager.ContinueToNextRound();
            await GoToGamePage(nameof(PositiveNegativePage));
        }

        [RelayCommand]
        async Task GoToMenu()
        {
            await GoToMainMenu();
        }
        #endregion
    }
}
