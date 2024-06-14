using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DubbeleKingen.Managers;
using DubbeleKingen.Models;
using DubbeleKingen.Pages;

namespace DubbeleKingen.ViewModels
{
    [QueryProperty(nameof(SelectedPlayers), "SelectedPlayers")]

    public partial class ChooseNameModel : BaseViewModel
    {
        [ObservableProperty]
        string gameName;
        [ObservableProperty]
        Player[] selectedPlayers;
        private KingGameManager gameManager;

        public ChooseNameModel(KingGameManager game,NavigationManager nav) : base(nav)
        {
            Title = "Choose Name";
            GameName = "New Game";
            gameManager = game;
        }

        #region COMMANDS

        [RelayCommand]
        async Task GoBackPage()
        {
            await GoBackPages(1);
        }
        [RelayCommand]
        async Task GoToNewGame()
        {
            try
            {
                int id = await gameManager.GetNewGameId();
                gameManager.StartNewGame(
                    id,
                    GameName,
                    SelectedPlayers.Count(),
                    SelectedPlayers);
                await GoToPage(nameof(PositiveNegativePage));

            }
            catch (Exception ex) { await Shell.Current.DisplayAlert("Fout", ex.Message, "ok"); }
            }
        #endregion
    }
}
