using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PartsManagement.Models
{
    public class FaturaOUT
    {
        [Key]
        public int FaturaId { get; set; }
        public int Sasia { get; set; }
        public double Qmimi { get; set; }
        public double Totali { get; set; }

        public int ProduktiId { get; set; }

        public Shitja Shitja { get; set; }
        public int ShitjaId { get; set; }
    }
}
