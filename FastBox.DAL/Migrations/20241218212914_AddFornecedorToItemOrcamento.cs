using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FastBox.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddFornecedorToItemOrcamento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "FornecedorId",
                schema: "fastbox-db",
                table: "ItemOrcamento",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_ItemOrcamento_FornecedorId",
                schema: "fastbox-db",
                table: "ItemOrcamento",
                column: "FornecedorId");

            migrationBuilder.AddForeignKey(
                name: "ItemOrcamento$fk_ItemOrcamento_Fornecedor",
                schema: "fastbox-db",
                table: "ItemOrcamento",
                column: "FornecedorId",
                principalSchema: "fastbox-db",
                principalTable: "Fornecedor",
                principalColumn: "FornecedorId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "ItemOrcamento$fk_ItemOrcamento_Fornecedor",
                schema: "fastbox-db",
                table: "ItemOrcamento");

            migrationBuilder.DropIndex(
                name: "IX_ItemOrcamento_FornecedorId",
                schema: "fastbox-db",
                table: "ItemOrcamento");

            migrationBuilder.DropColumn(
                name: "FornecedorId",
                schema: "fastbox-db",
                table: "ItemOrcamento");
        }
    }
}
