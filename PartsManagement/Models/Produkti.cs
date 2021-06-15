using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

namespace PartsManagement.Models
{
    public class Produkti
    {
        [Key]
        public int ProduktiID { get; set; }

        public string Emri { get; set; }

        public string OEnumber { get; set; }

        public int SektoriID { get; set; }
        [JsonIgnore]
        public Sektori Sektori { get; set; }

        public DetajetHyrese DetajetHyrese { get; set; }
        public DetajetDalese DetajetDalese { get; set; }

        public string CreatedAt { get; set; } = DateTime.Now.ToString("dd/MM/yyyy H:mm");
        public string UpdatedAt { get; set; } = DateTime.Now.ToString("dd/MM/yyyy H:mm");
        public ICollection<PerkatesiaProduktit> ProduktetPerkatese { get; set; }
    }

}
