using GymMangmentClient.ViewModels;
using GymMangmentClient.Views;

namespace GymMangmentClient
{
    public partial class App : Application
    {
        public App(LoginPageViewModel vm)
        {
            InitializeComponent();

            MainPage = new AppShell();
        }
    }
}
