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

        public double Qmimi { get; set; }

        public int Sasia { get; set; }

        public string OEnumber { get; set; }

        public int SektoriID { get; set; }
        [JsonIgnore]
        public Sektori Sektori { get; set; }

        public string CreatedAt { get; set; } = DateTime.Now.ToString("dd/MM/yyyy H:mm");
        public string UpdatedAt { get; set; } = DateTime.Now.ToString("dd/MM/yyyy H:mm");
    }

}
