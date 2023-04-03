using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Booking.Dal.Migrations
{
    /// <inheritdoc />
    public partial class Cleanup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "hotels",
                columns: table => new
                {
                    hotelID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    hotelName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    starRating = table.Column<int>(type: "int", nullable: false),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    city = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hotels", x => x.hotelID);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    roomID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    roomNumber = table.Column<int>(type: "int", nullable: false),
                    surface = table.Column<double>(type: "float", nullable: false),
                    needsRepair = table.Column<bool>(type: "bit", nullable: false),
                    hotelId = table.Column<int>(type: "int", nullable: true),
                    BusyFrom = table.Column<DateTime>(type: "datetime2", nullable: true),
                    BusyTo = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.roomID);
                    table.ForeignKey(
                        name: "FK_Rooms_hotels_hotelId",
                        column: x => x.hotelId,
                        principalTable: "hotels",
                        principalColumn: "hotelID",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    reservationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    roomId = table.Column<int>(type: "int", nullable: true),
                    hotelId = table.Column<int>(type: "int", nullable: true),
                    checkinDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    checkoutDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    customerName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.reservationId);
                    table.ForeignKey(
                        name: "FK_Reservations_Rooms_roomId",
                        column: x => x.roomId,
                        principalTable: "Rooms",
                        principalColumn: "roomID",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Reservations_hotels_hotelId",
                        column: x => x.hotelId,
                        principalTable: "hotels",
                        principalColumn: "hotelID",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_hotelId",
                table: "Reservations",
                column: "hotelId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_roomId",
                table: "Reservations",
                column: "roomId");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_hotelId",
                table: "Rooms",
                column: "hotelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "hotels");
        }
    }
}
