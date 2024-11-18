using GymMangmentClient.Models;
using GymMangmentClient.ViewModels;
using GymMangmentClient.Views;

namespace GymMangmentClient
{
    public partial class App : Application
    {
        public User? LoggedInUser { get; set; }
        public App(LoginPageViewModel vm)
        {
            InitializeComponent();

            MainPage = new AppShell();
        }
    }
}
