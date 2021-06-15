using System;
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

        protected override void OnModelCreating(ModelBuilder model)
        {
            model.Entity<User>()
                 .HasMany(s => s.Sektoret)
                 .WithOne(u => u.User);

            model.Entity<User>()
                 .HasMany(s => s.Shitjet)
                 .WithOne(u => u.User);

            model.Entity<User>()
                 .HasMany(s => s.Komentet)
                 .WithOne(u => u.User);

            model.Entity<User>()
                 .HasMany(s => s.Porosite)
                 .WithOne(u => u.User);

            model.Entity<User>()
                 .HasMany(s => s.Sektoret)
                 .WithOne(u => u.User);

            model.Entity<Sektori>()
                .HasMany(p => p.Produktet)
                .WithOne(s => s.Sektori);

            model.Entity<PerkatesiaProduktit>()
                .HasKey(b => new { b.modeliID, b.produktiID });

            model.Entity<PerkatesiaProduktit>()
                .HasOne(b => b.model)
                .WithMany(bc => bc.ProduktetPerkatese)
                .HasForeignKey(b => b.modeliID);

            model.Entity<PerkatesiaProduktit>()
               .HasOne(b => b.prod)
               .WithMany(c => c.ProduktetPerkatese)
               .HasForeignKey(b => b.produktiID);

        }
    }
}
