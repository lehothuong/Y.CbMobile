using Microsoft.EntityFrameworkCore.Migrations;

namespace CbMobile.Database.Migrations
{
    public partial class add_CategoryProduct_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryProductId",
                table: "Products",
                column: "CategoryProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_CategoryProducts_CategoryProductId",
                table: "Products",
                column: "CategoryProductId",
                principalTable: "CategoryProducts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_CategoryProducts_CategoryProductId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_CategoryProductId",
                table: "Products");
        }
    }
}
