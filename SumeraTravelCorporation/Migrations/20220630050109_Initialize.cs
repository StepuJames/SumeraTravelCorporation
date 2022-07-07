using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SumeraTravelCorporation.Migrations
{
    public partial class Initialize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Master");

            migrationBuilder.EnsureSchema(
                name: "MasterData");

            migrationBuilder.CreateTable(
                name: "Amenities",
                schema: "Master",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Amenities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Country",
                schema: "Master",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "varchar(5)", unicode: false, maxLength: 5, nullable: false),
                    Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CountryDto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountryDto", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "fligh_schedule",
                schema: "MasterData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FlightRefId = table.Column<int>(type: "int", nullable: false),
                    DepartureDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ArrivalDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_fligh_schedule", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FlightAmenities",
                schema: "Master",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlightAmenities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "rooms",
                schema: "MasterData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    room_name = table.Column<string>(type: "varchar", nullable: false),
                    room_desciption = table.Column<string>(type: "varchar", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rooms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TravelClass",
                schema: "MasterData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TravelClass", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "City",
                schema: "Master",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    CountryRefId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.Id);
                    table.ForeignKey(
                        name: "FK_City_Country_CountryRefId",
                        column: x => x.CountryRefId,
                        principalSchema: "Master",
                        principalTable: "Country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "flightbooking",
                schema: "MasterData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustRefId = table.Column<int>(type: "int", nullable: false),
                    BookingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FlightScheduleId = table.Column<int>(type: "int", nullable: false),
                    ContactNumber = table.Column<long>(type: "bigint", nullable: false),
                    ContactEmail = table.Column<long>(type: "bigint", nullable: false),
                    NumberOfPeople = table.Column<int>(type: "int", nullable: false),
                    NumberOfTicket = table.Column<int>(type: "int", nullable: false),
                    TotalAmount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_flightbooking", x => x.Id);
                    table.ForeignKey(
                        name: "FK_flightbooking_fligh_schedule_FlightScheduleId",
                        column: x => x.FlightScheduleId,
                        principalSchema: "MasterData",
                        principalTable: "fligh_schedule",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Airline",
                schema: "Master",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    ShortName = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    Logo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address1 = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Address2 = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Address3 = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    CityRefId = table.Column<int>(type: "int", nullable: false),
                    PinCode = table.Column<int>(type: "int", unicode: false, maxLength: 10, nullable: false),
                    Telephone1 = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: false),
                    Telephone2 = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true),
                    Email1 = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    Email2 = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Airline", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Airline_City_CityRefId",
                        column: x => x.CityRefId,
                        principalSchema: "Master",
                        principalTable: "City",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Airport",
                schema: "Master",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "varchar(5)", unicode: false, maxLength: 5, nullable: false),
                    CityRefId = table.Column<int>(type: "int", nullable: false),
                    Address1 = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Address2 = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Address3 = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    PinCode = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    Telephone1 = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: false),
                    Telephone2 = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true),
                    Email1 = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    Email2 = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Airport", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Airport_City_CityRefId",
                        column: x => x.CityRefId,
                        principalSchema: "Master",
                        principalTable: "City",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                schema: "Master",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Address1 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Address2 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Address3 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CityRefId = table.Column<int>(type: "int", nullable: false),
                    PinCode = table.Column<int>(type: "int", maxLength: 5, nullable: false),
                    Telephone1 = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Email1 = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customer_City_CityRefId",
                        column: x => x.CityRefId,
                        principalSchema: "Master",
                        principalTable: "City",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Hotel",
                schema: "Master",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Star = table.Column<int>(type: "int", nullable: false),
                    CityRefId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hotel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Hotel_City_CityRefId",
                        column: x => x.CityRefId,
                        principalSchema: "Master",
                        principalTable: "City",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Flight",
                schema: "Master",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    AirlineRefId = table.Column<int>(type: "int", nullable: false),
                    FromAirportRefId = table.Column<int>(type: "int", nullable: true),
                    ToAirportRefId = table.Column<int>(type: "int", nullable: true),
                    Address1 = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Address2 = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Address3 = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    CityRefId = table.Column<int>(type: "int", nullable: true),
                    PinCode = table.Column<int>(type: "int", unicode: false, maxLength: 10, nullable: false),
                    Telephone1 = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: false),
                    Telephone2 = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true),
                    Email1 = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    Email2 = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flight", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Flight_Airline_AirlineRefId",
                        column: x => x.AirlineRefId,
                        principalSchema: "Master",
                        principalTable: "Airline",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Flight_Airport_FromAirportRefId",
                        column: x => x.FromAirportRefId,
                        principalSchema: "Master",
                        principalTable: "Airport",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Flight_Airport_ToAirportRefId",
                        column: x => x.ToAirportRefId,
                        principalSchema: "Master",
                        principalTable: "Airport",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Flight_City_CityRefId",
                        column: x => x.CityRefId,
                        principalSchema: "Master",
                        principalTable: "City",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "flight_customer_details",
                schema: "MasterData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    FlightBookingId = table.Column<int>(type: "int", nullable: false),
                    UserRefId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_flight_customer_details", x => x.Id);
                    table.ForeignKey(
                        name: "FK_flight_customer_details_Customer_UserRefId",
                        column: x => x.UserRefId,
                        principalSchema: "Master",
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_flight_customer_details_flightbooking_FlightBookingId",
                        column: x => x.FlightBookingId,
                        principalSchema: "MasterData",
                        principalTable: "flightbooking",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "hotel_booking",
                schema: "MasterData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustRefId = table.Column<int>(type: "int", nullable: false),
                    BookingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HotelId = table.Column<int>(type: "int", nullable: false),
                    FromDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ToDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalAmount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hotel_booking", x => x.Id);
                    table.ForeignKey(
                        name: "FK_hotel_booking_Hotel_HotelId",
                        column: x => x.HotelId,
                        principalSchema: "Master",
                        principalTable: "Hotel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "hotel_room",
                schema: "MasterData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    hotel_ref_id = table.Column<int>(type: "int", nullable: false),
                    room_ref_id = table.Column<int>(type: "int", nullable: false),
                    rent_per_night = table.Column<int>(type: "int", nullable: false),
                    rent_per_day = table.Column<int>(type: "int", nullable: false),
                    rent_day_night = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hotel_room", x => x.Id);
                    table.ForeignKey(
                        name: "FK_hotel_room_Hotel_hotel_ref_id",
                        column: x => x.hotel_ref_id,
                        principalSchema: "Master",
                        principalTable: "Hotel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HotelAmenitiesLink",
                schema: "Master",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HotelRefId = table.Column<int>(type: "int", nullable: false),
                    AmenitiesRefId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotelAmenitiesLink", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HotelAmenitiesLink_Amenities_AmenitiesRefId",
                        column: x => x.AmenitiesRefId,
                        principalSchema: "Master",
                        principalTable: "Amenities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HotelAmenitiesLink_Hotel_HotelRefId",
                        column: x => x.HotelRefId,
                        principalSchema: "Master",
                        principalTable: "Hotel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "flight_travel",
                schema: "MasterData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FlightRefId = table.Column<int>(type: "int", nullable: false),
                    TravelClassRefId = table.Column<int>(type: "int", nullable: false),
                    Rent = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_flight_travel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_flight_travel_Flight_FlightRefId",
                        column: x => x.FlightRefId,
                        principalSchema: "Master",
                        principalTable: "Flight",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_flight_travel_TravelClass_TravelClassRefId",
                        column: x => x.TravelClassRefId,
                        principalSchema: "MasterData",
                        principalTable: "TravelClass",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FlightAmenitiesLink",
                schema: "Master",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FlightRefId = table.Column<int>(type: "int", nullable: false),
                    FlightAmenitiesRefId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlightAmenitiesLink", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FlightAmenitiesLink_Flight_FlightRefId",
                        column: x => x.FlightRefId,
                        principalSchema: "Master",
                        principalTable: "Flight",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FlightAmenitiesLink_FlightAmenities_FlightAmenitiesRefId",
                        column: x => x.FlightAmenitiesRefId,
                        principalSchema: "Master",
                        principalTable: "FlightAmenities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "hotel_customer_detail",
                schema: "MasterData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    first_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    last_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    HotelRefBookingId = table.Column<int>(type: "int", nullable: true),
                    UserRefId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hotel_customer_detail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_hotel_customer_detail_Customer_UserRefId",
                        column: x => x.UserRefId,
                        principalSchema: "Master",
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_hotel_customer_detail_hotel_booking_HotelRefBookingId",
                        column: x => x.HotelRefBookingId,
                        principalSchema: "MasterData",
                        principalTable: "hotel_booking",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Airline_CityRefId",
                schema: "Master",
                table: "Airline",
                column: "CityRefId");

            migrationBuilder.CreateIndex(
                name: "IX_Airport_CityRefId",
                schema: "Master",
                table: "Airport",
                column: "CityRefId");

            migrationBuilder.CreateIndex(
                name: "IX_City_CountryRefId",
                schema: "Master",
                table: "City",
                column: "CountryRefId");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_CityRefId",
                schema: "Master",
                table: "Customer",
                column: "CityRefId");

            migrationBuilder.CreateIndex(
                name: "IX_Flight_AirlineRefId",
                schema: "Master",
                table: "Flight",
                column: "AirlineRefId");

            migrationBuilder.CreateIndex(
                name: "IX_Flight_CityRefId",
                schema: "Master",
                table: "Flight",
                column: "CityRefId");

            migrationBuilder.CreateIndex(
                name: "IX_Flight_FromAirportRefId",
                schema: "Master",
                table: "Flight",
                column: "FromAirportRefId");

            migrationBuilder.CreateIndex(
                name: "IX_Flight_ToAirportRefId",
                schema: "Master",
                table: "Flight",
                column: "ToAirportRefId");

            migrationBuilder.CreateIndex(
                name: "IX_flight_customer_details_FlightBookingId",
                schema: "MasterData",
                table: "flight_customer_details",
                column: "FlightBookingId");

            migrationBuilder.CreateIndex(
                name: "IX_flight_customer_details_UserRefId",
                schema: "MasterData",
                table: "flight_customer_details",
                column: "UserRefId");

            migrationBuilder.CreateIndex(
                name: "IX_flight_travel_FlightRefId",
                schema: "MasterData",
                table: "flight_travel",
                column: "FlightRefId");

            migrationBuilder.CreateIndex(
                name: "IX_flight_travel_TravelClassRefId",
                schema: "MasterData",
                table: "flight_travel",
                column: "TravelClassRefId");

            migrationBuilder.CreateIndex(
                name: "IX_FlightAmenitiesLink_FlightAmenitiesRefId",
                schema: "Master",
                table: "FlightAmenitiesLink",
                column: "FlightAmenitiesRefId");

            migrationBuilder.CreateIndex(
                name: "IX_FlightAmenitiesLink_FlightRefId",
                schema: "Master",
                table: "FlightAmenitiesLink",
                column: "FlightRefId");

            migrationBuilder.CreateIndex(
                name: "IX_flightbooking_FlightScheduleId",
                schema: "MasterData",
                table: "flightbooking",
                column: "FlightScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_Hotel_CityRefId",
                schema: "Master",
                table: "Hotel",
                column: "CityRefId");

            migrationBuilder.CreateIndex(
                name: "IX_hotel_booking_HotelId",
                schema: "MasterData",
                table: "hotel_booking",
                column: "HotelId");

            migrationBuilder.CreateIndex(
                name: "IX_hotel_customer_detail_HotelRefBookingId",
                schema: "MasterData",
                table: "hotel_customer_detail",
                column: "HotelRefBookingId");

            migrationBuilder.CreateIndex(
                name: "IX_hotel_customer_detail_UserRefId",
                schema: "MasterData",
                table: "hotel_customer_detail",
                column: "UserRefId");

            migrationBuilder.CreateIndex(
                name: "IX_hotel_room_hotel_ref_id",
                schema: "MasterData",
                table: "hotel_room",
                column: "hotel_ref_id");

            migrationBuilder.CreateIndex(
                name: "IX_HotelAmenitiesLink_AmenitiesRefId",
                schema: "Master",
                table: "HotelAmenitiesLink",
                column: "AmenitiesRefId");

            migrationBuilder.CreateIndex(
                name: "IX_HotelAmenitiesLink_HotelRefId",
                schema: "Master",
                table: "HotelAmenitiesLink",
                column: "HotelRefId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CountryDto");

            migrationBuilder.DropTable(
                name: "flight_customer_details",
                schema: "MasterData");

            migrationBuilder.DropTable(
                name: "flight_travel",
                schema: "MasterData");

            migrationBuilder.DropTable(
                name: "FlightAmenitiesLink",
                schema: "Master");

            migrationBuilder.DropTable(
                name: "hotel_customer_detail",
                schema: "MasterData");

            migrationBuilder.DropTable(
                name: "hotel_room",
                schema: "MasterData");

            migrationBuilder.DropTable(
                name: "HotelAmenitiesLink",
                schema: "Master");

            migrationBuilder.DropTable(
                name: "rooms",
                schema: "MasterData");

            migrationBuilder.DropTable(
                name: "flightbooking",
                schema: "MasterData");

            migrationBuilder.DropTable(
                name: "TravelClass",
                schema: "MasterData");

            migrationBuilder.DropTable(
                name: "Flight",
                schema: "Master");

            migrationBuilder.DropTable(
                name: "FlightAmenities",
                schema: "Master");

            migrationBuilder.DropTable(
                name: "Customer",
                schema: "Master");

            migrationBuilder.DropTable(
                name: "hotel_booking",
                schema: "MasterData");

            migrationBuilder.DropTable(
                name: "Amenities",
                schema: "Master");

            migrationBuilder.DropTable(
                name: "fligh_schedule",
                schema: "MasterData");

            migrationBuilder.DropTable(
                name: "Airline",
                schema: "Master");

            migrationBuilder.DropTable(
                name: "Airport",
                schema: "Master");

            migrationBuilder.DropTable(
                name: "Hotel",
                schema: "Master");

            migrationBuilder.DropTable(
                name: "City",
                schema: "Master");

            migrationBuilder.DropTable(
                name: "Country",
                schema: "Master");
        }
    }
}
