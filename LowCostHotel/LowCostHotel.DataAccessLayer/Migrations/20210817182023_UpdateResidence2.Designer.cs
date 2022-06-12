﻿// <auto-generated />
using System;
using LowCostHotel.DataAccessLayer.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LowCostHotel.DataAccessLayer.Migrations
{
    [DbContext(typeof(LowCostHotelContext))]
    [Migration("20210817182023_UpdateResidence2")]
    partial class UpdateResidence2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("LowCostHotel.DataAccessLayer.Models.HotelRoom", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("NumberOfRooms")
                        .HasColumnType("int");

                    b.Property<double>("PricePerDay")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("HotelRooms");
                });

            modelBuilder.Entity("LowCostHotel.DataAccessLayer.Models.Residence", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("End")
                        .HasColumnType("datetime2");

                    b.Property<int>("HotelRoomId")
                        .HasColumnType("int");

                    b.Property<bool>("Paided")
                        .HasColumnType("bit");

                    b.Property<int>("ResourceId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Start")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("HotelRoomId");

                    b.HasIndex("ResourceId");

                    b.HasIndex("UserId");

                    b.ToTable("Residences");
                });

            modelBuilder.Entity("LowCostHotel.DataAccessLayer.Models.Resource", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<double>("PricePerHour")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Resources");
                });

            modelBuilder.Entity("LowCostHotel.DataAccessLayer.Models.Statistic", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("End")
                        .HasColumnType("datetime2");

                    b.Property<string>("HostelRoom")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<double>("PricePerDay")
                        .HasColumnType("float");

                    b.Property<double>("Profit")
                        .HasColumnType("float");

                    b.Property<string>("ResourceName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("ResourcePricePerHour")
                        .HasColumnType("float");

                    b.Property<DateTime>("Start")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Statistics");
                });

            modelBuilder.Entity("LowCostHotel.DataAccessLayer.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("HashedPassword")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("LowCostHotel.DataAccessLayer.Models.Residence", b =>
                {
                    b.HasOne("LowCostHotel.DataAccessLayer.Models.HotelRoom", "HotelRoom")
                        .WithMany("Residences")
                        .HasForeignKey("HotelRoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LowCostHotel.DataAccessLayer.Models.Resource", "Resource")
                        .WithMany("Residences")
                        .HasForeignKey("ResourceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LowCostHotel.DataAccessLayer.Models.User", "User")
                        .WithMany("Residences")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("HotelRoom");

                    b.Navigation("Resource");

                    b.Navigation("User");
                });

            modelBuilder.Entity("LowCostHotel.DataAccessLayer.Models.HotelRoom", b =>
                {
                    b.Navigation("Residences");
                });

            modelBuilder.Entity("LowCostHotel.DataAccessLayer.Models.Resource", b =>
                {
                    b.Navigation("Residences");
                });

            modelBuilder.Entity("LowCostHotel.DataAccessLayer.Models.User", b =>
                {
                    b.Navigation("Residences");
                });
#pragma warning restore 612, 618
        }
    }
}
