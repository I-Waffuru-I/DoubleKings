using DubbeleKingen.ViewModels;
namespace DubbeleKingen.Pages;

public partial class SimpleScorePage : ContentPage
{
	public SimpleScorePage(ScoreModel mod)
	{
		InitializeComponent();
		BindingContext = mod;
	}	
}