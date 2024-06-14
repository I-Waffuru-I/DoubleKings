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
    public partial class ScoreLoadGameModel : BaseViewModel
    {
        public ScoreLoadGameModel(ObservableCollection<LeaderboardPlayerScore> PlayerScores, KingGameManager game ,NavigationManager nav) : base(nav)
        {
            Title = "LEADERBOARD";
            this.PlayerScores = PlayerScores;
            gameManager = game;
        }

        KingGameManager gameManager;
        public ObservableCollection<LeaderboardPlayerScore> PlayerScores { get; } = new();


        [RelayCommand]
        async Task GetLeaderboardInfo()
        {
            PlayerScores.Clear();

            var l = gameManager.GetGameLeaderboard();
            foreach (LeaderboardPlayerScore item in l)
            {
                PlayerScores.Add(item);
            }
        }
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
    }
}
