using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
namespace PartsManagement.Models
{
    public class Shitja
    {
        [Key]
        public int ShitjaID { get; set; }

        public string Emri { get; set; }

        public int UserID { get; set; }
        public User User { get; set; }
        public double Qmimi { get; set; }

        public int Sasia { get; set; }

        public string OEnumber { get; set; }


        public string CreatedAt { get; set; } = DateTime.Now.ToString("dd/MM/yyyy H:mm");
        public string UpdatedAt { get; set; } = DateTime.Now.ToString("dd/MM/yyyy H:mm");
    }
}
