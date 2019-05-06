using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace jabil_test.Models
{
    public partial class MaterialsContext : DbContext
    {
        public MaterialsContext()
        {
        }

        public MaterialsContext(DbContextOptions<MaterialsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Building> Buildings { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<PartNumber> PartNumbers { get; set; }
        public virtual DbSet<PartReport> PartReport { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Ignore<PartReport>();

            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity<Building>(entity =>
            {
                entity.HasKey(e => e.PKBuilding);

                entity.Property(e => e.PKBuilding).HasColumnName("PKBuilding");

                entity.Property(e => e.Name)
                    .HasColumnName("Building")
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasData(
                    new { PKBuilding = 1, Name = "Building1", Available = true },
                    new { PKBuilding = 2, Name = "Building2", Available = true },
                    new { PKBuilding = 3, Name = "Building3", Available = false });
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.PKCustomer);

                entity.Property(e => e.PKCustomer).HasColumnName("PKCustomer");

                entity.Property(e => e.Name)
                    .HasColumnName("Customer")
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FKBuilding).HasColumnName("FKBuilding");

                entity.Property(e => e.Prefix)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.HasOne(d => d.Building)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(d => d.FKBuilding)
                    .HasConstraintName("FK_Customers_Buildings")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();

                entity.HasData(
                    new { PKCustomer = 1, Name = "Luis", Prefix = "cust1", FKBuilding = 1, Available = true },
                    new { PKCustomer = 2, Name = "Pedro", Prefix = "cust2", FKBuilding = 2, Available = true },
                    new { PKCustomer = 3, Name = "Juan", Prefix = "cust3", FKBuilding = 2, Available = false });
            });

            modelBuilder.Entity<PartNumber>(entity =>
            {
                entity.HasKey(e => e.PKPartNumber);

                entity.Property(e => e.PKPartNumber).HasColumnName("PKPartNumber");

                entity.Property(e => e.FKCustomer).HasColumnName("FKCustomer");

                entity.Property(e => e.Name)
                    .HasColumnName("PartNumber")
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.PartNumbers)
                    .HasForeignKey(d => d.FKCustomer)
                    .HasConstraintName("FK_PartNumbers_Customers")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();

                entity.HasData(
                    new { PKPartNumber = 1, Name = "P1231", FKCustomer = 1, Available = true },
                    new { PKPartNumber = 2, Name = "P5322", FKCustomer = 2, Available = true },
                    new { PKPartNumber = 3, Name = "P5232", FKCustomer = 2, Available = false });
            });
        }
    }
}
