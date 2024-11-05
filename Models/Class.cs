using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymMangmentClient.Models
{
    public class Class
    {
        public string? Name { get; set; }


        public int ClassId { get; set; }

        [Column("DIFFICULTY")]
        public int? Difficulty { get; set; }
        public Class() { }
        public Class(Models.Class @class)
        {
            Name = @class.Name;
            ClassId = @class.ClassId;
            Difficulty = @class.Difficulty;

        }
    }
}
