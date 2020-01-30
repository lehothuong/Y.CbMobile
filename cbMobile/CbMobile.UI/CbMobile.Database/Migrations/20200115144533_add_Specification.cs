using Microsoft.EntityFrameworkCore.Migrations;

namespace CbMobile.Database.Migrations
{
    public partial class add_Specification : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DetailSpecifications_Products_ProductsId",
                table: "DetailSpecifications");

            migrationBuilder.DropForeignKey(
                name: "FK_DetailSpecifications_Specifications_SpecificationId",
                table: "DetailSpecifications");

            migrationBuilder.DropIndex(
                name: "IX_DetailSpecifications_ProductsId",
                table: "DetailSpecifications");

            migrationBuilder.DropColumn(
                name: "IdProduct",
                table: "DetailSpecifications");

            migrationBuilder.DropColumn(
                name: "ProductsId",
                table: "DetailSpecifications");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Specifications",
                newName: "Sim");

            migrationBuilder.RenameColumn(
                name: "IdSpecification",
                table: "DetailSpecifications",
                newName: "ProductId");

            migrationBuilder.AddColumn<string>(
                name: "BatteryCapacity",
                table: "Specifications",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Display",
                table: "Specifications",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FrontCamera",
                table: "Specifications",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Gpu",
                table: "Specifications",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OperatingSystem",
                table: "Specifications",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Ram",
                table: "Specifications",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RearCamera",
                table: "Specifications",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SpecificationId",
                table: "DetailSpecifications",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DetailSpecifications_ProductId",
                table: "DetailSpecifications",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_DetailSpecifications_Products_ProductId",
                table: "DetailSpecifications",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DetailSpecifications_Specifications_SpecificationId",
                table: "DetailSpecifications",
                column: "SpecificationId",
                principalTable: "Specifications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DetailSpecifications_Products_ProductId",
                table: "DetailSpecifications");

            migrationBuilder.DropForeignKey(
                name: "FK_DetailSpecifications_Specifications_SpecificationId",
                table: "DetailSpecifications");

            migrationBuilder.DropIndex(
                name: "IX_DetailSpecifications_ProductId",
                table: "DetailSpecifications");

            migrationBuilder.DropColumn(
                name: "BatteryCapacity",
                table: "Specifications");

            migrationBuilder.DropColumn(
                name: "Display",
                table: "Specifications");

            migrationBuilder.DropColumn(
                name: "FrontCamera",
                table: "Specifications");

            migrationBuilder.DropColumn(
                name: "Gpu",
                table: "Specifications");

            migrationBuilder.DropColumn(
                name: "OperatingSystem",
                table: "Specifications");

            migrationBuilder.DropColumn(
                name: "Ram",
                table: "Specifications");

            migrationBuilder.DropColumn(
                name: "RearCamera",
                table: "Specifications");

            migrationBuilder.RenameColumn(
                name: "Sim",
                table: "Specifications",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "DetailSpecifications",
                newName: "IdSpecification");

            migrationBuilder.AlterColumn<int>(
                name: "SpecificationId",
                table: "DetailSpecifications",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "IdProduct",
                table: "DetailSpecifications",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProductsId",
                table: "DetailSpecifications",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DetailSpecifications_ProductsId",
                table: "DetailSpecifications",
                column: "ProductsId");

            migrationBuilder.AddForeignKey(
                name: "FK_DetailSpecifications_Products_ProductsId",
                table: "DetailSpecifications",
                column: "ProductsId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DetailSpecifications_Specifications_SpecificationId",
                table: "DetailSpecifications",
                column: "SpecificationId",
                principalTable: "Specifications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
