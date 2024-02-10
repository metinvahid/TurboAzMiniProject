using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turboazmini.Models
{
    public  class Marka
    {
        static int count = 0;
        public int Id { get;private set; }
        public string Name { get;  set; }

        public Marka() 
        {
            count++;
            this.Id = count;
            

        }
    }
}
