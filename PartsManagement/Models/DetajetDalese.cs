using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartsManagement.Models
{
    public class DetajetDalese
    {
        public int DetajetDaleseID { get; set; }
        public int Sasia { get; set; }
        public double Cmimi { get; set; }
        public int FaturaDaleseID { get; set; }
        public FaturaDalese FaturimiDales { get; set; }
        public int ProduktiID { get; set; }
        public Produkti Prod { get; set; }

    }

}
