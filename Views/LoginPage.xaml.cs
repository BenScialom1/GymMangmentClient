using GymMangmentClient.ViewModels;

namespace GymMangmentClient.Views;

public partial class LoginPage : ContentPage
{
	public LoginPage(LoginPageViewModel vm)
	{
		this.BindingContext = vm;
		InitializeComponent();
	}
}