using DubbeleKingen.ViewModels;
namespace DubbeleKingen.Pages;

public partial class ChooseNamePage : ContentPage
{
	public ChooseNamePage(ChooseNameModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}