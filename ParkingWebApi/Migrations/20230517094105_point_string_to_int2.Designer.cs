﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ParkingWebApi.Data;

#nullable disable

namespace ParkingWebApi.Migrations
{
    [DbContext(typeof(ParkingSystemDbContext))]
    [Migration("20230517094105_point_string_to_int2")]
    partial class point_string_to_int2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ParkingApp_Core.Models.Car", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Car_Plate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("ParkingApp_Core.Models.Park", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("CarId")
                        .HasColumnType("int");

                    b.Property<bool>("IsBusy")
                        .HasColumnType("bit");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CarId")
                        .IsUnique()
                        .HasFilter("[CarId] IS NOT NULL");

                    b.HasIndex("UserId")
                        .IsUnique()
                        .HasFilter("[UserId] IS NOT NULL");

                    b.ToTable("Parks");
                });

            modelBuilder.Entity("ParkingApp_Core.Models.Score", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Point")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Scores");
                });

            modelBuilder.Entity("ParkingApp_Core.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FreeTicket")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ParkingApp_Core.Models.Car", b =>
                {
                    b.HasOne("ParkingApp_Core.Models.User", "User")
                        .WithOne("Car")
                        .HasForeignKey("ParkingApp_Core.Models.Car", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("ParkingApp_Core.Models.Park", b =>
                {
                    b.HasOne("ParkingApp_Core.Models.Car", "Car")
                        .WithOne("Park")
                        .HasForeignKey("ParkingApp_Core.Models.Park", "CarId");

                    b.HasOne("ParkingApp_Core.Models.User", "User")
                        .WithOne("Park")
                        .HasForeignKey("ParkingApp_Core.Models.Park", "UserId");

                    b.Navigation("Car");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ParkingApp_Core.Models.Score", b =>
                {
                    b.HasOne("ParkingApp_Core.Models.User", "User")
                        .WithOne("Score")
                        .HasForeignKey("ParkingApp_Core.Models.Score", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("ParkingApp_Core.Models.Car", b =>
                {
                    b.Navigation("Park")
                        .IsRequired();
                });

            modelBuilder.Entity("ParkingApp_Core.Models.User", b =>
                {
                    b.Navigation("Car")
                        .IsRequired();

                    b.Navigation("Park")
                        .IsRequired();

                    b.Navigation("Score")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
