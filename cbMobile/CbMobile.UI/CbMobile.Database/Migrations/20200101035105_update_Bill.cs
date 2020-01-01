using Microsoft.EntityFrameworkCore.Migrations;

namespace CbMobile.Database.Migrations
{
    public partial class update_Bill : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Payment",
                table: "Bill",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Payment",
                table: "Bill",
                nullable: true,
                oldClrType: typeof(int));
        }
    }
}
