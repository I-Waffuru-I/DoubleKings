using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using DubbeleKingen.Models;
using DubbeleKingen.Models.GameTypes;
using DubbeleKingen.Models.Receptibles;
using DubbeleKingen.Services;
using DubbeleKingen.ViewModels;
namespace DubbeleKingen.Managers
{
    public partial class KingGameManager : ObservableObject
    { 
        public KingGameManager(IGameService serv) 
        {
            service = serv;
        }

        #region PROPERTIES

        public readonly Dictionary<int, GameScoreType> gameTypes = new()
        {
            {0,new StandardPlusGame("heart.png",13,17)},
            {1,new StandardPlusGame("club.png", 13, 17)},
            {2,new StandardPlusGame("diamond.png", 13, 17)},
            {3,new StandardPlusGame("spade.png", 13, 17)},
            {4,new StandardPlusGame("no_tricks.png", 13, 17) },
            {5,new NoHeartsGame("no_hearts.png", 13, 12) },
            {6,new NoQueensGame("no_queens.png", 8, 8) },
            {7,new NoKJGame("no_kj.png", 8, 8) },
            {8,new NoKingHeartsGame("no_k_hearts.png", 5, 5) },
            {9,new No7OrLastGame("no_sev_last.png" , 5, 5) }
        };

        int selectedPlayerIndex;
        int pickedGameType;
        bool isPositive;

        IGameService service;

        [ObservableProperty]
        Game currentGame = null!;

        #endregion


        #region METHODS

        #region ACTIONS

        /// <summary>
        /// Updates CurrentGame with the given parameters.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="pCount"></param>
        /// <param name="players"></param>
        public void StartNewGame(int id, string name, int pCount, Player[] players)
        {
            selectedPlayerIndex = 0;

            Game game = new();
            game.Id = id;
            game.Name = name;
            game.Players = players;
            game.PlayerCount = pCount;
            game.Plus = [];
            game.Min = [];

            foreach(Player p in players) 
            {
                game.Plus.Add(p.Name, 0);
                game.Min.Add(p.Name, 0);
            }

            CurrentGame = game;
        }

        /// <summary>
        /// Advances the selected player by 1.
        /// </summary>
        public void ContinueToNextRound()
        {
            selectedPlayerIndex = (selectedPlayerIndex == CurrentGame.PlayerCount-1) ? 0 : selectedPlayerIndex+1;
        }

        /// <summary>
        /// Adds a list of PlayerScores into the Plus/Min dictionaries of the current game.
        /// </summary>
        /// <param name="playerScores"></param>
        public void AddScoresToGame(List<PlayerScore> playerScores)
        {
            playerScores.ForEach(score =>
            {
                if(isPositive)
                    CurrentGame.Plus[score.Name] += score.Score;
                else
                    CurrentGame.Min[score.Name] += score.Score;
            });
        }

        /// <summary>
        /// Sets the current game type to the given integer.
        /// </summary>
        /// <param name="i"></param>
        public void SetCurrentPickedGameType(int i)
        {
            pickedGameType = i;
            isPositive = i <= 3;
        }

        public async Task SaveGameToDb()
        {
            await service.SaveGame(CurrentGame);
        }

        public void ContinueGameFromLoad(Game g)
        {
            CurrentGame = g;
            return;
        }


        #endregion

        #region GAME_INFO

        public List<LeaderboardPlayerScore> GetGameLeaderboard()
        {
            List<LeaderboardPlayerScore> list = [];

            Array.ForEach(CurrentGame.Players, (pl) =>
            {
                list.Add(new(pl.Name, CurrentGame.Plus[pl.Name], CurrentGame.Min[pl.Name]));
            });


            
            return list;
        }

        public async Task<int> GetNewGameId()
        {
            var gameList = await service.GetAllGames();

            return (gameList == null) ? 0 :
                gameList.games.OrderByDescending(x => x.Id).First().Id+1;

        }

        public string GetCurrentPlayerName()
        {
            return CurrentGame.Players[selectedPlayerIndex].Name;
        }

        public GameScoreType GetCurrentPickedGameInfo()
        {
            return gameTypes[pickedGameType];
        }

        public bool GetIsPositive()
        {
            return isPositive;
        }

        public List<Player> GetPlayers()
        {
            return [.. CurrentGame.Players];
        }

        #endregion

        #endregion
    }
}
