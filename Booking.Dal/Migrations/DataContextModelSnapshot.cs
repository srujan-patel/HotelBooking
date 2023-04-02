﻿// <auto-generated />
using System;
using Booking.Dal;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Booking.Dal.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Booking.Domain.Models.Hotel", b =>
                {
                    b.Property<int>("hotelID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("hotelID"));

                    b.Property<string>("address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("city")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("hotelName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("starRating")
                        .HasColumnType("int");

                    b.HasKey("hotelID");

                    b.ToTable("hotels");
                });

            modelBuilder.Entity("Booking.Domain.Models.Reservation", b =>
                {
                    b.Property<int>("reservationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("reservationId"));

                    b.Property<string>("customerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("endDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("roomID")
                        .HasColumnType("int");

                    b.Property<DateTime>("startDate")
                        .HasColumnType("datetime2");

                    b.HasKey("reservationId");

                    b.HasIndex("roomID");

                    b.ToTable("Reservations");
                });

            modelBuilder.Entity("Booking.Domain.Models.Room", b =>
                {
                    b.Property<int>("roomID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("roomID"));

                    b.Property<int>("HotelId")
                        .HasColumnType("int");

                    b.Property<bool>("needsRepair")
                        .HasColumnType("bit");

                    b.Property<int>("roomNumber")
                        .HasColumnType("int");

                    b.Property<double>("surface")
                        .HasColumnType("float");

                    b.HasKey("roomID");

                    b.HasIndex("HotelId");

                    b.ToTable("Rooms");
                });

            modelBuilder.Entity("Booking.Domain.Models.Reservation", b =>
                {
                    b.HasOne("Booking.Domain.Models.Room", "room")
                        .WithMany()
                        .HasForeignKey("roomID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("room");
                });

            modelBuilder.Entity("Booking.Domain.Models.Room", b =>
                {
                    b.HasOne("Booking.Domain.Models.Hotel", "Hotel")
                        .WithMany("roomList")
                        .HasForeignKey("HotelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hotel");
                });

            modelBuilder.Entity("Booking.Domain.Models.Hotel", b =>
                {
                    b.Navigation("roomList");
                });
#pragma warning restore 612, 618
        }
    }
}
