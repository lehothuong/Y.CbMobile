using Microsoft.EntityFrameworkCore.Migrations;

namespace CbMobile.Database.Migrations
{
    public partial class update_Bill_IsPay : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "IsPay",
                table: "Bill",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "IsPay",
                table: "Bill",
                nullable: true,
                oldClrType: typeof(bool));
        }
    }
}
