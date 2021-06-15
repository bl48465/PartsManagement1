using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartsManagement.Models
{
    public class FaturaDalese
    {
        public int FaturaDaleseID { get; set; }
        public string CreatedAt { get; set; } = DateTime.Now.ToString("dd/MM/yyyy H:mm");
        public DetajetDalese DetajetDalese { get; set; }
        public Shitja Shitja { get; set; }
    }
}
