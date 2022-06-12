using Microsoft.EntityFrameworkCore.Migrations;

namespace LowCostHotel.DataAccessLayer.Migrations
{
    public partial class UpdateResidence1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Residences_HotelRooms_HostelRoomId",
                table: "Residences");

            migrationBuilder.RenameColumn(
                name: "HostelRoomId",
                table: "Residences",
                newName: "HotelRoomId");

            migrationBuilder.RenameIndex(
                name: "IX_Residences_HostelRoomId",
                table: "Residences",
                newName: "IX_Residences_HotelRoomId");

            migrationBuilder.AddForeignKey(
                name: "FK_Residences_HotelRooms_HotelRoomId",
                table: "Residences",
                column: "HotelRoomId",
                principalTable: "HotelRooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Residences_HotelRooms_HotelRoomId",
                table: "Residences");

            migrationBuilder.RenameColumn(
                name: "HotelRoomId",
                table: "Residences",
                newName: "HostelRoomId");

            migrationBuilder.RenameIndex(
                name: "IX_Residences_HotelRoomId",
                table: "Residences",
                newName: "IX_Residences_HostelRoomId");

            migrationBuilder.AddForeignKey(
                name: "FK_Residences_HotelRooms_HostelRoomId",
                table: "Residences",
                column: "HostelRoomId",
                principalTable: "HotelRooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
