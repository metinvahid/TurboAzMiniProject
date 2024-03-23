using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turboazmini.Models.Entities
{
    public class Model
    {

        public int Id { get; set; }
        public string Name { get; set; }

        public int BrandId { get; set; }
        public DateTime CreatedAt { get; set; }

        public int CreatedBy { get; set; }

        public int? LastModifiedBy { get; set; }

        public DateTime? LastModifiedAt { get; set; }

        public int? DeletedBy { get; set; }

        public DateTime? DeletedAt { get; set; }


    }
}
