using Microsoft.EntityFrameworkCore.Migrations;

namespace LowCostHotel.DataAccessLayer.Migrations
{
    public partial class UpdateResidence : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "HostelRoomlId",
                table: "Residences",
                newName: "HotelRoomlId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "HotelRoomlId",
                table: "Residences",
                newName: "HostelRoomlId");
        }
    }
}
