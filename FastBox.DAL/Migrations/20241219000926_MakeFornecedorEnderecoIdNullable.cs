using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FastBox.DAL.Migrations
{
    /// <inheritdoc />
    public partial class MakeFornecedorEnderecoIdNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "Fornecedor$EnderecoId_UNIQUE",
                schema: "fastbox-db",
                table: "Fornecedor");

            migrationBuilder.AlterColumn<long>(
                name: "EnderecoId",
                schema: "fastbox-db",
                table: "Fornecedor",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.CreateIndex(
                name: "Fornecedor$EnderecoId_UNIQUE",
                schema: "fastbox-db",
                table: "Fornecedor",
                column: "EnderecoId",
                unique: true,
                filter: "[EnderecoId] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "Fornecedor$EnderecoId_UNIQUE",
                schema: "fastbox-db",
                table: "Fornecedor");

            migrationBuilder.AlterColumn<long>(
                name: "EnderecoId",
                schema: "fastbox-db",
                table: "Fornecedor",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "Fornecedor$EnderecoId_UNIQUE",
                schema: "fastbox-db",
                table: "Fornecedor",
                column: "EnderecoId",
                unique: true);
        }
    }
}
