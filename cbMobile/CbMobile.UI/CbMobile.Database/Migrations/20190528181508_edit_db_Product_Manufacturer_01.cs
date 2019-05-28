using Microsoft.EntityFrameworkCore.Migrations;

namespace CbMobile.Database.Migrations
{
    public partial class edit_db_Product_Manufacturer_01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Manufacturers_manufacturerId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "manufacturerId",
                table: "Products",
                newName: "ManufacturerId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_manufacturerId",
                table: "Products",
                newName: "IX_Products_ManufacturerId");

            migrationBuilder.AlterColumn<int>(
                name: "ManufacturerId",
                table: "Products",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Manufacturers_ManufacturerId",
                table: "Products",
                column: "ManufacturerId",
                principalTable: "Manufacturers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Manufacturers_ManufacturerId",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "ManufacturerId",
                table: "Products",
                newName: "manufacturerId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_ManufacturerId",
                table: "Products",
                newName: "IX_Products_manufacturerId");

            migrationBuilder.AlterColumn<int>(
                name: "manufacturerId",
                table: "Products",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "Products",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Manufacturers_manufacturerId",
                table: "Products",
                column: "manufacturerId",
                principalTable: "Manufacturers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
