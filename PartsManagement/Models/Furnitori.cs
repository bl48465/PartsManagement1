using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartsManagement.Models
{
    public class Furnitori
    {
        public int FurnitoriID { get; set; }
        public string EmriFurnitorit { get; set; }

        public FaturaHyrese Faturimi { get; set; }

    }
}
