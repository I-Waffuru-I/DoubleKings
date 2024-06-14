using DubbeleKingen.ViewModels;
using System;

namespace DubbeleKingen
{
    public partial class MainPage : ContentPage
    {
        public MainPage(MainMenuModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }
    }

}
