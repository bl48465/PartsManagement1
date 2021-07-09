using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
namespace PartsManagement.Models
{
    public class Kerkesa
    {
        [Key]
        public int KekresaID { get; set; }
        public string EmriMbiemri { get; set; }
        public string Email { get; set; }
        public string Marka { get; set; }
        public string Modeli { get; set; }
        public string Mbishkrimi { get; set; }

        
    }
}
