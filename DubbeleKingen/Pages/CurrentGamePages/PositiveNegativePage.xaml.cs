using DubbeleKingen.ViewModels;
namespace DubbeleKingen.Pages;

public partial class PositiveNegativePage : ContentPage
{
	public PositiveNegativePage(PositiveNegativeModel model)
	{
		InitializeComponent();
		BindingContext = model;
	}
}