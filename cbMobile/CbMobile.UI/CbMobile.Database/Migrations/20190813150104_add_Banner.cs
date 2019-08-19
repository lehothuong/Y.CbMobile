using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CbMobile.Database.Migrations
{
    public partial class add_Banner : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CreateDate",
                table: "Posts",
                newName: "UpdatedOnUtc");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Products",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOnUtc",
                table: "Products",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "Products",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "DisplayOrder",
                table: "Products",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "Published",
                table: "Products",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "Products",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedOnUtc",
                table: "Products",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Posts",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOnUtc",
                table: "Posts",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "Posts",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "DisplayOrder",
                table: "Posts",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "Published",
                table: "Posts",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "Posts",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Orders",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOnUtc",
                table: "Orders",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "Orders",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "DisplayOrder",
                table: "Orders",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "Published",
                table: "Orders",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "Orders",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedOnUtc",
                table: "Orders",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "OrderProducts",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOnUtc",
                table: "OrderProducts",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "OrderProducts",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "DisplayOrder",
                table: "OrderProducts",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "Published",
                table: "OrderProducts",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "OrderProducts",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedOnUtc",
                table: "OrderProducts",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "OrderManuFacturers",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOnUtc",
                table: "OrderManuFacturers",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "OrderManuFacturers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "DisplayOrder",
                table: "OrderManuFacturers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "Published",
                table: "OrderManuFacturers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "OrderManuFacturers",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedOnUtc",
                table: "OrderManuFacturers",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Manufacturers",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOnUtc",
                table: "Manufacturers",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "Manufacturers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "DisplayOrder",
                table: "Manufacturers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "Published",
                table: "Manufacturers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "Manufacturers",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedOnUtc",
                table: "Manufacturers",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Locations",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOnUtc",
                table: "Locations",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "Locations",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "DisplayOrder",
                table: "Locations",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "Published",
                table: "Locations",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "Locations",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedOnUtc",
                table: "Locations",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Contacts",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOnUtc",
                table: "Contacts",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "Contacts",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "DisplayOrder",
                table: "Contacts",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "Published",
                table: "Contacts",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "Contacts",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedOnUtc",
                table: "Contacts",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "CategoryProducts",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOnUtc",
                table: "CategoryProducts",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "CategoryProducts",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "DisplayOrder",
                table: "CategoryProducts",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "Published",
                table: "CategoryProducts",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "CategoryProducts",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedOnUtc",
                table: "CategoryProducts",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Categories",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOnUtc",
                table: "Categories",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "Categories",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "DisplayOrder",
                table: "Categories",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "Published",
                table: "Categories",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "Categories",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedOnUtc",
                table: "Categories",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CreatedOnUtc",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "DisplayOrder",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Published",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "UpdatedOnUtc",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "CreatedOnUtc",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "DisplayOrder",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "Published",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "CreatedOnUtc",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "DisplayOrder",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Published",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "UpdatedOnUtc",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "OrderProducts");

            migrationBuilder.DropColumn(
                name: "CreatedOnUtc",
                table: "OrderProducts");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "OrderProducts");

            migrationBuilder.DropColumn(
                name: "DisplayOrder",
                table: "OrderProducts");

            migrationBuilder.DropColumn(
                name: "Published",
                table: "OrderProducts");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "OrderProducts");

            migrationBuilder.DropColumn(
                name: "UpdatedOnUtc",
                table: "OrderProducts");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "OrderManuFacturers");

            migrationBuilder.DropColumn(
                name: "CreatedOnUtc",
                table: "OrderManuFacturers");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "OrderManuFacturers");

            migrationBuilder.DropColumn(
                name: "DisplayOrder",
                table: "OrderManuFacturers");

            migrationBuilder.DropColumn(
                name: "Published",
                table: "OrderManuFacturers");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "OrderManuFacturers");

            migrationBuilder.DropColumn(
                name: "UpdatedOnUtc",
                table: "OrderManuFacturers");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Manufacturers");

            migrationBuilder.DropColumn(
                name: "CreatedOnUtc",
                table: "Manufacturers");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "Manufacturers");

            migrationBuilder.DropColumn(
                name: "DisplayOrder",
                table: "Manufacturers");

            migrationBuilder.DropColumn(
                name: "Published",
                table: "Manufacturers");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "Manufacturers");

            migrationBuilder.DropColumn(
                name: "UpdatedOnUtc",
                table: "Manufacturers");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "CreatedOnUtc",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "DisplayOrder",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "Published",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "UpdatedOnUtc",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "CreatedOnUtc",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "DisplayOrder",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "Published",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "UpdatedOnUtc",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "CategoryProducts");

            migrationBuilder.DropColumn(
                name: "CreatedOnUtc",
                table: "CategoryProducts");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "CategoryProducts");

            migrationBuilder.DropColumn(
                name: "DisplayOrder",
                table: "CategoryProducts");

            migrationBuilder.DropColumn(
                name: "Published",
                table: "CategoryProducts");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "CategoryProducts");

            migrationBuilder.DropColumn(
                name: "UpdatedOnUtc",
                table: "CategoryProducts");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "CreatedOnUtc",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "DisplayOrder",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "Published",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "UpdatedOnUtc",
                table: "Categories");

            migrationBuilder.RenameColumn(
                name: "UpdatedOnUtc",
                table: "Posts",
                newName: "CreateDate");
        }
    }
}
