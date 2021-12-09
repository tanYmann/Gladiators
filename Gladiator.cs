using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gladiaddi
{
    [Table("Gladiatioren")]
    public class Gladiator
    {
       
        public string Name { get; set; }
        public string ImgUrl { get; set; }
        public int Level { get; set; }
        public int Xp { get; set; }
        public int Stamina { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }
        public int Fights { get; set; }
        public int Wins { get; set; }
        public DateTime StartDate { get; set; }

        public static void SetGladiator(Gladiator gladiator)
        {
            Gladiator gladiator1 = gladiator;
        }
    }

   
}
