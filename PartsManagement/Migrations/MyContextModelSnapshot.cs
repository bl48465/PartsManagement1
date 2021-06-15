﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PartsManagement.Models;

namespace PartsManagement.Migrations
{
    [DbContext(typeof(MyContext))]
    partial class MyContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PartsManagement.Models.DetajetDalese", b =>
                {
                    b.Property<int>("DetajetDaleseID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Cmimi")
                        .HasColumnType("float");

                    b.Property<int>("FaturaDaleseID")
                        .HasColumnType("int");

                    b.Property<int>("ProduktiID")
                        .HasColumnType("int");

                    b.Property<int>("Sasia")
                        .HasColumnType("int");

                    b.HasKey("DetajetDaleseID");

                    b.HasIndex("FaturaDaleseID")
                        .IsUnique();

                    b.HasIndex("ProduktiID")
                        .IsUnique();

                    b.ToTable("DetajetDalese");
                });

            modelBuilder.Entity("PartsManagement.Models.DetajetHyrese", b =>
                {
                    b.Property<int>("DetajetHyreseID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Cmimi")
                        .HasColumnType("float");

                    b.Property<int>("FaturaHyreseID")
                        .HasColumnType("int");

                    b.Property<int>("ProduktiID")
                        .HasColumnType("int");

                    b.Property<int>("Sasia")
                        .HasColumnType("int");

                    b.HasKey("DetajetHyreseID");

                    b.HasIndex("FaturaHyreseID")
                        .IsUnique();

                    b.HasIndex("ProduktiID")
                        .IsUnique();

                    b.ToTable("DetajetHyrese");
                });

            modelBuilder.Entity("PartsManagement.Models.FaturaDalese", b =>
                {
                    b.Property<int>("FaturaDaleseID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreatedAt")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("FaturaDaleseID");

                    b.ToTable("FaturaDalese");
                });

            modelBuilder.Entity("PartsManagement.Models.FaturaHyrese", b =>
                {
                    b.Property<int>("FaturaHyreseID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreatedAt")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmriFatures")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("FaturaHyreseID");

                    b.ToTable("FaturaHyrese");
                });

            modelBuilder.Entity("PartsManagement.Models.Furnitori", b =>
                {
                    b.Property<int>("FurnitoriID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("EmriFurnitorit")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("FaturimiFaturaHyreseID")
                        .HasColumnType("int");

                    b.HasKey("FurnitoriID");

                    b.HasIndex("FaturimiFaturaHyreseID");

                    b.ToTable("Furnitoret");
                });

            modelBuilder.Entity("PartsManagement.Models.Komenti", b =>
                {
                    b.Property<int>("KomentiID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreatedAt")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Mesazhi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Titulli")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UpdatedAt")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UserID")
                        .HasColumnType("int");

                    b.HasKey("KomentiID");

                    b.HasIndex("UserID");

                    b.ToTable("Komentet");
                });

            modelBuilder.Entity("PartsManagement.Models.Marka", b =>
                {
                    b.Property<int>("MarkaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("EmriMarkes")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MarkaID");

                    b.ToTable("Marka");
                });

            modelBuilder.Entity("PartsManagement.Models.Modeli", b =>
                {
                    b.Property<int>("ModeliID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("EmriModelit")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("MarkaID")
                        .HasColumnType("int");

                    b.HasKey("ModeliID");

                    b.HasIndex("MarkaID");

                    b.ToTable("Modeli");
                });

            modelBuilder.Entity("PartsManagement.Models.PerkatesiaProduktit", b =>
                {
                    b.Property<int>("modeliID")
                        .HasColumnType("int");

                    b.Property<int>("produktiID")
                        .HasColumnType("int");

                    b.HasKey("modeliID", "produktiID");

                    b.HasIndex("produktiID");

                    b.ToTable("PerkatesiaProduktit");
                });

            modelBuilder.Entity("PartsManagement.Models.Porosia", b =>
                {
                    b.Property<int>("PorosiaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreatedAt")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Emri")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Sasia")
                        .HasColumnType("int");

                    b.Property<string>("UpdatedAt")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UserID")
                        .HasColumnType("int");

                    b.HasKey("PorosiaID");

                    b.HasIndex("UserID");

                    b.ToTable("Porosite");
                });

            modelBuilder.Entity("PartsManagement.Models.Produkti", b =>
                {
                    b.Property<int>("ProduktiID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreatedAt")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Emri")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OEnumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SektoriID")
                        .HasColumnType("int");

                    b.Property<string>("UpdatedAt")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProduktiID");

                    b.HasIndex("SektoriID");

                    b.ToTable("Produktet");
                });

            modelBuilder.Entity("PartsManagement.Models.Sektori", b =>
                {
                    b.Property<int>("SektoriID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Emri")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UserID")
                        .HasColumnType("int");

                    b.HasKey("SektoriID");

                    b.HasIndex("UserID");

                    b.ToTable("Sektoret");
                });

            modelBuilder.Entity("PartsManagement.Models.Shitja", b =>
                {
                    b.Property<int>("ShitjaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreatedAt")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FaturaDaleseID")
                        .HasColumnType("int");

                    b.Property<string>("Komenti")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UpdatedAt")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("ShitjaID");

                    b.HasIndex("FaturaDaleseID")
                        .IsUnique();

                    b.HasIndex("UserID");

                    b.ToTable("Shitjet");
                });

            modelBuilder.Entity("PartsManagement.Models.User", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreatedAt")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Emri")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Kompania")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Mbiemri")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Roli")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UpdatedAt")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("PartsManagement.Models.DetajetDalese", b =>
                {
                    b.HasOne("PartsManagement.Models.FaturaDalese", "FaturimiDales")
                        .WithOne("DetajetDalese")
                        .HasForeignKey("PartsManagement.Models.DetajetDalese", "FaturaDaleseID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PartsManagement.Models.Produkti", "Prod")
                        .WithOne("DetajetDalese")
                        .HasForeignKey("PartsManagement.Models.DetajetDalese", "ProduktiID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PartsManagement.Models.DetajetHyrese", b =>
                {
                    b.HasOne("PartsManagement.Models.FaturaHyrese", "Fatura")
                        .WithOne("Detajet")
                        .HasForeignKey("PartsManagement.Models.DetajetHyrese", "FaturaHyreseID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PartsManagement.Models.Produkti", "Produkti")
                        .WithOne("DetajetHyrese")
                        .HasForeignKey("PartsManagement.Models.DetajetHyrese", "ProduktiID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PartsManagement.Models.Furnitori", b =>
                {
                    b.HasOne("PartsManagement.Models.FaturaHyrese", "Faturimi")
                        .WithMany()
                        .HasForeignKey("FaturimiFaturaHyreseID");
                });

            modelBuilder.Entity("PartsManagement.Models.Komenti", b =>
                {
                    b.HasOne("PartsManagement.Models.User", "User")
                        .WithMany("Komentet")
                        .HasForeignKey("UserID");
                });

            modelBuilder.Entity("PartsManagement.Models.Modeli", b =>
                {
                    b.HasOne("PartsManagement.Models.Marka", "Marka")
                        .WithMany("Modelet")
                        .HasForeignKey("MarkaID");
                });

            modelBuilder.Entity("PartsManagement.Models.PerkatesiaProduktit", b =>
                {
                    b.HasOne("PartsManagement.Models.Modeli", "model")
                        .WithMany("ProduktetPerkatese")
                        .HasForeignKey("modeliID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PartsManagement.Models.Produkti", "prod")
                        .WithMany("ProduktetPerkatese")
                        .HasForeignKey("produktiID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PartsManagement.Models.Porosia", b =>
                {
                    b.HasOne("PartsManagement.Models.User", "User")
                        .WithMany("Porosite")
                        .HasForeignKey("UserID");
                });

            modelBuilder.Entity("PartsManagement.Models.Produkti", b =>
                {
                    b.HasOne("PartsManagement.Models.Sektori", "Sektori")
                        .WithMany("Produktet")
                        .HasForeignKey("SektoriID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PartsManagement.Models.Sektori", b =>
                {
                    b.HasOne("PartsManagement.Models.User", "User")
                        .WithMany("Sektoret")
                        .HasForeignKey("UserID");
                });

            modelBuilder.Entity("PartsManagement.Models.Shitja", b =>
                {
                    b.HasOne("PartsManagement.Models.FaturaDalese", "FaturimiDales")
                        .WithOne("Shitja")
                        .HasForeignKey("PartsManagement.Models.Shitja", "FaturaDaleseID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PartsManagement.Models.User", "User")
                        .WithMany("Shitjet")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
