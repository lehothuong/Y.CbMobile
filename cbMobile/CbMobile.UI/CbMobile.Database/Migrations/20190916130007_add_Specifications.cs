using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CbMobile.Database.Migrations
{
    public partial class add_Specifications : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BatteryCapacity",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CameraAfter",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CameraHead",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "GPU",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Memoryexception",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "Screen",
                table: "Products",
                newName: "Color");

            migrationBuilder.AlterColumn<string>(
                name: "Ram",
                table: "Products",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "MainMemory",
                table: "Products",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateTable(
                name: "Specification",
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
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specification", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DetailSpecification",
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
                    IdProduct = table.Column<int>(nullable: false),
                    ProductsId = table.Column<int>(nullable: true),
                    IdSpecification = table.Column<int>(nullable: false),
                    SpecificationId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetailSpecification", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DetailSpecification_Products_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DetailSpecification_Specification_SpecificationId",
                        column: x => x.SpecificationId,
                        principalTable: "Specification",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DetailSpecification_ProductsId",
                table: "DetailSpecification",
                column: "ProductsId");

            migrationBuilder.CreateIndex(
                name: "IX_DetailSpecification_SpecificationId",
                table: "DetailSpecification",
                column: "SpecificationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetailSpecification");

            migrationBuilder.DropTable(
                name: "Specification");

            migrationBuilder.RenameColumn(
                name: "Color",
                table: "Products",
                newName: "Screen");

            migrationBuilder.AlterColumn<int>(
                name: "Ram",
                table: "Products",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MainMemory",
                table: "Products",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BatteryCapacity",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CameraAfter",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CameraHead",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GPU",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Memoryexception",
                table: "Products",
                nullable: false,
                defaultValue: 0);
        }
    }
}
