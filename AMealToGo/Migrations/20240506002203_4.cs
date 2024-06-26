using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AMealToGo.Migrations
{
    /// <inheritdoc />
    public partial class _4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CategoryName",
                table: "Category",
                newName: "Meet");

            migrationBuilder.AddColumn<decimal>(
                name: "OrderTotal",
                table: "Orders",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CustomerAddress",
                table: "Customer",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CustomerEmail",
                table: "Customer",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CustomerPhoneNumber",
                table: "Customer",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Dairy",
                table: "Category",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderTotal",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "CustomerAddress",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "CustomerEmail",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "CustomerPhoneNumber",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "Dairy",
                table: "Category");

            migrationBuilder.RenameColumn(
                name: "Meet",
                table: "Category",
                newName: "CategoryName");
        }
    }
}
