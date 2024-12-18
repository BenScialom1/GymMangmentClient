using GymMangmentClient.Models;
using GymMangmentClient.Services;
using GymMangmentClient.Views;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GymMangmentClient.ViewModels
{
    public class LoginPageViewModel:ViewModelBase
    {
        private GymMangmentWebApi proxy;
        private IServiceProvider serviceProvider;
        public LoginPageViewModel(GymMangmentWebApi proxy, IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
            this.proxy = proxy;
            LoginCommand = new Command(OnLogin);
            RegisterCommand = new Command(OnRegister);
            email = "";
            password = "";
            InServerCall = false;
            errorMsg = "";
        }

        private string email;
        private string password;

        public string Email
        {
            get => email;
            set
            {
                if (email != value)
                {
                    email = value;
                    OnPropertyChanged(nameof(Email));
                }
            }
        }

        public string Password
        {
            get => password;
            set
            {
                if (password != value)
                {
                    password = value;
                    OnPropertyChanged(nameof(Password));
                }
            }
        }

        private string errorMsg;
        public string ErrorMsg
        {
            get => errorMsg;
            set
            {
                if (errorMsg != value)
                {
                    errorMsg = value;
                    OnPropertyChanged(nameof(ErrorMsg));
                }
            }
        }


        public ICommand LoginCommand { get; }
        public ICommand RegisterCommand { get; }



        private async void OnLogin()
        {
            //Choose the way you want to blobk the page while indicating a server call
            InServerCall = true;
            ErrorMsg = "";
            //Call the server to login
            Logininfo loginInfo = new Logininfo { Email = Email, Password = Password };
            User? u = await this.proxy.LoginAsync(loginInfo);

            InServerCall = false;

            //Set the application logged in user to be whatever user returned (null or real user)
            ((App)Application.Current).LoggedInUser = u;
            if (u == null)
            {
                ErrorMsg = "Invalid email or password";
            }
            else
            {
                ErrorMsg = "Succses";
                //Navigate to the main page
                //AppShell shell = serviceProvider.GetService<AppShell>();
                //MainPage tasksViewModel = serviceProvider.GetService<MainPage>();
                //tasksViewModel.Refresh(); //Refresh data and user in the tasksview model as it is a singleton
                //((App)Application.Current).MainPage = shell;
                //Shell.Current.FlyoutIsPresented = false; //close the flyout
                //Shell.Current.GoToAsync("Tasks"); //Navigate to the Tasks tab page
            }
        }

        private void OnRegister()
        {
            ErrorMsg = "";
            Email = "";
            Password = "";
            // Navigate to the Register View page
            ((App)Application.Current).MainPage.Navigation.PushAsync(serviceProvider.GetService<Register>());
        }
    }
}
