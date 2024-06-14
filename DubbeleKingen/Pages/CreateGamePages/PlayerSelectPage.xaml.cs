using DubbeleKingen.ViewModels;

namespace DubbeleKingen.Pages;

public partial class PlayerSelectPage : ContentPage
{
	public PlayerSelectPage(PlayerSelectModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
		//test(viewModel);
	}
}