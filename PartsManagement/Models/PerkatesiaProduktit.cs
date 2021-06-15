using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartsManagement.Models
{
    public class PerkatesiaProduktit
    {
        public int produktiID { get; set; }
        public Produkti prod { get; set; }
        public int modeliID { get; set; }
        public Modeli model { get; set; }
    }
}
