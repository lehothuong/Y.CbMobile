using Microsoft.EntityFrameworkCore.Migrations;

namespace CbMobile.Database.Migrations
{
    public partial class update_DetailBill_Name : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ColorName",
                table: "DetailBill",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MemoryName",
                table: "DetailBill",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ColorName",
                table: "DetailBill");

            migrationBuilder.DropColumn(
                name: "MemoryName",
                table: "DetailBill");
        }
    }
}
