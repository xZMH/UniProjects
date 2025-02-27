﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using _77CarRental.Models;

#nullable disable

namespace _77CarRental.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240326175549_newmigration1")]
    partial class newmigration1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("_77CarRental.Models.Car", b =>
                {
                    b.Property<int>("CarId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CarId"));

                    b.Property<string>("CarStatus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Color")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImagePath")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Make")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<double?>("Price")
                        .IsRequired()
                        .HasColumnType("float");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("CarId");

                    b.ToTable("Cars");

                    b.HasData(
                        new
                        {
                            CarId = 1,
                            CarStatus = "Reserved",
                            Color = "Silver",
                            ImagePath = "Sedan01.png",
                            Make = "Toyota",
                            Model = "Camry",
                            Price = 100.0,
                            Year = 2020
                        },
                        new
                        {
                            CarId = 2,
                            CarStatus = "Available",
                            Color = "Red",
                            ImagePath = "Sedan01.png",
                            Make = "Mercedes",
                            Model = "E Class",
                            Price = 350.0,
                            Year = 2019
                        },
                        new
                        {
                            CarId = 3,
                            CarStatus = "Maintenance",
                            Color = "Black",
                            ImagePath = "Sedan01.png",
                            Make = "Nissan",
                            Model = "Sentra",
                            Price = 120.0,
                            Year = 2017
                        });
                });

            modelBuilder.Entity("_77CarRental.Models.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CustomerId"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.HasKey("CustomerId");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            CustomerId = 1,
                            Email = "Kholoudy24@hotmail.com",
                            FirstName = "Kholoud",
                            LastName = "Habash",
                            Phone = "0552121254"
                        },
                        new
                        {
                            CustomerId = 2,
                            Email = "Fatima@hotmail.com",
                            FirstName = "Noura",
                            LastName = "Al Shamsi",
                            Phone = "0529287929"
                        },
                        new
                        {
                            CustomerId = 3,
                            Email = "Zayed-AlHosani@outlook.com",
                            FirstName = "Zayed",
                            LastName = "Al Hosani",
                            Phone = "0567777129"
                        },
                        new
                        {
                            CustomerId = 4,
                            Email = "Aisha-AlShamsi@outlook.com",
                            FirstName = "Aisha",
                            LastName = "Al Shamsi",
                            Phone = "0501770144"
                        });
                });

            modelBuilder.Entity("_77CarRental.Models.Reservation", b =>
                {
                    b.Property<int>("ReservationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ReservationId"));

                    b.Property<int?>("CarId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int?>("CustomerId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<DateTime>("End_Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("ReservationStatus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Start_Date")
                        .HasColumnType("datetime2");

                    b.HasKey("ReservationId");

                    b.HasIndex("CarId");

                    b.HasIndex("CustomerId");

                    b.ToTable("Reservations");

                    b.HasData(
                        new
                        {
                            ReservationId = 1,
                            CarId = 1,
                            CustomerId = 1,
                            End_Date = new DateTime(2024, 3, 29, 21, 55, 49, 409, DateTimeKind.Local).AddTicks(7472),
                            ReservationStatus = "Completed",
                            Start_Date = new DateTime(2024, 3, 26, 21, 55, 49, 409, DateTimeKind.Local).AddTicks(7460)
                        },
                        new
                        {
                            ReservationId = 2,
                            CarId = 2,
                            CustomerId = 2,
                            End_Date = new DateTime(2024, 3, 30, 21, 55, 49, 409, DateTimeKind.Local).AddTicks(7474),
                            ReservationStatus = "Completed",
                            Start_Date = new DateTime(2024, 3, 26, 21, 55, 49, 409, DateTimeKind.Local).AddTicks(7473)
                        },
                        new
                        {
                            ReservationId = 3,
                            CarId = 3,
                            CustomerId = 3,
                            End_Date = new DateTime(2024, 3, 31, 21, 55, 49, 409, DateTimeKind.Local).AddTicks(7475),
                            ReservationStatus = "Completed",
                            Start_Date = new DateTime(2024, 3, 26, 21, 55, 49, 409, DateTimeKind.Local).AddTicks(7475)
                        });
                });

            modelBuilder.Entity("_77CarRental.Models.Review", b =>
                {
                    b.Property<int>("ReviewId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ReviewId"));

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.Property<int>("ReservationId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ReviewDate")
                        .HasColumnType("datetime2");

                    b.HasKey("ReviewId");

                    b.HasIndex("ReservationId");

                    b.ToTable("Reviews");

                    b.HasData(
                        new
                        {
                            ReviewId = 1,
                            Comment = "Excellent service and car condition.",
                            Rating = 5,
                            ReservationId = 1,
                            ReviewDate = new DateTime(2024, 3, 29, 21, 55, 49, 409, DateTimeKind.Local).AddTicks(7487)
                        },
                        new
                        {
                            ReviewId = 2,
                            Comment = "Very satisfied with the booking process.",
                            Rating = 4,
                            ReservationId = 2,
                            ReviewDate = new DateTime(2024, 3, 30, 21, 55, 49, 409, DateTimeKind.Local).AddTicks(7489)
                        });
                });

            modelBuilder.Entity("_77CarRental.Models.Reservation", b =>
                {
                    b.HasOne("_77CarRental.Models.Car", "Car")
                        .WithMany()
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("_77CarRental.Models.Customer", "Customer")
                        .WithMany("Reservations")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Car");

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("_77CarRental.Models.Review", b =>
                {
                    b.HasOne("_77CarRental.Models.Reservation", "Reservation")
                        .WithMany()
                        .HasForeignKey("ReservationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Reservation");
                });

            modelBuilder.Entity("_77CarRental.Models.Customer", b =>
                {
                    b.Navigation("Reservations");
                });
#pragma warning restore 612, 618
        }
    }
}
