using DubbeleKingen.ViewModels;
namespace DubbeleKingen.Pages;

public partial class ScorePage : ContentPage
{
	public ScorePage(ScoreModel mod)
	{
		InitializeComponent();
		BindingContext = mod;
	}	
}