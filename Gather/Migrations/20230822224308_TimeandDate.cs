using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gather.Migrations
{
    public partial class TimeandDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "VendorItemsId",
                table: "VendorItems",
                newName: "VendorItemId");

            migrationBuilder.RenameColumn(
                name: "TimeDate",
                table: "Gatherings",
                newName: "Time");

            migrationBuilder.AddColumn<int>(
                name: "Date",
                table: "Gatherings",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "Gatherings");

            migrationBuilder.RenameColumn(
                name: "VendorItemId",
                table: "VendorItems",
                newName: "VendorItemsId");

            migrationBuilder.RenameColumn(
                name: "Time",
                table: "Gatherings",
                newName: "TimeDate");
        }
    }
}
