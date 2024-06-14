using DubbeleKingen.ViewModels;

namespace DubbeleKingen.Pages;

public partial class GameRunningPage : ContentPage
{
	public GameRunningPage(GameRunningModel model)
	{
		InitializeComponent();
		BindingContext = model;
	}
}