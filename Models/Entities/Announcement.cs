using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Turboazmini.Enums;

namespace Turboazmini.Models.Entities
{
    public class Announcement
    {


        public int Id { get; set; }
        public int ModelId { get; set; }
        public int March { get; set; }
        public double Price { get; set; }
        public TypeOfBan Banner { get; set; }
        public TypeOfFuel FuelType { get; set; }
        public TypeOfGearBox GearBox { get; set; }
        public TypeOfTransmission Transmission { get; set; }

        public DateTime CreatedAt { get; set; }

        public int CreatedBy { get; set; }
        public int? LastModifiedBy { get; set; }

        public DateTime? LastModifiedAt { get; set; }

        public int? DeletedBy { get; set; }

        public DateTime? DeletedAt { get; set; }

    }


}
