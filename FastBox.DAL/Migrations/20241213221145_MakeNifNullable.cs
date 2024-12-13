using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FastBox.DAL.Migrations
{
    /// <inheritdoc />
    public partial class MakeNifNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "Cliente$Nif_UNIQUE",
                schema: "fastbox-db",
                table: "Cliente");

            migrationBuilder.AlterColumn<string>(
                name: "Nif",
                schema: "fastbox-db",
                table: "Cliente",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.CreateIndex(
                name: "Cliente$Nif_UNIQUE",
                schema: "fastbox-db",
                table: "Cliente",
                column: "Nif",
                unique: true,
                filter: "[Nif] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "Cliente$Nif_UNIQUE",
                schema: "fastbox-db",
                table: "Cliente");

            migrationBuilder.AlterColumn<string>(
                name: "Nif",
                schema: "fastbox-db",
                table: "Cliente",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "Cliente$Nif_UNIQUE",
                schema: "fastbox-db",
                table: "Cliente",
                column: "Nif",
                unique: true);
        }
    }
}
