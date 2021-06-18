using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PartsManagement.Models;


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

        public DbSet<Furnitori> Furnitoret { get; set; }

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

            model.Entity<User>()
           .HasOne(s => s.Vendbanimi)
           .WithMany(g => g.Users)
           .HasForeignKey(s => s.VendbanimiID);

            model.Entity<Vendbanimi>()
         .HasOne(s => s.Shteti)
         .WithMany(g => g.Qyteti)
         .HasForeignKey(s => s.ShtetiID);


        model.Entity<Shteti>().HasData(
            new Shteti() { ShtetiID = 1, EmriShtetit = "Kosovë" },
            new Shteti() { ShtetiID = 2, EmriShtetit = "Shqipëri" },
            new Shteti() { ShtetiID = 3, EmriShtetit = "Maqedoni" }
            );

        model.Entity<Vendbanimi>().HasData(

             new Vendbanimi() { VendbanimiID = 1, ShtetiID = 1, EmriQytetit = "Artanë" },
             new Vendbanimi() { VendbanimiID = 2, ShtetiID = 1, EmriQytetit = "Besianë" },
             new Vendbanimi() { VendbanimiID = 3, ShtetiID = 1, EmriQytetit = "Burim" },
             new Vendbanimi() { VendbanimiID = 4, ShtetiID = 1, EmriQytetit = "Dardanë" },
             new Vendbanimi() { VendbanimiID = 5, ShtetiID = 1, EmriQytetit = "Decan" },
             new Vendbanimi() { VendbanimiID = 6, ShtetiID = 1, EmriQytetit = "Dragash" },
             new Vendbanimi() { VendbanimiID = 7, ShtetiID = 1, EmriQytetit = "Drenas" },
             new Vendbanimi() { VendbanimiID = 8, ShtetiID = 1, EmriQytetit = "Ferizaj" },
             new Vendbanimi() { VendbanimiID = 9, ShtetiID = 1, EmriQytetit = "Fushë Kosovë" },
             new Vendbanimi() { VendbanimiID = 10, ShtetiID = 1, EmriQytetit = "Gjakovë" },
             new Vendbanimi() { VendbanimiID = 11, ShtetiID = 1, EmriQytetit = "Gjilan" },
             new Vendbanimi() { VendbanimiID = 12, ShtetiID = 1, EmriQytetit = "Kastriot" },
             new Vendbanimi() { VendbanimiID = 13, ShtetiID = 1, EmriQytetit = "Kaqanik" },
             new Vendbanimi() { VendbanimiID = 14, ShtetiID = 1, EmriQytetit = "Klinë" },
             new Vendbanimi() { VendbanimiID = 15, ShtetiID = 1, EmriQytetit = "Leposaviq" },
             new Vendbanimi() { VendbanimiID = 16, ShtetiID = 1, EmriQytetit = "Lipjan" },
             new Vendbanimi() { VendbanimiID = 17, ShtetiID = 1, EmriQytetit = "Malishevë" },
             new Vendbanimi() { VendbanimiID = 18, ShtetiID = 1, EmriQytetit = "Mitrovicë" },
             new Vendbanimi() { VendbanimiID = 19, ShtetiID = 1, EmriQytetit = "Pejë" },
             new Vendbanimi() { VendbanimiID = 20, ShtetiID = 1, EmriQytetit = "Prishtinë" },
             new Vendbanimi() { VendbanimiID = 21, ShtetiID = 1, EmriQytetit = "Prizren" },
             new Vendbanimi() { VendbanimiID = 22, ShtetiID = 1, EmriQytetit = "Rahovec" },
             new Vendbanimi() { VendbanimiID = 23, ShtetiID = 1, EmriQytetit = "Skënderaj" },
             new Vendbanimi() { VendbanimiID = 24, ShtetiID = 1, EmriQytetit = "Shtërpcë" },
             new Vendbanimi() { VendbanimiID = 25, ShtetiID = 1, EmriQytetit = "Shtime" },
             new Vendbanimi() { VendbanimiID = 26, ShtetiID = 1, EmriQytetit = "Therandë" },
             new Vendbanimi() { VendbanimiID = 27, ShtetiID = 1, EmriQytetit = "Viti" },
             new Vendbanimi() { VendbanimiID = 28, ShtetiID = 1, EmriQytetit = "Vushtrri" },
             new Vendbanimi() { VendbanimiID = 29, ShtetiID = 1, EmriQytetit = "Zubin Potok" },
             new Vendbanimi() { VendbanimiID = 30, ShtetiID = 1, EmriQytetit = "Zveqan" },


             new Vendbanimi() { VendbanimiID = 31, ShtetiID = 2, EmriQytetit = "Berat" },
             new Vendbanimi() { VendbanimiID = 32, ShtetiID = 2, EmriQytetit = "Bulqizë" },
             new Vendbanimi() { VendbanimiID = 33, ShtetiID = 2, EmriQytetit = "Delvinë" },
             new Vendbanimi() { VendbanimiID = 34, ShtetiID = 2, EmriQytetit = "Devoll" },
             new Vendbanimi() { VendbanimiID = 35, ShtetiID = 2, EmriQytetit = "Dibër" },
             new Vendbanimi() { VendbanimiID = 36, ShtetiID = 2, EmriQytetit = "Durrës" },
             new Vendbanimi() { VendbanimiID = 37, ShtetiID = 2, EmriQytetit = "Elbasan" },
             new Vendbanimi() { VendbanimiID = 38, ShtetiID = 2, EmriQytetit = "Fier" },
             new Vendbanimi() { VendbanimiID = 39, ShtetiID = 2, EmriQytetit = "Gramsh" },
             new Vendbanimi() { VendbanimiID = 40, ShtetiID = 2, EmriQytetit = "Gjirokastër" },
             new Vendbanimi() { VendbanimiID = 41, ShtetiID = 2, EmriQytetit = "Has" },
             new Vendbanimi() { VendbanimiID = 42, ShtetiID = 2, EmriQytetit = "Kavajë" },
             new Vendbanimi() { VendbanimiID = 43, ShtetiID = 2, EmriQytetit = "Kolonjë" },
             new Vendbanimi() { VendbanimiID = 44, ShtetiID = 2, EmriQytetit = "Korcë" },
             new Vendbanimi() { VendbanimiID = 45, ShtetiID = 2, EmriQytetit = "Krujë" },
             new Vendbanimi() { VendbanimiID = 46, ShtetiID = 2, EmriQytetit = "Kucovë" },
             new Vendbanimi() { VendbanimiID = 47, ShtetiID = 2, EmriQytetit = "Kukës" },
             new Vendbanimi() { VendbanimiID = 48, ShtetiID = 2, EmriQytetit = "Kurbin" },
             new Vendbanimi() { VendbanimiID = 49, ShtetiID = 2, EmriQytetit = "Lezhë" },
             new Vendbanimi() { VendbanimiID = 50, ShtetiID = 2, EmriQytetit = "Librazhd" },
             new Vendbanimi() { VendbanimiID = 51, ShtetiID = 2, EmriQytetit = "Lushnjë" },
             new Vendbanimi() { VendbanimiID = 52, ShtetiID = 2, EmriQytetit = "Malësi e madhe" },
             new Vendbanimi() { VendbanimiID = 53, ShtetiID = 2, EmriQytetit = "Mallakastër" },
             new Vendbanimi() { VendbanimiID = 54, ShtetiID = 2, EmriQytetit = "Mat" },
             new Vendbanimi() { VendbanimiID = 55, ShtetiID = 2, EmriQytetit = "Mirditë" },
             new Vendbanimi() { VendbanimiID = 56, ShtetiID = 2, EmriQytetit = "Peqin" },
             new Vendbanimi() { VendbanimiID = 57, ShtetiID = 2, EmriQytetit = "Përmet" },
             new Vendbanimi() { VendbanimiID = 58, ShtetiID = 2, EmriQytetit = "Pogradec" },
             new Vendbanimi() { VendbanimiID = 59, ShtetiID = 2, EmriQytetit = "Pukë" },
             new Vendbanimi() { VendbanimiID = 60, ShtetiID = 2, EmriQytetit = "Sarandë" },
             new Vendbanimi() { VendbanimiID = 61, ShtetiID = 2, EmriQytetit = "Skrapar" },
             new Vendbanimi() { VendbanimiID = 62, ShtetiID = 2, EmriQytetit = "Shkodër" },
             new Vendbanimi() { VendbanimiID = 63, ShtetiID = 2, EmriQytetit = "Tepelenë" },
             new Vendbanimi() { VendbanimiID = 64, ShtetiID = 2, EmriQytetit = "Tiranë" },
             new Vendbanimi() { VendbanimiID = 65, ShtetiID = 2, EmriQytetit = "Tropojë" },
             new Vendbanimi() { VendbanimiID = 66, ShtetiID = 2, EmriQytetit = "Vlorë" }
        );
    }

    

        public DbSet<PartsManagement.Models.FaturaDalese> FaturaDalese { get; set; }

        public DbSet<PartsManagement.Models.FaturaHyrese> FaturaHyrese { get; set; }

        public DbSet<PartsManagement.Models.DetajetDalese> DetajetDalese { get; set; }

        public DbSet<PartsManagement.Models.DetajetHyrese> DetajetHyrese { get; set; }

        public DbSet<PartsManagement.Models.Modeli> Modeli { get; set; }

        public DbSet<PartsManagement.Models.Marka> Marka { get; set; }

        public DbSet<PartsManagement.Models.Shteti> Shteti { get; set; }

        public DbSet<PartsManagement.Models.Vendbanimi> Vendbanimi { get; set; }

    }
}



