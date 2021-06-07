﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace PartsManagement.Models
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Komenti> Komentet { get; set; }
        public DbSet<Produkti> Produktet { get; set; }
        public DbSet<Porosia> Porosite { get; set; }
        public DbSet<Sektori> Sektoret { get; set; }
        public DbSet<Shitja> Shitjet { get; set; }
    }
}
