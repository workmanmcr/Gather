using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gather.Migrations
{
    public partial class NameChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GuestItems_AspNetUsers_UserId1",
                table: "GuestItems");

            migrationBuilder.DropIndex(
                name: "IX_GuestItems_UserId1",
                table: "GuestItems");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "GuestItems");

            migrationBuilder.RenameColumn(
                name: "VendorItemsId",
                table: "VendorItems",
                newName: "VendorItemId");

            migrationBuilder.RenameColumn(
                name: "GuestItemsId",
                table: "GuestItems",
                newName: "GuestItemId");

            migrationBuilder.RenameColumn(
                name: "GatheringItemsId",
                table: "GatheringItems",
                newName: "GatheringItemId");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "GuestItems",
                type: "varchar(255)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_GuestItems_UserId",
                table: "GuestItems",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_GuestItems_AspNetUsers_UserId",
                table: "GuestItems",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GuestItems_AspNetUsers_UserId",
                table: "GuestItems");

            migrationBuilder.DropIndex(
                name: "IX_GuestItems_UserId",
                table: "GuestItems");

            migrationBuilder.RenameColumn(
                name: "VendorItemId",
                table: "VendorItems",
                newName: "VendorItemsId");

            migrationBuilder.RenameColumn(
                name: "GuestItemId",
                table: "GuestItems",
                newName: "GuestItemsId");

            migrationBuilder.RenameColumn(
                name: "GatheringItemId",
                table: "GatheringItems",
                newName: "GatheringItemsId");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "GuestItems",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldNullable: true)
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "GuestItems",
                type: "varchar(255)",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_GuestItems_UserId1",
                table: "GuestItems",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_GuestItems_AspNetUsers_UserId1",
                table: "GuestItems",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
