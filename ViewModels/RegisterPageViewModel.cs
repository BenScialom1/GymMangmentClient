using GymMangmentClient.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GymMangmentClient.Models;

namespace GymMangmentClient.ViewModels
{
    public class RegisterPageViewModel : ViewModelBase
    {
        private GymMangmentWebApi proxy;
        public RegisterPageViewModel(GymMangmentWebApi proxy)
        {
            this.proxy = proxy;
            RegisterCommand = new Command(OnRegister);
            CancelCommand = new Command(OnCancel);
            IsPassword = true;
            NameError = "Name is required";
            EmailError = "Email is required";
            PasswordError = "Password must be at least 4 characters long and contain letters and numbers";
        }
        #region Name
        private bool showNameError;
        public bool ShowNameError
        {
            get => showNameError;
            set
            {
                showNameError = value;
                OnPropertyChanged("ShowNameError");
            }
        }

        private string name;
        public string Name
        {
            get => name;
            set
            {
                name = value;
                ValidateName();
                OnPropertyChanged("Name");
            }
        }
        private string nameError;
        public string NameError
        {
            get => nameError;
            set
            {
                nameError = value;
                OnPropertyChanged("NameError");
            }
        }
        private void ValidateName()
        {
            this.ShowNameError = string.IsNullOrEmpty(name);
        }
        #endregion
        #region Email
        private bool showEmailError;
        public bool ShowEmailError
        {
            get => showEmailError;
            set
            {
                showEmailError = value; OnPropertyChanged("ShowEmailError");
            }
        }
        private string email;
        public string Email
        {
            get => email;
            set
            {
                email = value;

            }
        }
        private string emailError;
        public string EmailError
        {
            get => emailError;
            set
            {
                emailError = value; OnPropertyChanged("EmailError");
            }
        }
        private void ValidateEmail()
        {
            this.ShowEmailError = string.IsNullOrEmpty(email);
            if (!ShowEmailError)
            {
                if (!System.Text.RegularExpressions.Regex.IsMatch(Email, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"))
                {
                    EmailError = "Email is not valid";
                    ShowEmailError = true;
                }
                else
                {
                    EmailError = "";
                    ShowEmailError = false;
                }
            }
            else
            {
                EmailError = "Email is required";
            }
        }
        #endregion
        #region Password
        private bool showPasswordError;
        public bool ShowPasswordError
        {
            get => showPasswordError;
            set
            {
                showPasswordError = value; OnPropertyChanged("ShowPasswordError");
            }
        }
        private string password;
        public string Password
        {
            get => password;
            set
            {
                password = value;
                ValidatePassword();
                OnPropertyChanged("Password");
            }
        }
        private string passwordError;
        public string PasswordError
        {
            get=>passwordError;
            set
            {
                passwordError = value; OnPropertyChanged("PasswordError");
            }
        }
        private void ValidatePassword()
        {
            if (string.IsNullOrEmpty(password) ||
                    password.Length < 4 ||
                    !password.Any(char.IsDigit) ||
                    !password.Any(char.IsLetter))
            {
                this.ShowPasswordError = true;
            }
            else
                this.ShowPasswordError = false;

        }
    
        private bool isPassword = true;
        public bool IsPassword
        {
            get => isPassword;
            set
            {
                isPassword = value;
                OnPropertyChanged("IsPassword");

            }
        }
        public Command ShowPasswordCommand { get; }
        public void OnShowPassword()
        {
            isPassword = !isPassword;// there is a chance that i need a cpital  
        }
        #endregion
        #region BirthDate
        private bool showDateOfBirthError;
        public bool ShowDateOfBirthError
        {
            get => showDateOfBirthError;
            set
            {
                showDateOfBirthError = value; OnPropertyChanged("ShowDateOfBirthError");
            }
        }
        private DateTime dateOfBirth;
        public DateTime DateOfBirth
        {
            get => dateOfBirth;
            set
            {
                dateOfBirth = value;
                ValidateDateOfBirth();
                OnPropertyChanged("DateOfBirth");
            }
        }

        private DateTime minDate;
        public DateTime MinDate
        {
            get => DateTime.Now.AddYears(-14);
        }

        private string dateOfBirthError;
        public string DateOfBirthError
        {
            get => dateOfBirthError;
            set
            {
                dateOfBirthError = value; OnPropertyChanged("DateOfBirthError");
            }
        }
        private void ValidateDateOfBirth()
        {
            
                this.ShowDateOfBirthError = false;

        }


        #endregion
        #region Address
        private string address;
        public string Address
        {
            get => address;
            set
            {
                address = value;

                OnPropertyChanged();
            }
        }
        #endregion
        #region Difficulty
        private string difficulty;
        public string Difficulty
        {
            get => difficulty;
            set
            {
                difficulty = value;
               
                OnPropertyChanged();
            }
        }
        #endregion
        public Command RegisterCommand { get; }
        public Command CancelCommand { get; }
        public async void OnRegister()
        {
            ValidateName();

            ValidateEmail();
            ValidatePassword();

            if (!ShowNameError && !ShowEmailError && !ShowPasswordError)
            {
                //Create a new AppUser object with the data from the registration form
                var newUser = new User
                {
                    Username = Name,
                    Email = Email,
                    Password = Password,
                    BirthDate = DateOnly.FromDateTime(this.DateOfBirth)

                };

                //Call the Register method on the proxy to register the new user
                InServerCall = true;
                int? userId = await proxy.Register(newUser);
                InServerCall = false;

                //If the registration was successful, navigate to the login page
                if (userId != null)
                {

                    InServerCall = false;
                    newUser.Id = userId.Value;
                    ((App)(Application.Current)).MainPage.Navigation.PopAsync();
                }
                else
                {

                    //If the registration failed, display an error message
                    string errorMsg = "Registration failed. Please try again.";
                    await Application.Current.MainPage.DisplayAlert("Registration", errorMsg, "ok");
                }
            }
            }
        public void OnCancel()
        {
            ((App)(Application.Current)).MainPage.Navigation.PopAsync();
        }

        private void DateTimeExaple()
        {
            DateOnly d = DateOnly.FromDateTime(DateTime.Now);

            DateOnly d1 = DateOnly.FromDateTime(this.DateOfBirth);

        }
    }
}
