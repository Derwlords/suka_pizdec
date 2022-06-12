using Microsoft.EntityFrameworkCore.Migrations;

namespace LowCostHotel.DataAccessLayer.Migrations
{
    public partial class UpdateResidence2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Residences_HotelRooms_HotelRoomId",
                table: "Residences");

            migrationBuilder.DropColumn(
                name: "HotelRoomlId",
                table: "Residences");

            migrationBuilder.AlterColumn<int>(
                name: "HotelRoomId",
                table: "Residences",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Residences_HotelRooms_HotelRoomId",
                table: "Residences",
                column: "HotelRoomId",
                principalTable: "HotelRooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Residences_HotelRooms_HotelRoomId",
                table: "Residences");

            migrationBuilder.AlterColumn<int>(
                name: "HotelRoomId",
                table: "Residences",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "HotelRoomlId",
                table: "Residences",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Residences_HotelRooms_HotelRoomId",
                table: "Residences",
                column: "HotelRoomId",
                principalTable: "HotelRooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
