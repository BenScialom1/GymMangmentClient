using GymMangmentClient.Views;

namespace GymMangmentClient
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute("Login", typeof(LoginPage));
        }
    }
}
