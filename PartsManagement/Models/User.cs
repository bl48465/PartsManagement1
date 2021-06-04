using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PartsManagement.Models
{
    public class User
    {
            [Key]
            public int UserId { get; set; }

            [Required]
            [MinLength(3)]
            public string Emri { get; set; }

            [Required]
            [MinLength(3)]
            public string Mbiemri { get; set; }

            [Required]
            [MinLength(3)]
            public string Kompania { get; set; }

            [Required]
            [EmailAddress]
            public string Email { get; set; }

            [Required]
            [MinLength(8)]
            [DataType(DataType.Password)]
            public string Password { get; set; }

            [Required]
            [NotMapped]
            [DataType(DataType.Password)]
            [Compare("Password")]

            public string Konfirmimi { get; set; }
            public DateTime CreatedAt { get; set; } = DateTime.Now;
            public DateTime UpdatedAt { get; set; } = DateTime.Now;

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

            //public List<Pjese> pjeset...
        }

        public class UserLogin
        {
            [Required]
            [EmailAddress]
            public string Email { get; set; }

            [Required]
            [MinLength(8)]
            [DataType(DataType.Password)]
            public string Password { get; set; }
        }
        public class AdminLogin
        {
            [Key]
            public int AdminId { get; set; }

            [Required]
            public string Username { get; set; }

            [Required]
            [MinLength(8)]
            [DataType(DataType.Password)]
            public string Password { get; set; }
        }
}

