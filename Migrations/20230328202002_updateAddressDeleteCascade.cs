using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class updateAddressDeleteCascade : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerAddress_Address_AddressID",
                schema: "SalesLT",
                table: "CustomerAddress");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerAddress_Customer_CustomerID",
                schema: "SalesLT",
                table: "CustomerAddress");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerAddress_Address_AddressID",
                schema: "SalesLT",
                table: "CustomerAddress",
                column: "AddressID",
                principalSchema: "SalesLT",
                principalTable: "Address",
                principalColumn: "AddressID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerAddress_Customer_CustomerID",
                schema: "SalesLT",
                table: "CustomerAddress",
                column: "CustomerID",
                principalSchema: "SalesLT",
                principalTable: "Customer",
                principalColumn: "CustomerID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerAddress_Address_AddressID",
                schema: "SalesLT",
                table: "CustomerAddress");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerAddress_Customer_CustomerID",
                schema: "SalesLT",
                table: "CustomerAddress");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerAddress_Address_AddressID",
                schema: "SalesLT",
                table: "CustomerAddress",
                column: "AddressID",
                principalSchema: "SalesLT",
                principalTable: "Address",
                principalColumn: "AddressID");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerAddress_Customer_CustomerID",
                schema: "SalesLT",
                table: "CustomerAddress",
                column: "CustomerID",
                principalSchema: "SalesLT",
                principalTable: "Customer",
                principalColumn: "CustomerID");
        }
    }
}
