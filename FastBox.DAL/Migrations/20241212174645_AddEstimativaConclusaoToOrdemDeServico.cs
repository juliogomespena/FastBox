using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FastBox.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddEstimativaConclusaoToOrdemDeServico : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "EstimativaConclusao",
                schema: "fastbox-db",
                table: "OrdemDeServico",
                type: "datetime2(0)",
                precision: 0,
                nullable: true,
                defaultValueSql: "(NULL)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EstimativaConclusao",
                schema: "fastbox-db",
                table: "OrdemDeServico");
        }
    }
}
