using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CbMobile.Database.Migrations
{
    public partial class delete_detailMemory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetailMemorys");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DetailMemorys",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false),
                    DisplayOrder = table.Column<int>(nullable: false),
                    MainMemoryId = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    Published = table.Column<bool>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedOnUtc = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetailMemorys", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DetailMemorys_MainMemorys_MainMemoryId",
                        column: x => x.MainMemoryId,
                        principalTable: "MainMemorys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetailMemorys_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DetailMemorys_MainMemoryId",
                table: "DetailMemorys",
                column: "MainMemoryId");

            migrationBuilder.CreateIndex(
                name: "IX_DetailMemorys_ProductId",
                table: "DetailMemorys",
                column: "ProductId");
        }
    }
}
