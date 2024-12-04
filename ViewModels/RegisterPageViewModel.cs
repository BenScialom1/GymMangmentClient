using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymMangmentClient.ViewModels
{
    public class RegisterPageViewModel:ViewModelBase
    {
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime DateOfBirth { get; set; } = DateTime.Now;
        public string Address { get; set; }
        public string Difficulty { get; set; }
        public string Gender { get; set; }
         

    }
}
