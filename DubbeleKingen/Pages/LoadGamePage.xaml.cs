using DubbeleKingen.ViewModels;
namespace DubbeleKingen.Pages;

public partial class LoadGamePage : ContentPage
{
	public LoadGamePage(LoadGameModel model)
	{
		InitializeComponent();
        BindingContext = model;
    }
}