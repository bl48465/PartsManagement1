using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartsManagement.Models
{
    public class Vendbanimi
    {
        public int VendbanimiID { get; set; }
        public string EmriQytetit { get; set; }
        public int ShtetiID { get; set; }
        public Shteti Shteti { get; set; }
        public ICollection<User> Users { get; set; }

    }
}
