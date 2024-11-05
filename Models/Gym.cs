using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymMangmentClient.Models
{
    public class Gym
    {
        public string Name { get; set; }
        public int GymId { get; set; }
        public int? Level { get; set; }
        public Gym() { }
        public Gym(Models.Gym gym)
        {
            this.Name = Name;
            this.GymId = GymId;
            this.Level = Level;
        }
    }
}
