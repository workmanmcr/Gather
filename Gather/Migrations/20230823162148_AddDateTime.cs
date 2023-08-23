using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gather.Migrations
{
    public partial class AddDateTime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "Gatherings");

            migrationBuilder.RenameColumn(
                name: "Time",
                table: "Gatherings",
                newName: "DateTime");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DateTime",
                table: "Gatherings",
                newName: "Time");

            migrationBuilder.AddColumn<int>(
                name: "Date",
                table: "Gatherings",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
