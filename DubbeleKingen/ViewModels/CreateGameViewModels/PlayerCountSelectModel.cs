using DubbeleKingen.ViewModels;
using System;
using CommunityToolkit.Mvvm.Input;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DubbeleKingen.Pages;

namespace DubbeleKingen.ViewModels
{
    public partial class PlayerCountSelectModel : BaseViewModel
    {
        public PlayerCountSelectModel(NavigationManager nav) : base(nav)
        {
            Title = "HOW MANY PLAYERS";
        }

        
        [RelayCommand]
        async Task OpenPlayerSelectPage(int playerCount)
        {
            if (playerCount == 0) 
                return;

            await GoToPage(nameof(PlayerSelectPage), new Dictionary<string, object>
            {
                {"playerCount", playerCount }
            });
        }
        [RelayCommand]
        async Task GoToMenu()
        {
            await GoToMainMenu();
        }
    }
}
