using GymMangmentClient.ViewModels;

namespace GymMangmentClient.Views;

public partial class Register : ContentPage
{
	public Register(RegisterPageViewModel vm)
	{
		BindingContext = vm;
		InitializeComponent();
	}
}