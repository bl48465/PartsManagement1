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

        public string Komenti { get; set; }
        public User User { get; set; }
       
        public int UserID { get; set; }

<<<<<<< HEAD

        [JsonIgnore]
        public FaturaOUT Fatura { get; set; }
     
=======
        public int FaturaDaleseID { get; set; }
        public FaturaDalese FaturimiDales { get; set; }
        public string CreatedAt { get; set; } = DateTime.Now.ToString("dd/MM/yyyy H:mm");
        public string UpdatedAt { get; set; } = DateTime.Now.ToString("dd/MM/yyyy H:mm");
>>>>>>> parent of bf1934f (Backend Refactor Completed - Final ?)
    }
}
