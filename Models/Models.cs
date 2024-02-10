using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turboazmini.Models
{
    public  class Models
    {
        static int count = 0;
        public int Id { get; private set; } 
        public string Name { get; set; }
        public Marka? Marka { get; set; }

        public Models()
        {
            count++;
            this.Id = count;

        }

    }
}
