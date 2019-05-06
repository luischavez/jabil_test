﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using jabil_test.Models;

namespace jabil_test.Migrations
{
    [DbContext(typeof(MaterialsContext))]
    [Migration("20190504222019_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("jabil_test.Models.Building", b =>
                {
                    b.Property<int>("Pkbuilding")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("PKBuilding")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Available");

                    b.Property<string>("Name")
                        .HasColumnName("Building")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.HasKey("Pkbuilding");

                    b.ToTable("Buildings");
                });

            modelBuilder.Entity("jabil_test.Models.Customer", b =>
                {
                    b.Property<int>("Pkcustomer")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("PKCustomer")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Available");

                    b.Property<string>("Name")
                        .HasColumnName("Customer")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.Property<int>("Fkbuilding")
                        .HasColumnName("FKBuilding");

                    b.Property<string>("Prefix")
                        .IsRequired()
                        .HasMaxLength(5)
                        .IsUnicode(false);

                    b.HasKey("Pkcustomer");

                    b.HasIndex("Fkbuilding");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("jabil_test.Models.PartNumber", b =>
                {
                    b.Property<int>("PkpartNumber")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("PKPartNumber")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Available");

                    b.Property<int>("Fkcustomer")
                        .HasColumnName("FKCustomer");

                    b.Property<string>("Name")
                        .HasColumnName("PartNumber")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.HasKey("PkpartNumber");

                    b.HasIndex("Fkcustomer");

                    b.ToTable("PartNumbers");
                });

            modelBuilder.Entity("jabil_test.Models.Customer", b =>
                {
                    b.HasOne("jabil_test.Models.Building", "FkbuildingNavigation")
                        .WithMany("Customers")
                        .HasForeignKey("Fkbuilding")
                        .HasConstraintName("FK_Customers_Buildings")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("jabil_test.Models.PartNumber", b =>
                {
                    b.HasOne("jabil_test.Models.Customer", "FkcustomerNavigation")
                        .WithMany("PartNumbers")
                        .HasForeignKey("Fkcustomer")
                        .HasConstraintName("FK_PartNumbers_Customers")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
