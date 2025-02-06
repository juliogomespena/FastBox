using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FastBox.DAL.Migrations
{
    /// <inheritdoc />
    public partial class ChangeQuantityToFloat : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "Quantidade",
                schema: "fastbox-db",
                table: "ItemOrcamento",
                type: "real",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Quantidade",
                schema: "fastbox-db",
                table: "ItemOrcamento",
                type: "int",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");
        }
    }
}
