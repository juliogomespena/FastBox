using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FastBox.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddMetodoPagamentoSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "fastbox-db",
                table: "MetodoPagamento",
                columns: new[] { "MetodoPagamentoId", "Nome" },
                values: new object[,]
                {
                    { 1L, "Cartão de Crédito" },
                    { 2L, "Pix" },
                    { 3L, "Dinheiro" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "fastbox-db",
                table: "MetodoPagamento",
                keyColumn: "MetodoPagamentoId",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                schema: "fastbox-db",
                table: "MetodoPagamento",
                keyColumn: "MetodoPagamentoId",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                schema: "fastbox-db",
                table: "MetodoPagamento",
                keyColumn: "MetodoPagamentoId",
                keyValue: 3L);
        }
    }
}
