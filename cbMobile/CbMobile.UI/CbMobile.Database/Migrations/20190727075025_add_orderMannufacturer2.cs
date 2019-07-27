using Microsoft.EntityFrameworkCore.Migrations;

namespace CbMobile.Database.Migrations
{
    public partial class add_orderMannufacturer2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryProductId",
                table: "OrderManuFacturers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_OrderManuFacturers_CategoryProductId",
                table: "OrderManuFacturers",
                column: "CategoryProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderManuFacturers_CategoryProducts_CategoryProductId",
                table: "OrderManuFacturers",
                column: "CategoryProductId",
                principalTable: "CategoryProducts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderManuFacturers_CategoryProducts_CategoryProductId",
                table: "OrderManuFacturers");

            migrationBuilder.DropIndex(
                name: "IX_OrderManuFacturers_CategoryProductId",
                table: "OrderManuFacturers");

            migrationBuilder.DropColumn(
                name: "CategoryProductId",
                table: "OrderManuFacturers");
        }
    }
}
