using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PartsManagement.Models
{
    public class Komenti
    {
            
        [Key]
        public int KomentiID { get; set; }

        public string Titulli { get; set; }
        
        public string Mesazhi { get; set; }

        public User User { get; set; }
        
        public string CreatedAt { get; set; } = DateTime.Now.ToString("dd/MM/yyyy H:mm");
        public string UpdatedAt { get; set; } = DateTime.Now.ToString("dd/MM/yyyy H:mm");

    }
}
