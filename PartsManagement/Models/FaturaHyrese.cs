using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartsManagement.Models
{
    public class FaturaHyrese
    {
        public int FaturaHyreseID { get; set; }
        public string EmriFatures { get; set; }
        public string CreatedAt { get; set; } = DateTime.Now.ToString("dd/MM/yyyy H:mm");
        public DetajetHyrese Detajet { get; set; }
    }


}
