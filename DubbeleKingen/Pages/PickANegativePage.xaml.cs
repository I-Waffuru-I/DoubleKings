using DubbeleKingen.ViewModels;

namespace DubbeleKingen.Pages;

public partial class PickANegativePage : ContentPage
{
	public PickANegativePage(PickANegativeModel model)
	{
		InitializeComponent();
		BindingContext = model;
	}
}