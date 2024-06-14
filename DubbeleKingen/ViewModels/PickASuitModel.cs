using CommunityToolkit.Mvvm.Input;
using DubbeleKingen.Managers;
using DubbeleKingen.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DubbeleKingen.ViewModels
{
    public partial class PickASuitModel : BaseViewModel
    {
        #region PROPERTIES

        KingGameManager gameManager;

        #endregion

        public PickASuitModel(KingGameManager manager ,NavigationManager nav) : base(nav)
        {
            gameManager = manager;
        }

        #region COMMANDS

        [RelayCommand]
        async Task GoToRunningGame(int gameTypeId)
        {
            gameManager.SetCurrentPickedGameType(gameTypeId);
            await GoToGamePage(nameof(GameRunningPage));
        }

        [RelayCommand]
        async Task GoBack()
        {
            await GoToGamePage(nameof(PositiveNegativePage));
        }

        [RelayCommand]
        void UpdateTitle()
        {
            Title = $"{gameManager.GetCurrentPlayerName()}'s turn!";
        }

        #endregion
    }
}
