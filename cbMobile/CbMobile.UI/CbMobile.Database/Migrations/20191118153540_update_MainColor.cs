using Microsoft.EntityFrameworkCore.Migrations;

namespace CbMobile.Database.Migrations
{
    public partial class update_MainColor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DetailAccessories_MainColor_MainColorId",
                table: "DetailAccessories");

            migrationBuilder.DropForeignKey(
                name: "FK_DetailAccessories_MainMemorys_MainMemoryId",
                table: "DetailAccessories");

            migrationBuilder.DropForeignKey(
                name: "FK_DetailAccessories_Products_ProductId",
                table: "DetailAccessories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MainColor",
                table: "MainColor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DetailAccessories",
                table: "DetailAccessories");

            migrationBuilder.RenameTable(
                name: "MainColor",
                newName: "MainColors");

            migrationBuilder.RenameTable(
                name: "DetailAccessories",
                newName: "DetailAccessoriess");

            migrationBuilder.RenameIndex(
                name: "IX_DetailAccessories_ProductId",
                table: "DetailAccessoriess",
                newName: "IX_DetailAccessoriess_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_DetailAccessories_MainMemoryId",
                table: "DetailAccessoriess",
                newName: "IX_DetailAccessoriess_MainMemoryId");

            migrationBuilder.RenameIndex(
                name: "IX_DetailAccessories_MainColorId",
                table: "DetailAccessoriess",
                newName: "IX_DetailAccessoriess_MainColorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MainColors",
                table: "MainColors",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DetailAccessoriess",
                table: "DetailAccessoriess",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DetailAccessoriess_MainColors_MainColorId",
                table: "DetailAccessoriess",
                column: "MainColorId",
                principalTable: "MainColors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DetailAccessoriess_MainMemorys_MainMemoryId",
                table: "DetailAccessoriess",
                column: "MainMemoryId",
                principalTable: "MainMemorys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DetailAccessoriess_Products_ProductId",
                table: "DetailAccessoriess",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DetailAccessoriess_MainColors_MainColorId",
                table: "DetailAccessoriess");

            migrationBuilder.DropForeignKey(
                name: "FK_DetailAccessoriess_MainMemorys_MainMemoryId",
                table: "DetailAccessoriess");

            migrationBuilder.DropForeignKey(
                name: "FK_DetailAccessoriess_Products_ProductId",
                table: "DetailAccessoriess");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MainColors",
                table: "MainColors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DetailAccessoriess",
                table: "DetailAccessoriess");

            migrationBuilder.RenameTable(
                name: "MainColors",
                newName: "MainColor");

            migrationBuilder.RenameTable(
                name: "DetailAccessoriess",
                newName: "DetailAccessories");

            migrationBuilder.RenameIndex(
                name: "IX_DetailAccessoriess_ProductId",
                table: "DetailAccessories",
                newName: "IX_DetailAccessories_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_DetailAccessoriess_MainMemoryId",
                table: "DetailAccessories",
                newName: "IX_DetailAccessories_MainMemoryId");

            migrationBuilder.RenameIndex(
                name: "IX_DetailAccessoriess_MainColorId",
                table: "DetailAccessories",
                newName: "IX_DetailAccessories_MainColorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MainColor",
                table: "MainColor",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DetailAccessories",
                table: "DetailAccessories",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DetailAccessories_MainColor_MainColorId",
                table: "DetailAccessories",
                column: "MainColorId",
                principalTable: "MainColor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DetailAccessories_MainMemorys_MainMemoryId",
                table: "DetailAccessories",
                column: "MainMemoryId",
                principalTable: "MainMemorys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DetailAccessories_Products_ProductId",
                table: "DetailAccessories",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
