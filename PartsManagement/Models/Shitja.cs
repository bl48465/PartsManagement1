using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace PartsManagement.Models
{
    public class Shitja
    {

        public int ShitjaId { get; set; }

        public string UserId { get; set; }

        public int FaturaId { get; set; }

        [JsonIgnore]
        public User User { get; set; }

     
    }
}
