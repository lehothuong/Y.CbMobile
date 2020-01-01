using Microsoft.EntityFrameworkCore.Migrations;

namespace CbMobile.Database.Migrations
{
    public partial class update_detailBill_decimal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "DetailBill",
                nullable: false,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Price",
                table: "DetailBill",
                nullable: false,
                oldClrType: typeof(decimal));
        }
    }
}
