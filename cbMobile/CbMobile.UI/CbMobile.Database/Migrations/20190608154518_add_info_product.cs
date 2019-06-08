using Microsoft.EntityFrameworkCore.Migrations;

namespace CbMobile.Database.Migrations
{
    public partial class add_info_product : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BatteryCapacity",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CameraAfter",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CameraHead",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GPU",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MainMemory",
                table: "Products",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Memoryexception",
                table: "Products",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Ram",
                table: "Products",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Screen",
                table: "Products",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BatteryCapacity",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CameraAfter",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CameraHead",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "GPU",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "MainMemory",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Memoryexception",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Ram",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Screen",
                table: "Products");
        }
    }
}
