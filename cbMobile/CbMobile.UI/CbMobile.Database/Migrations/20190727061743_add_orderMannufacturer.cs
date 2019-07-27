using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CbMobile.Database.Migrations
{
    public partial class add_orderMannufacturer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OrderManuFacturer",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CategoryProductId = table.Column<int>(nullable: false),
                    ManufacturerID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderManuFacturer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderManuFacturer_CategoryProducts_CategoryProductId",
                        column: x => x.CategoryProductId,
                        principalTable: "CategoryProducts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderManuFacturer_Manufacturers_ManufacturerID",
                        column: x => x.ManufacturerID,
                        principalTable: "Manufacturers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderManuFacturer_CategoryProductId",
                table: "OrderManuFacturer",
                column: "CategoryProductId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderManuFacturer_ManufacturerID",
                table: "OrderManuFacturer",
                column: "ManufacturerID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderManuFacturer");
        }
    }
}
