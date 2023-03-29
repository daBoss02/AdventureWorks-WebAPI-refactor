using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSalesOrderHeaderNullableColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte>(
                name: "RevisionNumber",
                schema: "SalesLT",
                table: "SalesOrderHeader",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0,
                comment: "Incremental number to track changes to the sales order over time.",
                oldClrType: typeof(byte),
                oldType: "tinyint",
                oldComment: "Incremental number to track changes to the sales order over time.");

            migrationBuilder.AlterColumn<bool>(
                name: "OnlineOrderFlag",
                schema: "SalesLT",
                table: "SalesOrderHeader",
                type: "bit",
                nullable: true,
                defaultValueSql: "((1))",
                comment: "0 = Order placed by sales person. 1 = Order placed online by customer.",
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValueSql: "((1))",
                oldComment: "0 = Order placed by sales person. 1 = Order placed online by customer.");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte>(
                name: "RevisionNumber",
                schema: "SalesLT",
                table: "SalesOrderHeader",
                type: "tinyint",
                nullable: false,
                comment: "Incremental number to track changes to the sales order over time.",
                oldClrType: typeof(byte),
                oldType: "tinyint",
                oldDefaultValue: (byte)0,
                oldComment: "Incremental number to track changes to the sales order over time.");

            migrationBuilder.AlterColumn<bool>(
                name: "OnlineOrderFlag",
                schema: "SalesLT",
                table: "SalesOrderHeader",
                type: "bit",
                nullable: false,
                defaultValueSql: "((1))",
                comment: "0 = Order placed by sales person. 1 = Order placed online by customer.",
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true,
                oldDefaultValueSql: "((1))",
                oldComment: "0 = Order placed by sales person. 1 = Order placed online by customer.");
        }
    }
}
