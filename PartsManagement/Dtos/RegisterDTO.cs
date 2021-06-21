using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartsManagement.Dtos
{
    public class RegisterDTO
    {
        public string Emri { get; set; }
        public string Mbiemri { get; set; }
        public string Kompania { get; set; }
        public int VendbanimiID { get;  set; }
        public string Email { get; set; }
        public string Password { get; set; } 
        public string Konfirmimi { get; set; }
 
    }
}
