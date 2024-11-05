using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymMangmentClient.Models
{
    public class Trainer
    {
        public string? Name { get; set; }


        public int TrainerId { get; set; }

        public int? NumOfClasses { get; set; }
        public Trainer() { }
        public Trainer(Models.Trainer trainer)
        {
            this.Name = Name;
            this.TrainerId = trainer.TrainerId;
            this.NumOfClasses = trainer.NumOfClasses;
        }
    }
}
