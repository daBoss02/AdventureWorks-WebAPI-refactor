using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class NameStyleNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "NameStyle",
                schema: "SalesLT",
                table: "Customer",
                type: "bit",
                nullable: false,
                defaultValueSql: "0",
                comment: "0 = The data in FirstName and LastName are stored in western style (first name, last name) order.  1 = Eastern style (last name, first name) order.",
                oldClrType: typeof(bool),
                oldType: "bit",
                oldComment: "0 = The data in FirstName and LastName are stored in western style (first name, last name) order.  1 = Eastern style (last name, first name) order.");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "NameStyle",
                schema: "SalesLT",
                table: "Customer",
                type: "bit",
                nullable: false,
                comment: "0 = The data in FirstName and LastName are stored in western style (first name, last name) order.  1 = Eastern style (last name, first name) order.",
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValueSql: "0",
                oldComment: "0 = The data in FirstName and LastName are stored in western style (first name, last name) order.  1 = Eastern style (last name, first name) order.");
        }
    }
}
