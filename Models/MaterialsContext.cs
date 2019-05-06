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
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity<Building>(entity =>
            {
                entity.HasKey(e => e.Pkbuilding);

                entity.Property(e => e.Pkbuilding).HasColumnName("PKBuilding");

                entity.Property(e => e.Name)
                    .HasColumnName("Building")
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.Pkcustomer);

                entity.Property(e => e.Pkcustomer).HasColumnName("PKCustomer");

                entity.Property(e => e.Name)
                    .HasColumnName("Customer")
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Fkbuilding).HasColumnName("FKBuilding");

                entity.Property(e => e.Prefix)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.HasOne(d => d.Building)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(d => d.Fkbuilding)
                    .HasConstraintName("FK_Customers_Buildings")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();
            });

            modelBuilder.Entity<PartNumber>(entity =>
            {
                entity.HasKey(e => e.PkpartNumber);

                entity.Property(e => e.PkpartNumber).HasColumnName("PKPartNumber");

                entity.Property(e => e.Fkcustomer).HasColumnName("FKCustomer");

                entity.Property(e => e.Name)
                    .HasColumnName("PartNumber")
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.PartNumbers)
                    .HasForeignKey(d => d.Fkcustomer)
                    .HasConstraintName("FK_PartNumbers_Customers")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();
            });
        }
    }
}
