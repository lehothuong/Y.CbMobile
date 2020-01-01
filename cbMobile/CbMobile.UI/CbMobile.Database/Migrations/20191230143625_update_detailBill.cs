using Microsoft.EntityFrameworkCore.Migrations;

namespace CbMobile.Database.Migrations
{
    public partial class update_detailBill : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Total",
                table: "DetailBill",
                newName: "Price");

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalPrice",
                table: "DetailBill",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "Amount",
                table: "DetailBill",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Amount",
                table: "DetailBill");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "DetailBill",
                newName: "Total");

            migrationBuilder.AlterColumn<int>(
                name: "TotalPrice",
                table: "DetailBill",
                nullable: false,
                oldClrType: typeof(decimal));
        }
    }
}
