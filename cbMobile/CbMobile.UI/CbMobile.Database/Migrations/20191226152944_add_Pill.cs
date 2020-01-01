using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CbMobile.Database.Migrations
{
    public partial class add_Pill : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bill",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Deleted = table.Column<bool>(nullable: false),
                    Published = table.Column<bool>(nullable: false),
                    DisplayOrder = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(nullable: false),
                    UpdatedOnUtc = table.Column<DateTime>(nullable: false),
                    UserName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Payment = table.Column<string>(nullable: true),
                    Content = table.Column<string>(nullable: true),
                    TotalBill = table.Column<string>(nullable: true),
                    IsPay = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bill", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DetailBill",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Deleted = table.Column<bool>(nullable: false),
                    Published = table.Column<bool>(nullable: false),
                    DisplayOrder = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(nullable: false),
                    UpdatedOnUtc = table.Column<DateTime>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    BillId = table.Column<int>(nullable: false),
                    Total = table.Column<int>(nullable: false),
                    TotalPrice = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetailBill", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DetailBill_Bill_BillId",
                        column: x => x.BillId,
                        principalTable: "Bill",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetailBill_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DetailBill_BillId",
                table: "DetailBill",
                column: "BillId");

            migrationBuilder.CreateIndex(
                name: "IX_DetailBill_ProductId",
                table: "DetailBill",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetailBill");

            migrationBuilder.DropTable(
                name: "Bill");
        }
    }
}
