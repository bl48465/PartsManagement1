using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PartsManagement.Models
{
    public class Sektori
    {
        [Key]
        public int SektoriID { get; set; }

        [Required]
        public string Emri { get; set; }

        public int UserId { get; set; }
        public User Krijuesi { get; set; }

        public virtual List<Produkti> Produktet { get; set; }

    }
}
