using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FastBox.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddMetodosDePagamento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "fastbox-db",
                table: "MetodoPagamento",
                keyColumn: "MetodoPagamentoId",
                keyValue: 1L,
                column: "Nome",
                value: "Multibanco");

            migrationBuilder.UpdateData(
                schema: "fastbox-db",
                table: "MetodoPagamento",
                keyColumn: "MetodoPagamentoId",
                keyValue: 2L,
                column: "Nome",
                value: "MBWAY STD");

            migrationBuilder.UpdateData(
                schema: "fastbox-db",
                table: "MetodoPagamento",
                keyColumn: "MetodoPagamentoId",
                keyValue: 3L,
                column: "Nome",
                value: "MBWAY NB");

            migrationBuilder.InsertData(
                schema: "fastbox-db",
                table: "MetodoPagamento",
                columns: new[] { "MetodoPagamentoId", "Nome" },
                values: new object[] { 4L, "Numerário" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "fastbox-db",
                table: "MetodoPagamento",
                keyColumn: "MetodoPagamentoId",
                keyValue: 4L);

            migrationBuilder.UpdateData(
                schema: "fastbox-db",
                table: "MetodoPagamento",
                keyColumn: "MetodoPagamentoId",
                keyValue: 1L,
                column: "Nome",
                value: "Cartão de Crédito");

            migrationBuilder.UpdateData(
                schema: "fastbox-db",
                table: "MetodoPagamento",
                keyColumn: "MetodoPagamentoId",
                keyValue: 2L,
                column: "Nome",
                value: "Pix");

            migrationBuilder.UpdateData(
                schema: "fastbox-db",
                table: "MetodoPagamento",
                keyColumn: "MetodoPagamentoId",
                keyValue: 3L,
                column: "Nome",
                value: "Dinheiro");
        }
    }
}
