﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SumeraTravelCorporation.Data;

#nullable disable

namespace SumeraTravelCorporation.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220705120714_final6")]
    partial class final6
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Sumera.Data.Models.MasterModels.HotelRooms", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("HotelRefId")
                        .HasColumnType("int");

                    b.Property<int>("PerDay")
                        .HasColumnType("int");

                    b.Property<int>("PerDayNight")
                        .HasColumnType("int");

                    b.Property<int>("PerNight")
                        .HasColumnType("int");

                    b.Property<int>("RoomRefId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("HotelRefId");

                    b.HasIndex("RoomRefId");

                    b.ToTable("hotel_room", "Master");
                });

            modelBuilder.Entity("Sumera.Data.Models.MasterModels.Room", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("room_desciption");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("room_name");

                    b.HasKey("Id");

                    b.ToTable("rooms", "MasterData");
                });

            modelBuilder.Entity("SumeraTravelCorporation.Data.MasterModels.TravelClass", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TravelClass", "MasterData");
                });

            modelBuilder.Entity("SumeraTravelCorporation.Data.Models.Airline", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Address1")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Address2")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Address3")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<int>("CityRefId")
                        .HasColumnType("int");

                    b.Property<string>("Email1")
                        .IsRequired()
                        .HasMaxLength(30)
                        .IsUnicode(false)
                        .HasColumnType("varchar(30)");

                    b.Property<string>("Email2")
                        .HasMaxLength(30)
                        .IsUnicode(false)
                        .HasColumnType("varchar(30)");

                    b.Property<string>("Logo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<int>("PinCode")
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("int");

                    b.Property<string>("ShortName")
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("varchar(10)");

                    b.Property<string>("Telephone1")
                        .IsRequired()
                        .HasMaxLength(15)
                        .IsUnicode(false)
                        .HasColumnType("varchar(15)");

                    b.Property<string>("Telephone2")
                        .HasMaxLength(15)
                        .IsUnicode(false)
                        .HasColumnType("varchar(15)");

                    b.HasKey("Id");

                    b.HasIndex("CityRefId");

                    b.ToTable("Airline", "Master");
                });

            modelBuilder.Entity("SumeraTravelCorporation.Data.Models.Airport", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Address1")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Address2")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Address3")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<int>("CityRefId")
                        .HasColumnType("int");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(5)
                        .IsUnicode(false)
                        .HasColumnType("varchar(5)");

                    b.Property<string>("Email1")
                        .IsRequired()
                        .HasMaxLength(30)
                        .IsUnicode(false)
                        .HasColumnType("varchar(30)");

                    b.Property<string>("Email2")
                        .HasMaxLength(30)
                        .IsUnicode(false)
                        .HasColumnType("varchar(30)");

                    b.Property<string>("PinCode")
                        .IsRequired()
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("varchar(10)");

                    b.Property<string>("Telephone1")
                        .IsRequired()
                        .HasMaxLength(15)
                        .IsUnicode(false)
                        .HasColumnType("varchar(15)");

                    b.Property<string>("Telephone2")
                        .HasMaxLength(15)
                        .IsUnicode(false)
                        .HasColumnType("varchar(15)");

                    b.HasKey("Id");

                    b.HasIndex("CityRefId");

                    b.ToTable("Airport", "Master");
                });

            modelBuilder.Entity("SumeraTravelCorporation.Data.Models.Amenities", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .HasMaxLength(200)
                        .IsUnicode(false)
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Amenities", "Master");
                });

            modelBuilder.Entity("SumeraTravelCorporation.Data.Models.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CountryRefId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("CountryRefId");

                    b.ToTable("City", "Master");
                });

            modelBuilder.Entity("SumeraTravelCorporation.Data.Models.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(5)
                        .IsUnicode(false)
                        .HasColumnType("varchar(5)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Country", "Master");
                });

            modelBuilder.Entity("SumeraTravelCorporation.Data.Models.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Address1")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Address2")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Address3")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("CityRefId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email1")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("LastName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("PinCode")
                        .HasMaxLength(5)
                        .HasColumnType("int");

                    b.Property<string>("Telephone1")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.HasKey("Id");

                    b.HasIndex("CityRefId");

                    b.ToTable("Customer", "Master");
                });

            modelBuilder.Entity("SumeraTravelCorporation.Data.Models.Flight", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Address1")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Address2")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Address3")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<int>("AirlineRefId")
                        .HasColumnType("int");

                    b.Property<int?>("CityRefId")
                        .HasColumnType("int");

                    b.Property<string>("Code")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)");

                    b.Property<string>("Email1")
                        .IsRequired()
                        .HasMaxLength(30)
                        .IsUnicode(false)
                        .HasColumnType("varchar(30)");

                    b.Property<string>("Email2")
                        .HasMaxLength(30)
                        .IsUnicode(false)
                        .HasColumnType("varchar(30)");

                    b.Property<int?>("FromAirportRefId")
                        .HasColumnType("int");

                    b.Property<int>("PinCode")
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("int");

                    b.Property<string>("Telephone1")
                        .IsRequired()
                        .HasMaxLength(15)
                        .IsUnicode(false)
                        .HasColumnType("varchar(15)");

                    b.Property<string>("Telephone2")
                        .HasMaxLength(15)
                        .IsUnicode(false)
                        .HasColumnType("varchar(15)");

                    b.Property<int?>("ToAirportRefId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AirlineRefId");

                    b.HasIndex("CityRefId");

                    b.HasIndex("FromAirportRefId");

                    b.HasIndex("ToAirportRefId");

                    b.ToTable("Flight", "Master");
                });

            modelBuilder.Entity("SumeraTravelCorporation.Data.Models.FlightAmenities", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .HasMaxLength(200)
                        .IsUnicode(false)
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("FlightAmenities", "Master");
                });

            modelBuilder.Entity("SumeraTravelCorporation.Data.Models.FlightAmenitiesLink", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("FlightAmenitiesRefId")
                        .HasColumnType("int");

                    b.Property<int>("FlightRefId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FlightAmenitiesRefId");

                    b.HasIndex("FlightRefId");

                    b.ToTable("FlightAmenitiesLink", "Master");
                });

            modelBuilder.Entity("SumeraTravelCorporation.Data.Models.Hotel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CityRefId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<int>("Star")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CityRefId");

                    b.ToTable("Hotel", "Master");
                });

            modelBuilder.Entity("SumeraTravelCorporation.Data.Models.HotelAmenitiesLink", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AmenitiesRefId")
                        .HasColumnType("int");

                    b.Property<int>("HotelRefId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AmenitiesRefId");

                    b.HasIndex("HotelRefId");

                    b.ToTable("HotelAmenitiesLink", "Master");
                });

            modelBuilder.Entity("SumeraTravelCorporation.Data.TranctionModels.FlightBooking", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime?>("BookingDate")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<string>("ContactEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("ContactNumber")
                        .HasColumnType("bigint");

                    b.Property<int>("CustRefId")
                        .HasColumnType("int");

                    b.Property<int>("FlightScheduleId")
                        .HasColumnType("int");

                    b.Property<int>("NumberOfPeople")
                        .HasColumnType("int");

                    b.Property<int>("NumberOfTicket")
                        .HasColumnType("int");

                    b.Property<int>("TotalAmount")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FlightScheduleId");

                    b.ToTable("flightbooking");
                });

            modelBuilder.Entity("SumeraTravelCorporation.Data.TranctionModels.FlightCustomerDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FlightBookingId")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserRefId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FlightBookingId");

                    b.HasIndex("UserRefId");

                    b.ToTable("flight_customer_details");
                });

            modelBuilder.Entity("SumeraTravelCorporation.Data.TranctionModels.FlightSchedule", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime?>("ArrivalDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DepartureDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("FlightRefId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("fligh_schedule");
                });

            modelBuilder.Entity("SumeraTravelCorporation.Data.TranctionModels.FlightTravel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("FlightRefId")
                        .HasColumnType("int");

                    b.Property<int>("Rent")
                        .HasColumnType("int");

                    b.Property<int>("TravelClassRefId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FlightRefId");

                    b.HasIndex("TravelClassRefId");

                    b.ToTable("flight_travel");
                });

            modelBuilder.Entity("SumeraTravelCorporation.Data.TranctionModels.HotelBooking", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("BookingDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("CustRefId")
                        .HasColumnType("int");

                    b.Property<DateTime>("FromDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("HotelId")
                        .HasColumnType("int");

                    b.Property<DateTime>("ToDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("TotalAmount")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("HotelId");

                    b.ToTable("hotel_booking");
                });

            modelBuilder.Entity("SumeraTravelCorporation.Data.TranctionModels.HotelCustomerDetails", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("first_name");

                    b.Property<int?>("HotelRefBookingId")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("last_name");

                    b.Property<int>("UserRefId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("HotelRefBookingId");

                    b.HasIndex("UserRefId");

                    b.ToTable("hotel_customer_detail");
                });

            modelBuilder.Entity("Sumera.Data.Models.MasterModels.HotelRooms", b =>
                {
                    b.HasOne("SumeraTravelCorporation.Data.Models.Hotel", "Hotel")
                        .WithMany()
                        .HasForeignKey("HotelRefId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Sumera.Data.Models.MasterModels.Room", "Room")
                        .WithMany()
                        .HasForeignKey("RoomRefId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hotel");

                    b.Navigation("Room");
                });

            modelBuilder.Entity("SumeraTravelCorporation.Data.Models.Airline", b =>
                {
                    b.HasOne("SumeraTravelCorporation.Data.Models.City", "CityRef")
                        .WithMany()
                        .HasForeignKey("CityRefId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CityRef");
                });

            modelBuilder.Entity("SumeraTravelCorporation.Data.Models.Airport", b =>
                {
                    b.HasOne("SumeraTravelCorporation.Data.Models.City", "CityRef")
                        .WithMany()
                        .HasForeignKey("CityRefId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CityRef");
                });

            modelBuilder.Entity("SumeraTravelCorporation.Data.Models.City", b =>
                {
                    b.HasOne("SumeraTravelCorporation.Data.Models.Country", "CountryRef")
                        .WithMany()
                        .HasForeignKey("CountryRefId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CountryRef");
                });

            modelBuilder.Entity("SumeraTravelCorporation.Data.Models.Customer", b =>
                {
                    b.HasOne("SumeraTravelCorporation.Data.Models.City", "CityRef")
                        .WithMany()
                        .HasForeignKey("CityRefId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CityRef");
                });

            modelBuilder.Entity("SumeraTravelCorporation.Data.Models.Flight", b =>
                {
                    b.HasOne("SumeraTravelCorporation.Data.Models.Airline", "Airline")
                        .WithMany()
                        .HasForeignKey("AirlineRefId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SumeraTravelCorporation.Data.Models.City", "CityRef")
                        .WithMany()
                        .HasForeignKey("CityRefId");

                    b.HasOne("SumeraTravelCorporation.Data.Models.Airport", "FromAirport")
                        .WithMany()
                        .HasForeignKey("FromAirportRefId");

                    b.HasOne("SumeraTravelCorporation.Data.Models.Airport", "ToAirport")
                        .WithMany()
                        .HasForeignKey("ToAirportRefId");

                    b.Navigation("Airline");

                    b.Navigation("CityRef");

                    b.Navigation("FromAirport");

                    b.Navigation("ToAirport");
                });

            modelBuilder.Entity("SumeraTravelCorporation.Data.Models.FlightAmenitiesLink", b =>
                {
                    b.HasOne("SumeraTravelCorporation.Data.Models.FlightAmenities", "FlightAmenities")
                        .WithMany()
                        .HasForeignKey("FlightAmenitiesRefId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SumeraTravelCorporation.Data.Models.Flight", "FlightRef")
                        .WithMany()
                        .HasForeignKey("FlightRefId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FlightAmenities");

                    b.Navigation("FlightRef");
                });

            modelBuilder.Entity("SumeraTravelCorporation.Data.Models.Hotel", b =>
                {
                    b.HasOne("SumeraTravelCorporation.Data.Models.City", "CityRef")
                        .WithMany()
                        .HasForeignKey("CityRefId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CityRef");
                });

            modelBuilder.Entity("SumeraTravelCorporation.Data.Models.HotelAmenitiesLink", b =>
                {
                    b.HasOne("SumeraTravelCorporation.Data.Models.Amenities", "AmenitiesRef")
                        .WithMany()
                        .HasForeignKey("AmenitiesRefId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SumeraTravelCorporation.Data.Models.Hotel", "HotelRef")
                        .WithMany()
                        .HasForeignKey("HotelRefId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AmenitiesRef");

                    b.Navigation("HotelRef");
                });

            modelBuilder.Entity("SumeraTravelCorporation.Data.TranctionModels.FlightBooking", b =>
                {
                    b.HasOne("SumeraTravelCorporation.Data.TranctionModels.FlightSchedule", "FlightShcedule")
                        .WithMany()
                        .HasForeignKey("FlightScheduleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FlightShcedule");
                });

            modelBuilder.Entity("SumeraTravelCorporation.Data.TranctionModels.FlightCustomerDetail", b =>
                {
                    b.HasOne("SumeraTravelCorporation.Data.TranctionModels.FlightBooking", "FlightBooking")
                        .WithMany("FlightCustomerDetails")
                        .HasForeignKey("FlightBookingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SumeraTravelCorporation.Data.Models.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("UserRefId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("FlightBooking");
                });

            modelBuilder.Entity("SumeraTravelCorporation.Data.TranctionModels.FlightTravel", b =>
                {
                    b.HasOne("SumeraTravelCorporation.Data.Models.Flight", "Flight")
                        .WithMany()
                        .HasForeignKey("FlightRefId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SumeraTravelCorporation.Data.MasterModels.TravelClass", "TravelClass")
                        .WithMany()
                        .HasForeignKey("TravelClassRefId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Flight");

                    b.Navigation("TravelClass");
                });

            modelBuilder.Entity("SumeraTravelCorporation.Data.TranctionModels.HotelBooking", b =>
                {
                    b.HasOne("SumeraTravelCorporation.Data.Models.Hotel", "hotelRef")
                        .WithMany()
                        .HasForeignKey("HotelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("hotelRef");
                });

            modelBuilder.Entity("SumeraTravelCorporation.Data.TranctionModels.HotelCustomerDetails", b =>
                {
                    b.HasOne("SumeraTravelCorporation.Data.TranctionModels.HotelBooking", "HotelBooking")
                        .WithMany("HotelCustomerDetails")
                        .HasForeignKey("HotelRefBookingId");

                    b.HasOne("SumeraTravelCorporation.Data.Models.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("UserRefId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("HotelBooking");
                });

            modelBuilder.Entity("SumeraTravelCorporation.Data.TranctionModels.FlightBooking", b =>
                {
                    b.Navigation("FlightCustomerDetails");
                });

            modelBuilder.Entity("SumeraTravelCorporation.Data.TranctionModels.HotelBooking", b =>
                {
                    b.Navigation("HotelCustomerDetails");
                });
#pragma warning restore 612, 618
        }
    }
}
