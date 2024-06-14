using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DubbeleKingen;

namespace DubbeleKingen.ViewModels
{
    public partial class BaseViewModel : ObservableObject
    {
        public BaseViewModel(NavigationManager nav) 
        {
            _navigationManager = nav;
        }

        #region PROPERTIES
        private NavigationManager _navigationManager;

        [ObservableProperty]
        string title = "";

        #endregion

        #region NAVIGATION_COMMANDS
        
        public async Task GoToMainMenu()
        {
            await _navigationManager.GoToMain();
        }
        
        public async Task GoBackPages(int x)
        {
            await _navigationManager.GoBackXPages(x);
        }

        public async Task GoToPage(string name)
        {
            await _navigationManager.GoFurtherOnePage(name);
        }
        public async Task GoToPage(string name,IDictionary<string,object> data)
        {
            await _navigationManager.GoFurtherOnePage(name,data);
        }

        public async Task GoToGamePage(string name)
        {
            await _navigationManager.GoToSameDepthPage(name);
        }
        public async Task GoToGamePage(string name,IDictionary<string, object> data)
        {
            await _navigationManager.GoToSameDepthPage(name,data);
        }
        #endregion
    }
}
