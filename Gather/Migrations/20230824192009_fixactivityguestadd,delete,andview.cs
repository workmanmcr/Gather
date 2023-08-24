using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gather.Migrations
{
    public partial class fixactivityguestadddeleteandview : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserActivities_AspNetUsers_UserId",
                table: "UserActivities");

            migrationBuilder.DropIndex(
                name: "IX_UserActivities_UserId",
                table: "UserActivities");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "UserActivities");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "UserActivities",
                type: "varchar(255)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_UserActivities_ApplicationUserId",
                table: "UserActivities",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserActivities_AspNetUsers_ApplicationUserId",
                table: "UserActivities",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserActivities_AspNetUsers_ApplicationUserId",
                table: "UserActivities");

            migrationBuilder.DropIndex(
                name: "IX_UserActivities_ApplicationUserId",
                table: "UserActivities");

            migrationBuilder.AlterColumn<int>(
                name: "ApplicationUserId",
                table: "UserActivities",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldNullable: true)
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "UserActivities",
                type: "varchar(255)",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_UserActivities_UserId",
                table: "UserActivities",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserActivities_AspNetUsers_UserId",
                table: "UserActivities",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
