using Microsoft.EntityFrameworkCore.Migrations;

namespace CbMobile.Database.Migrations
{
    public partial class update_mainMemoryId_Product : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MainMemoryId",
                table: "Products");

            migrationBuilder.AddColumn<string>(
                name: "MainMemory",
                table: "Products",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MainMemory",
                table: "Products");

            migrationBuilder.AddColumn<int>(
                name: "MainMemoryId",
                table: "Products",
                nullable: false,
                defaultValue: 0);
        }
    }
}
