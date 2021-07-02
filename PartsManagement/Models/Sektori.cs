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
    public class Sektori
    {
        [Key]
        public int SektoriID { get; set; }

        [Required]
        public string Emri { get; set; }

        public User User { get; set; }

        public virtual ICollection<Produkti> Produktet { get; set; } = new List<Produkti>();

    }
}
