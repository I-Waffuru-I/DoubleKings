using DubbeleKingen.ViewModels;

namespace DubbeleKingen.Pages;

public partial class PlayerCountSelectPage : ContentPage
{
	public PlayerCountSelectPage(PlayerCountSelectModel model)
	{
		InitializeComponent();
		BindingContext = model;
	}
}