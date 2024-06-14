using DubbeleKingen.Models;
using DubbeleKingen.ViewModels;

namespace DubbeleKingen.Pages;

public partial class CreateNewPlayerPage : ContentPage
{
	public CreateNewPlayerPage(CreateNewPlayerModel model)
	{
		InitializeComponent();
		this.BindingContext = model;
	}
}