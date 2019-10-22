using Microsoft.EntityFrameworkCore.Migrations;

namespace CbMobile.Database.Migrations
{
    public partial class add_BannerCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoriesId",
                table: "Banners",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Banners",
                nullable: false,
                defaultValue: 0);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Banners");
        }
    }
}
