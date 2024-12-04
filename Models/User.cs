using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymMangmentClient.Models
{
    public class User
    {
        public string? Username { get; set; }


        public string Email { get; set; } = null!;


        public string? Password { get; set; }


        public int Id { get; set; }

        public DateOnly? BirthDate { get; set; }


        public string Address { get; set; } = null!;


        public string Difficulty { get; set; } = null!;

        public int? GenderId { get; set; }

        public bool IsManager { get; set; }

        public User() { }
        public User(Models.User user)
        {
            this.Username = user.Username;
            this.Email = user.Email;
            this.Password = user.Password;
            this.Id = user.Id;
            this.BirthDate = user.BirthDate;
            this.Address = user.Address;
            this.Difficulty = user.Difficulty;
            this.GenderId = user.GenderId;
            this.IsManager = user.IsManager;
        }
    }
}
