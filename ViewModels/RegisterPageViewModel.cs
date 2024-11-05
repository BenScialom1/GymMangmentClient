using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymMangmentClient.ViewModels
{
    public class RegisterPageViewModel:ViewModelBase
    {
        private string name;
        private int? userId { get; set; }
        private string? user_error;
        private string email;
        private string password;
        private string? password_error;
        private string user_type;
        private bool isSellerChecked;
        private bool isBuyerChecked;
        private readonly IServiceProvider serviceProvider;

        // הוספת אובייקט ממחלקת השירותים שיוכל להפעיל את הפונקציות במחלקה
        //private SweetBoxWebApi api_service;


        //public RegistrationPageViewModel(SweetBoxWebApi api_service, IServiceProvider serviceProvider)
        //{
        //    this.api_service = api_service;
        //    RegistrationCommand = new Command(Register);
        //    this.serviceProvider = serviceProvider;


        //}

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
                User_Error = ""; // איפוס שגיאת שם המשתמש
                OnPropertyChanged(nameof(Name));
                // בדיקת תקינות שם המשתמש

                if (!string.IsNullOrEmpty(Name))

                {
                    if (char.IsDigit(Name[0]))
                    {
                        User_Error = "!!שם המשתמש לא יכול להתחיל בספרה!!";
                        OnPropertyChanged(nameof(Name));
                    }

                }
            }
        }

        public string User_Error
        {
            get
            {
                return user_error;
            }
            set
            {
                user_error = value;
                OnPropertyChanged(nameof(User_Error));
            }
        }

        public string Email
        {
            get
            {
                return email;
            }
            set
            {
                email = value;
                OnPropertyChanged(nameof(Email));
            }
        }

        public string? Password
        {
            get { return password; }
            set
            {
                password = value;
                Password_Error = "";
                OnPropertyChanged(nameof(Password));
                OnPropertyChanged(nameof(User_Error));
                if (string.IsNullOrEmpty(password))
                {
                    Password_Error = ""; // איפוס השגיאה אם השדה ריק
                }
                else
                {
                    if (password != null)
                    {
                        bool IsPasswordOk = IsValidPassword(password);
                        if (!IsPasswordOk)
                        {
                            Password_Error = "!!סיסמה חייבת להכיל לפחות אות גדולה אחת ומספר!!";
                        }
                    }
                }
            }
        }

        private bool IsValidPassword(string password)
        {
            bool hasUpperCase = false;
            bool hasDigit = false;

            foreach (char c in password)
            {
                if (char.IsUpper(c))
                {
                    hasUpperCase = true;
                }
                if (char.IsDigit(c))
                {
                    hasDigit = true;
                }

                if (hasUpperCase && hasDigit)
                {
                    break; // אם מצאנו כבר גם אות גדולה וגם ספרה, אפשר לעצור את הלולאה
                }
            }
            return hasUpperCase && hasDigit;

        }

        public string Password_Error
        {
            get { return password_error; }
            set
            {
                password_error = value;
                OnPropertyChanged(nameof(Password_Error));
                //OnPropertyChanged(nameof(CanRegister));
            }
        }

        public string User_Type
        {
            get
            {
                return user_type;
            }
            set
            {
                user_type = value;
                OnPropertyChanged(nameof(User_Type));
            }
        }
    }
}
