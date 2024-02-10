using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Turboazmini.Enums;

namespace Turboazmini.Models
{
    public class Announcement
    {
        static int count = 0;
       
        public int Id { get; set; }
        public int March { get; set; }
        public double Price { get; set; }
        public Models Models { get; set; }
        public TypeOfBan TypeOfBan { get; set; } 
        public TypeOfFuel TypeOfFuel {  get; set; }
        public TypeOfGearBox TypeOfGearBox { get; set; }
        public TypeOfTransmission TypeOfTransmission { get; set; }
        public Announcement()
        {
            count++;
            this.Id = count;      }



        
    }
}
