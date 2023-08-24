using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gather.Migrations
{
    public partial class AddstringUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GatheringUsers_AspNetUsers_UserId",
                table: "GatheringUsers");

            migrationBuilder.DropIndex(
                name: "IX_GatheringUsers_UserId",
                table: "GatheringUsers");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "GatheringUsers");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "GatheringUsers",
                type: "varchar(255)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_GatheringUsers_ApplicationUserId",
                table: "GatheringUsers",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_GatheringUsers_AspNetUsers_ApplicationUserId",
                table: "GatheringUsers",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GatheringUsers_AspNetUsers_ApplicationUserId",
                table: "GatheringUsers");

            migrationBuilder.DropIndex(
                name: "IX_GatheringUsers_ApplicationUserId",
                table: "GatheringUsers");

            migrationBuilder.AlterColumn<int>(
                name: "ApplicationUserId",
                table: "GatheringUsers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldNullable: true)
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "GatheringUsers",
                type: "varchar(255)",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_GatheringUsers_UserId",
                table: "GatheringUsers",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_GatheringUsers_AspNetUsers_UserId",
                table: "GatheringUsers",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
