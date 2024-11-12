using GymMangmentClient.Models;
using GymMangmentClient.Services;
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
        public GymMangmentWebApi service;
        private readonly IServiceProvider serviceProvider;

        public ICommand LoginCommand { get; set; }
        public ICommand GoToRegisterCommand { get; set; }
        public string Email { get; set; }

        public string Password { get; set; }

        public LoginPageViewModel(GymMangmentWebApi service, IServiceProvider serviceProvider)
        {
            this.service = service;
            this.serviceProvider = serviceProvider;
            this.LoginCommand = new Command(OnLogin);
            this.GoToRegisterCommand = new Command(OnRegisterClicked);
        }

        public async void OnLogin()
        {
            Logininfo info = new Logininfo
            {
                Username = this.Email,
                Password = this.Password
            };
            User user = await service.Login(info);
            //if (user != null)
            //{
            //    if (user.UserType == "3")
            //    {
            //        var businessesPage = serviceProvider.GetRequiredService<BusinessesPage>();
            //        await App.Current.MainPage.Navigation.PushAsync(businessesPage);
            //    }
            //    if (user.UserType == "2")
            //    {
            //        //Navigate to the main page
            //        App.Current.MainPage = new MainPage();
            //    }
            //    //Navigate to the main page
            //    //App.Current.MainPage = new MainPage();
            //    // קבלת הדף דרך ה-DI וניווט אליו
            //    //var businessesPage = serviceProvider.GetRequiredService<BusinessesPage>();
            //    //await App.Current.MainPage.Navigation.PushAsync(businessesPage);
            //}

            
            
                Debug.WriteLine("Login failed");
            
        }

        private async void OnRegisterClicked()
        {
            // קבלת הדף דרך ה-DI וניווט אליו
            var registrationPage = serviceProvider.GetRequiredService<RegisterPageViewModel>();
            await App.Current.MainPage.Navigation.PushAsync(registrationPage);
        }
    }
}
