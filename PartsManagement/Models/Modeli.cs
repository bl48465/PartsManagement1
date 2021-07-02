using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartsManagement.Models
{
    public class Modeli
    {
        public int ModeliID { get; set; }

        public string EmriModelit { get; set; }

        public int MarkaID { get; set; }
        public Marka Marka { get; set; }
 
    
    }
}
