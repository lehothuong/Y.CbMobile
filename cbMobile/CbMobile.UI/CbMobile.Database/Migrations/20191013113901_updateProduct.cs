using Microsoft.EntityFrameworkCore.Migrations;

namespace CbMobile.Database.Migrations
{
    public partial class updateProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "ValuePromotion",
                table: "Products",
                nullable: true,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<decimal>(
                name: "Value",
                table: "Products",
                nullable: true,
                oldClrType: typeof(decimal));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "ValuePromotion",
                table: "Products",
                nullable: false,
                oldClrType: typeof(decimal),
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Value",
                table: "Products",
                nullable: false,
                oldClrType: typeof(decimal),
                oldNullable: true);
        }
    }
}
