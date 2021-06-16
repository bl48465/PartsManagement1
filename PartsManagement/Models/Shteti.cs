using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartsManagement.Models
{
    public class Shteti
    {
        public int ShtetiID { get; set; }
        public string EmriShtetit { get; set; }
        public ICollection<Vendbanimi> Qyteti { get; set; }
    }
}
