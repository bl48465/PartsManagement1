using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PartsManagement.Dtos;

using System.ComponentModel.DataAnnotations;

namespace PartsManagement.Dtos
{
    public class CreateKerkesaDTO
    {
        [Required]
       
        public string EmriMbiemri { get; set; }

        public string Email { get; set; }
        public string Marka { get; set; }
        public string Modeli { get; set; }
        public string Mbishkrimi { get; set; }

    }
    public class UpdateKerkesaDTO : CreateKerkesaDTO
    {

    }
    public class KerkesaDTO : CreateKerkesaDTO
    {
        public int KerkesaId { get; set; }
    }
}
