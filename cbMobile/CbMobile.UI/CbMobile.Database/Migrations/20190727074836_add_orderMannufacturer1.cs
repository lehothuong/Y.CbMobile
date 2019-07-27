using Microsoft.EntityFrameworkCore.Migrations;

namespace CbMobile.Database.Migrations
{
    public partial class add_orderMannufacturer1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderManuFacturer_CategoryProducts_CategoryProductId",
                table: "OrderManuFacturer");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderManuFacturer_Manufacturers_ManufacturerID",
                table: "OrderManuFacturer");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderManuFacturer",
                table: "OrderManuFacturer");

            migrationBuilder.DropIndex(
                name: "IX_OrderManuFacturer_CategoryProductId",
                table: "OrderManuFacturer");

            migrationBuilder.DropColumn(
                name: "CategoryProductId",
                table: "OrderManuFacturer");

            migrationBuilder.RenameTable(
                name: "OrderManuFacturer",
                newName: "OrderManuFacturers");

            migrationBuilder.RenameIndex(
                name: "IX_OrderManuFacturer_ManufacturerID",
                table: "OrderManuFacturers",
                newName: "IX_OrderManuFacturers_ManufacturerID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderManuFacturers",
                table: "OrderManuFacturers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderManuFacturers_Manufacturers_ManufacturerID",
                table: "OrderManuFacturers",
                column: "ManufacturerID",
                principalTable: "Manufacturers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderManuFacturers_Manufacturers_ManufacturerID",
                table: "OrderManuFacturers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderManuFacturers",
                table: "OrderManuFacturers");

            migrationBuilder.RenameTable(
                name: "OrderManuFacturers",
                newName: "OrderManuFacturer");

            migrationBuilder.RenameIndex(
                name: "IX_OrderManuFacturers_ManufacturerID",
                table: "OrderManuFacturer",
                newName: "IX_OrderManuFacturer_ManufacturerID");

            migrationBuilder.AddColumn<int>(
                name: "CategoryProductId",
                table: "OrderManuFacturer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderManuFacturer",
                table: "OrderManuFacturer",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_OrderManuFacturer_CategoryProductId",
                table: "OrderManuFacturer",
                column: "CategoryProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderManuFacturer_CategoryProducts_CategoryProductId",
                table: "OrderManuFacturer",
                column: "CategoryProductId",
                principalTable: "CategoryProducts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderManuFacturer_Manufacturers_ManufacturerID",
                table: "OrderManuFacturer",
                column: "ManufacturerID",
                principalTable: "Manufacturers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
