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

	private async void test(PlayerSelectModel viewModel)
	{
		await Shell.Current.DisplayAlert("k", viewModel.ToString(), "ok");
    }
}