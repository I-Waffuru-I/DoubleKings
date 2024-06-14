using CommunityToolkit.Mvvm.Input;
using DubbeleKingen.Pages;
using Microsoft.Maui.Controls.Platform;
using DubbeleKingen.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DubbeleKingen.ViewModels
{
    public partial class MainMenuModel : BaseViewModel
    {
        public MainMenuModel(NavigationManager nav) : base(nav) 
        {
            Title = "DOUBLE KING";
        }
        
        [RelayCommand]
        async Task OpenNewGamePage()
        {
            await GoToPage(nameof(PlayerCountSelectPage));
        }

        [RelayCommand]
        async Task OpenLoadGamePage()
        {
            await GoToPage(nameof(LoadGamePage));
        }
        [RelayCommand]
        async Task OpenLeaderboardPage()
        {
            await GoToPage(nameof(LeaderboardPage));
        }
    }
}
