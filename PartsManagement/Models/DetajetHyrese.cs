using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PartsManagement.Models
{
    public class DetajetHyrese
    {
        public int DetajetHyreseID { get; set; }
        public int Sasia { get; set; }
        public double Cmimi { get; set; }
        public FaturaHyrese Fatura { get; set; }
        public int FaturaHyreseID { get; set; }

        public int ProduktiID { get; set; }
        public  Produkti Produkti { get; set; }



    }
}
