using DubbeleKingen.ViewModels;

namespace DubbeleKingen.Pages;

public partial class GameLeaderboardPage : ContentPage
{
	public GameLeaderboardPage(GameLeaderboardModel model)
	{
		InitializeComponent();
		BindingContext = model;
	}
}