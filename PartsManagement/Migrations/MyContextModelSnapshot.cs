﻿// <auto-generated />
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

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("KomentiID");

                    b.HasIndex("UserID");

                    b.ToTable("Komentet");
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

                    b.Property<int>("UserID")
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

                    b.Property<double>("Qmimi")
                        .HasColumnType("float");

                    b.Property<int>("Sasia")
                        .HasColumnType("int");

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

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("SektoriID");

                    b.HasIndex("UserId");

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

                    b.Property<string>("Emri")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OEnumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Qmimi")
                        .HasColumnType("float");

                    b.Property<int>("Sasia")
                        .HasColumnType("int");

                    b.Property<string>("UpdatedAt")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("ShitjaID");

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

            modelBuilder.Entity("PartsManagement.Models.Komenti", b =>
                {
                    b.HasOne("PartsManagement.Models.User", "Krijuesi")
                        .WithMany("Komentet")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PartsManagement.Models.Porosia", b =>
                {
                    b.HasOne("PartsManagement.Models.User", "Krijuesi")
                        .WithMany("Porosite")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
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
                    b.HasOne("PartsManagement.Models.User", "Krijuesi")
                        .WithMany("Sektoret")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PartsManagement.Models.Shitja", b =>
                {
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
