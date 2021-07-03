using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartsManagement.Dtos
{
    public class CreateShitjaDTO
    {
        public string UserId { get; set; }
        public int FaturaId { get; set; }

    }
    public class ShitjaDTO
    {
        public int ShitjaId { get; set; }
    }
}
