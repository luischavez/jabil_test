﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using jabil_test.Models;

namespace jabil_test.Migrations
{
    [DbContext(typeof(MaterialsContext))]
    partial class MaterialsContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("jabil_test.Models.Building", b =>
                {
                    b.Property<int>("PKBuilding")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Available");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.HasKey("PKBuilding");

                    b.ToTable("Buildings");
                });

            modelBuilder.Entity("jabil_test.Models.Customer", b =>
                {
                    b.Property<int>("PKCustomer")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Available");

                    b.Property<int>("FKBuilding");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("Customer")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.Property<string>("Prefix")
                        .IsRequired()
                        .HasMaxLength(5)
                        .IsUnicode(false);

                    b.HasKey("PKCustomer");

                    b.HasIndex("FKBuilding");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("jabil_test.Models.PartNumber", b =>
                {
                    b.Property<int>("PKPartNumber")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Available");

                    b.Property<int>("FKCustomer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("PartNumber")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.HasKey("PKPartNumber");

                    b.HasIndex("FKCustomer");

                    b.ToTable("PartNumbers");
                });

            modelBuilder.Entity("jabil_test.Models.Customer", b =>
                {
                    b.HasOne("jabil_test.Models.Building", "Building")
                        .WithMany("Customers")
                        .HasForeignKey("FKBuilding")
                        .HasConstraintName("FK_Customers_Buildings")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("jabil_test.Models.PartNumber", b =>
                {
                    b.HasOne("jabil_test.Models.Customer", "Customer")
                        .WithMany("PartNumbers")
                        .HasForeignKey("FKCustomer")
                        .HasConstraintName("FK_PartNumbers_Customers")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
