using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FastBox.DAL.Migrations
{
    /// <inheritdoc />
    public partial class CreateLocalDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Margem",
                schema: "fastbox-db",
                table: "ItemOrcamento",
                type: "decimal(10,5)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(5,2)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Margem",
                schema: "fastbox-db",
                table: "ItemOrcamento",
                type: "decimal(5,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(10,5)");
        }
    }
}
