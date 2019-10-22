using Microsoft.EntityFrameworkCore.Migrations;

namespace CbMobile.Database.Migrations
{
    public partial class add_BannerCategorynew : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Banners_Categories_CategoriesId",
                table: "Banners");

            migrationBuilder.DropIndex(
                name: "IX_Banners_CategoriesId",
                table: "Banners");

            migrationBuilder.DropColumn(
                name: "CategoriesId",
                table: "Banners");

            migrationBuilder.CreateIndex(
                name: "IX_Banners_CategoryId",
                table: "Banners",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Banners_Categories_CategoryId",
                table: "Banners",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Banners_Categories_CategoryId",
                table: "Banners");

            migrationBuilder.DropIndex(
                name: "IX_Banners_CategoryId",
                table: "Banners");

            migrationBuilder.AddColumn<int>(
                name: "CategoriesId",
                table: "Banners",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Banners_CategoriesId",
                table: "Banners",
                column: "CategoriesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Banners_Categories_CategoriesId",
                table: "Banners",
                column: "CategoriesId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
