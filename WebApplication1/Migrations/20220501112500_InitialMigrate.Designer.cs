﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApplication1.Data;

namespace WebApplication1.Migrations
{
    [DbContext(typeof(WarehouseDbContext))]
    [Migration("20220501112500_InitialMigrate")]
    partial class InitialMigrate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.24");

            modelBuilder.Entity("WebApplication1.Models.Car", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("Location")
                        .HasColumnType("TEXT");

                    b.Property<string>("WarehouseId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("WarehouseId")
                        .IsUnique();

                    b.ToTable("Car");
                });

            modelBuilder.Entity("WebApplication1.Models.Location", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<double>("Lat")
                        .HasColumnType("REAL");

                    b.Property<double>("Long")
                        .HasColumnType("REAL");

                    b.Property<string>("WarehouseId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("WarehouseId")
                        .IsUnique();

                    b.ToTable("Location");
                });

            modelBuilder.Entity("WebApplication1.Models.Vehicle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CarID")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateAdded")
                        .HasColumnType("TEXT");

                    b.Property<bool>("Licensed")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Make")
                        .HasColumnType("TEXT");

                    b.Property<string>("Model")
                        .HasColumnType("TEXT");

                    b.Property<double>("Price")
                        .HasColumnType("REAL");

                    b.Property<int>("YearModel")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("CarID");

                    b.ToTable("Vehicle");
                });

            modelBuilder.Entity("WebApplication1.Models.Warehouse", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Warehouse");
                });

            modelBuilder.Entity("WebApplication1.Models.Car", b =>
                {
                    b.HasOne("WebApplication1.Models.Warehouse", null)
                        .WithOne("Cars")
                        .HasForeignKey("WebApplication1.Models.Car", "WarehouseId");
                });

            modelBuilder.Entity("WebApplication1.Models.Location", b =>
                {
                    b.HasOne("WebApplication1.Models.Warehouse", null)
                        .WithOne("Location")
                        .HasForeignKey("WebApplication1.Models.Location", "WarehouseId");
                });

            modelBuilder.Entity("WebApplication1.Models.Vehicle", b =>
                {
                    b.HasOne("WebApplication1.Models.Car", null)
                        .WithMany("Vehicles")
                        .HasForeignKey("CarID");
                });
#pragma warning restore 612, 618
        }
    }
}