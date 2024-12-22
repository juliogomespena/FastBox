using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FastBox.DAL.Migrations
{
    /// <inheritdoc />
    public partial class ChangeGarantiaToDateTime : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GarantiaEmDias",
                schema: "fastbox-db",
                table: "OrdemDeServico");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataGarantia",
                schema: "fastbox-db",
                table: "OrdemDeServico",
                type: "datetime2",
                nullable: true,
                defaultValueSql: "(NULL)");

            migrationBuilder.UpdateData(
                schema: "fastbox-db",
                table: "MetodoPagamento",
                keyColumn: "MetodoPagamentoId",
                keyValue: 1L,
                column: "Nome",
                value: "MULTIBANCO");

            migrationBuilder.UpdateData(
                schema: "fastbox-db",
                table: "MetodoPagamento",
                keyColumn: "MetodoPagamentoId",
                keyValue: 4L,
                column: "Nome",
                value: "NUMERÁRIO");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataGarantia",
                schema: "fastbox-db",
                table: "OrdemDeServico");

            migrationBuilder.AddColumn<int>(
                name: "GarantiaEmDias",
                schema: "fastbox-db",
                table: "OrdemDeServico",
                type: "int",
                nullable: true,
                defaultValueSql: "(NULL)");

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
                keyValue: 4L,
                column: "Nome",
                value: "Numerário");
        }
    }
}
