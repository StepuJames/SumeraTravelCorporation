using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SumeraTravelCorporation.Migrations
{
    public partial class Final : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_hotel_room_Hotel_hotel_ref_id",
                schema: "MasterData",
                table: "hotel_room");

            migrationBuilder.RenameTable(
                name: "hotel_room",
                schema: "MasterData",
                newName: "hotel_room",
                newSchema: "Master");

            migrationBuilder.RenameColumn(
                name: "room_ref_id",
                schema: "Master",
                table: "hotel_room",
                newName: "RoomRefId");

            migrationBuilder.RenameColumn(
                name: "rent_per_night",
                schema: "Master",
                table: "hotel_room",
                newName: "PerNight");

            migrationBuilder.RenameColumn(
                name: "rent_per_day",
                schema: "Master",
                table: "hotel_room",
                newName: "PerDay");

            migrationBuilder.RenameColumn(
                name: "rent_day_night",
                schema: "Master",
                table: "hotel_room",
                newName: "PerDayNight");

            migrationBuilder.RenameColumn(
                name: "hotel_ref_id",
                schema: "Master",
                table: "hotel_room",
                newName: "HotelRefId");

            migrationBuilder.RenameIndex(
                name: "IX_hotel_room_hotel_ref_id",
                schema: "Master",
                table: "hotel_room",
                newName: "IX_hotel_room_HotelRefId");

            migrationBuilder.CreateTable(
                name: "HotelRoomDto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HotelRefId = table.Column<int>(type: "int", nullable: false),
                    RoomRefId = table.Column<int>(type: "int", nullable: false),
                    PerNight = table.Column<int>(type: "int", nullable: false),
                    PerDay = table.Column<int>(type: "int", nullable: false),
                    PerDayNight = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotelRoomDto", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_hotel_room_RoomRefId",
                schema: "Master",
                table: "hotel_room",
                column: "RoomRefId");

            migrationBuilder.AddForeignKey(
                name: "FK_hotel_room_Hotel_HotelRefId",
                schema: "Master",
                table: "hotel_room",
                column: "HotelRefId",
                principalSchema: "Master",
                principalTable: "Hotel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_hotel_room_rooms_RoomRefId",
                schema: "Master",
                table: "hotel_room",
                column: "RoomRefId",
                principalSchema: "MasterData",
                principalTable: "rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_hotel_room_Hotel_HotelRefId",
                schema: "Master",
                table: "hotel_room");

            migrationBuilder.DropForeignKey(
                name: "FK_hotel_room_rooms_RoomRefId",
                schema: "Master",
                table: "hotel_room");

            migrationBuilder.DropTable(
                name: "HotelRoomDto");

            migrationBuilder.DropIndex(
                name: "IX_hotel_room_RoomRefId",
                schema: "Master",
                table: "hotel_room");

            migrationBuilder.RenameTable(
                name: "hotel_room",
                schema: "Master",
                newName: "hotel_room",
                newSchema: "MasterData");

            migrationBuilder.RenameColumn(
                name: "RoomRefId",
                schema: "MasterData",
                table: "hotel_room",
                newName: "room_ref_id");

            migrationBuilder.RenameColumn(
                name: "PerNight",
                schema: "MasterData",
                table: "hotel_room",
                newName: "rent_per_night");

            migrationBuilder.RenameColumn(
                name: "PerDayNight",
                schema: "MasterData",
                table: "hotel_room",
                newName: "rent_day_night");

            migrationBuilder.RenameColumn(
                name: "PerDay",
                schema: "MasterData",
                table: "hotel_room",
                newName: "rent_per_day");

            migrationBuilder.RenameColumn(
                name: "HotelRefId",
                schema: "MasterData",
                table: "hotel_room",
                newName: "hotel_ref_id");

            migrationBuilder.RenameIndex(
                name: "IX_hotel_room_HotelRefId",
                schema: "MasterData",
                table: "hotel_room",
                newName: "IX_hotel_room_hotel_ref_id");

            migrationBuilder.AddForeignKey(
                name: "FK_hotel_room_Hotel_hotel_ref_id",
                schema: "MasterData",
                table: "hotel_room",
                column: "hotel_ref_id",
                principalSchema: "Master",
                principalTable: "Hotel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
