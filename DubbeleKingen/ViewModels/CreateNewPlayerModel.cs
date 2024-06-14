using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DubbeleKingen.Models;
using DubbeleKingen.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DubbeleKingen.ViewModels
{
    public partial class CreateNewPlayerModel : BaseViewModel
    {
        [ObservableProperty]
        string inputText = "New Player";

        PlayerService _service;
        
        public CreateNewPlayerModel(NavigationManager nav, PlayerService serv) : base(nav)
        {
            this._service = serv;
        }

        #region COMMANDS

        [RelayCommand]
        async Task CreatePlayerAndLeave()
        {
            
            if(await _service.MakeNewPlayer(InputText))
                await GoBackPages(1);
        }
        [RelayCommand]
        async Task GoBackPage()
        {
            await GoBackPages(1);
        }
        #endregion
    }
}
