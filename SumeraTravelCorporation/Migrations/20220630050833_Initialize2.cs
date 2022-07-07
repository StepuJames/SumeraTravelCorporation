using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SumeraTravelCorporation.Migrations
{
    public partial class Initialize2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CountryDto");

            migrationBuilder.RenameTable(
                name: "hotel_customer_detail",
                schema: "MasterData",
                newName: "hotel_customer_detail");

            migrationBuilder.RenameTable(
                name: "hotel_booking",
                schema: "MasterData",
                newName: "hotel_booking");

            migrationBuilder.RenameTable(
                name: "flightbooking",
                schema: "MasterData",
                newName: "flightbooking");

            migrationBuilder.RenameTable(
                name: "flight_travel",
                schema: "MasterData",
                newName: "flight_travel");

            migrationBuilder.RenameTable(
                name: "flight_customer_details",
                schema: "MasterData",
                newName: "flight_customer_details");

            migrationBuilder.RenameTable(
                name: "fligh_schedule",
                schema: "MasterData",
                newName: "fligh_schedule");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "hotel_customer_detail",
                newName: "hotel_customer_detail",
                newSchema: "MasterData");

            migrationBuilder.RenameTable(
                name: "hotel_booking",
                newName: "hotel_booking",
                newSchema: "MasterData");

            migrationBuilder.RenameTable(
                name: "flightbooking",
                newName: "flightbooking",
                newSchema: "MasterData");

            migrationBuilder.RenameTable(
                name: "flight_travel",
                newName: "flight_travel",
                newSchema: "MasterData");

            migrationBuilder.RenameTable(
                name: "flight_customer_details",
                newName: "flight_customer_details",
                newSchema: "MasterData");

            migrationBuilder.RenameTable(
                name: "fligh_schedule",
                newName: "fligh_schedule",
                newSchema: "MasterData");

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
        }
    }
}
