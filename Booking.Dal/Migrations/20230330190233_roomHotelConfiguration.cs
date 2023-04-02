using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Booking.Dal.Migrations
{
    /// <inheritdoc />
    public partial class roomHotelConfiguration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_hotels_hotelID",
                table: "Rooms");

            migrationBuilder.RenameColumn(
                name: "hotelID",
                table: "Rooms",
                newName: "HotelId");

            migrationBuilder.RenameIndex(
                name: "IX_Rooms_hotelID",
                table: "Rooms",
                newName: "IX_Rooms_HotelId");

            migrationBuilder.AlterColumn<int>(
                name: "HotelId",
                table: "Rooms",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_hotels_HotelId",
                table: "Rooms",
                column: "HotelId",
                principalTable: "hotels",
                principalColumn: "hotelID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_hotels_HotelId",
                table: "Rooms");

            migrationBuilder.RenameColumn(
                name: "HotelId",
                table: "Rooms",
                newName: "hotelID");

            migrationBuilder.RenameIndex(
                name: "IX_Rooms_HotelId",
                table: "Rooms",
                newName: "IX_Rooms_hotelID");

            migrationBuilder.AlterColumn<int>(
                name: "hotelID",
                table: "Rooms",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_hotels_hotelID",
                table: "Rooms",
                column: "hotelID",
                principalTable: "hotels",
                principalColumn: "hotelID");
        }
    }
}
