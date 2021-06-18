using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PartsManagement.Models
{
    public class User
    {
        [Key]
        public int UserID { get; set; }

        [Required]
        [MinLength(3)]
        public string Emri { get; set; }

        [Required]
        [MinLength(3)]
        public string Mbiemri { get; set; }

        [Required]
        [MinLength(3)]
        public string Kompania { get; set; }

        public int VendbanimiID { get; set; }
        public Vendbanimi Vendbanimi { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [JsonIgnore]
        [MinLength(8)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [JsonIgnore]
        [NotMapped]
        [DataType(DataType.Password)]
        [Compare("Password")]

        public string Konfirmimi { get; set; }

        public string CreatedAt { get; set; } = DateTime.Now.ToString("dd/MM/yyyy H:mm");
        public string UpdatedAt { get; set; } = DateTime.Now.ToString("dd/MM/yyyy H:mm");

        private string _status = "Pending";
       
        public string Status
        {
            get
            {
                return this._status;
            }
            set
            {
                this._status = value;
            }
        }

        private int _roli = 1;
        [JsonIgnore]
        public int Roli
        {
            get
            {
                return this._roli;
            }
            set
            {
                this._roli = value;
            }
        }

        public  ICollection<Sektori> Sektoret { get; set; } = new List<Sektori>();
        public  ICollection<Porosia> Porosite { get; set; } = new List<Porosia>();
        public  ICollection<Shitja> Shitjet { get; set; } = new List<Shitja>();
        public  ICollection<Komenti> Komentet { get; set; } = new List<Komenti>();
    }
}

