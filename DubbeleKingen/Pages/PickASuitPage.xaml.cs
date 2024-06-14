using DubbeleKingen.ViewModels;

namespace DubbeleKingen.Pages;

public partial class PickASuitPage : ContentPage
{
	public PickASuitPage(PickASuitModel model)
	{
		InitializeComponent();
		BindingContext = model;
	}
}