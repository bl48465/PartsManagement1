using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartsManagement.Models
{
    public class Marka
    {
        public int MarkaID { get; set; }

        public string EmriMarkes { get; set; }

        public ICollection<Modeli> Modelet { get; set; }

    }
}
