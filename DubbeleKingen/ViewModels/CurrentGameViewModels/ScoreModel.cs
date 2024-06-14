using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DubbeleKingen.Managers;
using DubbeleKingen.Models;
using DubbeleKingen.Models.Receptibles;
using DubbeleKingen.Pages;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DubbeleKingen.ViewModels
{
    public partial class ScoreModel : BaseViewModel
    {
        public ScoreModel(KingGameManager manager ,NavigationManager nav) : base(nav)
        {
            Title = "Points!";
            gameManager = manager;
        }

        #region PROPERTIES

        KingGameManager gameManager;

        [ObservableProperty]
        string scoreCheck = "";
        [ObservableProperty]
        bool correctScoreCountIsAchievedInv;


        List<Player> playerList { get; } = new();
        public ObservableCollection<PlayerScore> PlayerScores { get; } = new();

        bool hasToChange = true;
        int totalPoints, pointsToBeGotten;
        List<int> permScoreList = new();
        List<int> activatedScores = new();
        public ObservableCollection<int> ScoresList { get; } = new();

        #endregion


        #region COMMANDS

        /// <summary>
        /// Initialization code for the model. To be run each time a player has to give scores in.
        /// </summary>
        /// <returns></returns>
        [RelayCommand]
        async Task SetupScorePage()
        {
            CorrectScoreCountIsAchievedInv = false;
            totalPoints = 0;
            pointsToBeGotten = 0;

            playerList.Clear();
            PlayerScores.Clear();
            ScoresList.Clear();
            permScoreList.Clear();
            activatedScores.Clear();

            await GetCurrentPlayers();
            GetScoreDetails();
            ChangeTitle();
        }

        /// <summary>
        /// Navigation item to continue after distributing points.
        /// </summary>
        /// <returns></returns>
        [RelayCommand]
        async Task GoToNextRound()
        {
            if (!PointsAreOkay()) 
            {
                await Shell.Current.DisplayAlert("Fout","Please assign all points.","Ok"); 
                return;
            }

            gameManager.AddScoresToGame(PlayerScores.ToList());
            await GoToGamePage(nameof(GameLeaderboardPage));
        }

        /// <summary>
        /// Command for interaction with a Picker. Refreshes the list of scores to distribute.
        /// </summary>
        /// <returns></returns>
        [RelayCommand]
        async Task PickerItemChanged(PlayerScore ps)
        {
            await Shell.Current.DisplayAlert("test", $"{ps.Name} met score {ps.Score}","ok");
            if (hasToChange)
            {
                GetCorrectPoints();
                ShowActiveScores();
            }

            hasToChange= !hasToChange;
        }

        /// <summary>
        /// Adapts the ScoreCheck field into the right format, each time a Picker value is selected.
        /// </summary>
        /// <returns></returns>
        [RelayCommand]
        async Task SimplePickerItemChanged()
        {
            ChangeTitle();
        }

        #endregion


        #region METHODS


        /// <summary>
        /// Gets list of players in the current game and assigns them
        /// </summary>
        /// <returns></returns>
        async Task GetCurrentPlayers()
        {

            try
            {
                List<Player> pl = gameManager.GetPlayers();

                if (pl.Count < 1 || pl == null)
                    throw new Exception("No players found.");

                foreach (Player p in pl)
                {
                    PlayerScores.Add(new(p.Name, 0));
                    playerList.Add(p);
                }
            }
            catch (Exception ex) { await Shell.Current.DisplayAlert("Fout", ex.Message, "OK"); }
        }

        /// <summary>
        /// Gets the score values from the KingGameManager for the corresponding game type.
        /// </summary>
        async void GetScoreDetails()
        {
            try
            { 
                GameScoreType type =  gameManager.GetCurrentPickedGameInfo();

                var scores = type.GetInitialScores(gameManager.CurrentGame.PlayerCount);
            
                foreach (int score in scores)
                {
                    permScoreList.Add(score);
                    activatedScores.Add(1);
                }
                pointsToBeGotten = scores.Last();
                ShowActiveScores();

            }
            catch(Exception ex) { await Shell.Current.DisplayAlert("Fout", ex.Message, "ok"); }
        }

        /// <summary>
        /// Checks if total assigned points are equal to the points to be gotten.
        /// </summary>
        /// <returns></returns>
        private bool PointsAreOkay()
        {
            return GetTotalPoints() == pointsToBeGotten;
        }

        /// <summary>
        /// Parses the active score values into ScoresList.
        /// </summary>
        private async void ShowActiveScores()
        {
            try
            {
                ScoresList.Clear();

                foreach (var score in permScoreList)
                {
                    int index = permScoreList.IndexOf(score);

                    if (activatedScores[index] == 1)
                        ScoresList.Add(score);
                }
            }
            catch (Exception ex) { await Shell.Current.DisplayAlert("Fout: ShowActiveScores", ex.Message, "ok"); }
            
        }

        private async void GetCorrectPoints()
        {
            try { 
                totalPoints = 0;
                activatedScores.Clear();
                totalPoints = GetTotalPoints();

                foreach (var score in permScoreList)
                { activatedScores.Add((totalPoints + score > pointsToBeGotten) ? 0 : 1); }
            }
            catch(Exception ex) { await Shell.Current.DisplayAlert("Fout: GetCorrectPoints", ex.Message, "ok"); }            
        }

        private void ChangeTitle()
        {
            int total = GetTotalPoints();

            if (total == pointsToBeGotten)
            {
                ScoreCheck = "Score is correct.";
                CorrectScoreCountIsAchievedInv = true;
                return;
            }
            CorrectScoreCountIsAchievedInv = false;
            string pts = (total - pointsToBeGotten > 1 || pointsToBeGotten - total > 1) ? "points" : "point";
            ScoreCheck = (total > pointsToBeGotten) 
                ? $"Remove {total - pointsToBeGotten} {pts}." : $"{pointsToBeGotten - total} {pts} to go.";
        }

        private int GetTotalPoints()
        {
            int tot = 0;
            foreach (PlayerScore pl in PlayerScores)
                tot += pl.Score;

            return tot;
        }
        #endregion

    }
}
