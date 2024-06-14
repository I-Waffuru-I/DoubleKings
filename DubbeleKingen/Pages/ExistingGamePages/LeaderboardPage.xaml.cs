using DubbeleKingen.ViewModels;
namespace DubbeleKingen.Pages;

public partial class LeaderboardPage : ContentPage
{
	public LeaderboardPage(LoadGameModel model)
    {
		InitializeComponent();
        BindingContext = model;
    }
}