﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RideShareRestApi.Entity.Models;

namespace RideShareRestApi.Entity.Migrations
{
    [DbContext(typeof(RideShareContext))]
    [Migration("20201213175935_create-database")]
    partial class createdatabase
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("RideShareRestApi.Entity.Models.City", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CityName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CityNumber")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("RideShareRestApi.Entity.Models.TravelPassenger", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<Guid>("TravelPlanId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("TravelPlanId");

                    b.HasIndex("UserId");

                    b.ToTable("TravelPassengers");
                });

            modelBuilder.Entity("RideShareRestApi.Entity.Models.TravelPlan", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("FinishCityId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<bool>("IsPublish")
                        .HasColumnType("bit");

                    b.Property<int>("SeatsCount")
                        .HasColumnType("int");

                    b.Property<Guid>("StartCityId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("TravelTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("FinishCityId");

                    b.HasIndex("StartCityId");

                    b.HasIndex("UserId");

                    b.ToTable("TravelPlans");
                });

            modelBuilder.Entity("RideShareRestApi.Entity.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("RideShareRestApi.Entity.Models.TravelPassenger", b =>
                {
                    b.HasOne("RideShareRestApi.Entity.Models.TravelPlan", "TravelPlan")
                        .WithMany()
                        .HasForeignKey("TravelPlanId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("RideShareRestApi.Entity.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("TravelPlan");

                    b.Navigation("User");
                });

            modelBuilder.Entity("RideShareRestApi.Entity.Models.TravelPlan", b =>
                {
                    b.HasOne("RideShareRestApi.Entity.Models.City", "FinishCity")
                        .WithMany()
                        .HasForeignKey("FinishCityId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("RideShareRestApi.Entity.Models.City", "StartCity")
                        .WithMany()
                        .HasForeignKey("StartCityId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("RideShareRestApi.Entity.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("FinishCity");

                    b.Navigation("StartCity");

                    b.Navigation("User");
                });
#pragma warning restore 612, 618
        }
    }
}
