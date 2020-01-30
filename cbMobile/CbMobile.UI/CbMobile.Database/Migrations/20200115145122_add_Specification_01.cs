using Microsoft.EntityFrameworkCore.Migrations;

namespace CbMobile.Database.Migrations
{
    public partial class add_Specification_01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BatteryCapacity",
                table: "Specifications");

            migrationBuilder.DropColumn(
                name: "Display",
                table: "Specifications");

            migrationBuilder.DropColumn(
                name: "FrontCamera",
                table: "Specifications");

            migrationBuilder.DropColumn(
                name: "Gpu",
                table: "Specifications");

            migrationBuilder.DropColumn(
                name: "OperatingSystem",
                table: "Specifications");

            migrationBuilder.DropColumn(
                name: "Ram",
                table: "Specifications");

            migrationBuilder.DropColumn(
                name: "RearCamera",
                table: "Specifications");

            migrationBuilder.RenameColumn(
                name: "Sim",
                table: "Specifications",
                newName: "Name");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Specifications",
                newName: "Sim");

            migrationBuilder.AddColumn<string>(
                name: "BatteryCapacity",
                table: "Specifications",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Display",
                table: "Specifications",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FrontCamera",
                table: "Specifications",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Gpu",
                table: "Specifications",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OperatingSystem",
                table: "Specifications",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Ram",
                table: "Specifications",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RearCamera",
                table: "Specifications",
                nullable: true);
        }
    }
}
