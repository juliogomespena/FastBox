using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FastBox.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AdicionarNumeroFaturaItemOrcamento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NumeroFatura",
                schema: "fastbox-db",
                table: "ItemOrcamento",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumeroFatura",
                schema: "fastbox-db",
                table: "ItemOrcamento");
        }
    }
}
