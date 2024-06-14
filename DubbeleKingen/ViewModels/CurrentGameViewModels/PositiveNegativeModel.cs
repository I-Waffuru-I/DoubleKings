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
    public partial class PositiveNegativeModel : BaseViewModel
    {
        KingGameManager gameManager;

        public PositiveNegativeModel(KingGameManager g,NavigationManager nav) : base(nav)
        {
            gameManager = g;
        }

        #region COMMANDS

        [RelayCommand]
        void UpdateTitle()
        {
            Title = $"{gameManager.GetCurrentPlayerName()}'s turn!";
        }

        [RelayCommand]
        async Task GoToPlus()
        {
            await GoToGamePage(nameof(PickASuitPage));
        }

        [RelayCommand]
        async Task GoToMin()
        {
            await GoToGamePage(nameof(PickANegativePage));
        }

        [RelayCommand]
        async Task GoToMenu()
        {
            await GoToMainMenu();
        }
        #endregion
    }
}
