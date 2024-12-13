using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FastBox.DAL.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "fastbox-db");

            migrationBuilder.CreateTable(
                name: "Distrito",
                schema: "fastbox-db",
                columns: table => new
                {
                    DistritoId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Distrito_DistritoId", x => x.DistritoId);
                });

            migrationBuilder.CreateTable(
                name: "MetodoPagamento",
                schema: "fastbox-db",
                columns: table => new
                {
                    MetodoPagamentoId = table.Column<long>(type: "bigint", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MetodoPagamento_MetodoPagamentoId", x => x.MetodoPagamentoId);
                });

            migrationBuilder.CreateTable(
                name: "NivelDeAcessos",
                columns: table => new
                {
                    NivelDeAcessoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NivelDeAcessos", x => x.NivelDeAcessoId);
                });

            migrationBuilder.CreateTable(
                name: "StatusOrdemDeServico",
                schema: "fastbox-db",
                columns: table => new
                {
                    StatusOrdemDeServicoId = table.Column<long>(type: "bigint", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusOrdemDeServico_StatusOrdemDeServicoId", x => x.StatusOrdemDeServicoId);
                });

            migrationBuilder.CreateTable(
                name: "Concelho",
                schema: "fastbox-db",
                columns: table => new
                {
                    ConcelhoId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DistritoId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Concelho_ConcelhoId", x => x.ConcelhoId);
                    table.ForeignKey(
                        name: "Concelho$fk_Concelho_Distrito",
                        column: x => x.DistritoId,
                        principalSchema: "fastbox-db",
                        principalTable: "Distrito",
                        principalColumn: "DistritoId");
                });

            migrationBuilder.CreateTable(
                name: "Endereco",
                schema: "fastbox-db",
                columns: table => new
                {
                    EnderecoId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Logradouro = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Numero = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Complemento = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, defaultValueSql: "(NULL)"),
                    Freguesia = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CodigoPostal = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    ConcelhoId = table.Column<long>(type: "bigint", nullable: false),
                    Pais = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, defaultValue: "Portugal")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Endereco_EnderecoId", x => x.EnderecoId);
                    table.ForeignKey(
                        name: "Endereco$fk_Endereco_Concelho",
                        column: x => x.ConcelhoId,
                        principalSchema: "fastbox-db",
                        principalTable: "Concelho",
                        principalColumn: "ConcelhoId");
                });

            migrationBuilder.CreateTable(
                name: "Cliente",
                schema: "fastbox-db",
                columns: table => new
                {
                    ClienteId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    Sobrenome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Nif = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Telemovel = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, defaultValueSql: "(NULL)"),
                    EnderecoId = table.Column<long>(type: "bigint", nullable: true),
                    DataCadastro = table.Column<DateTime>(type: "datetime2(0)", precision: 0, nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente_ClienteId", x => x.ClienteId);
                    table.ForeignKey(
                        name: "Cliente$fk_Cliente_Endereco",
                        column: x => x.EnderecoId,
                        principalSchema: "fastbox-db",
                        principalTable: "Endereco",
                        principalColumn: "EnderecoId");
                });

            migrationBuilder.CreateTable(
                name: "Fornecedor",
                schema: "fastbox-db",
                columns: table => new
                {
                    FornecedorId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Telemovel = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, defaultValueSql: "(NULL)"),
                    EnderecoId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fornecedor_FornecedorId", x => x.FornecedorId);
                    table.ForeignKey(
                        name: "Fornecedor$fk_Fornecedor_Endereco",
                        column: x => x.EnderecoId,
                        principalSchema: "fastbox-db",
                        principalTable: "Endereco",
                        principalColumn: "EnderecoId");
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                schema: "fastbox-db",
                columns: table => new
                {
                    UsuarioId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Login = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Senha = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime2(0)", precision: 0, nullable: false, defaultValueSql: "(getdate())"),
                    ClienteId = table.Column<long>(type: "bigint", nullable: true, defaultValueSql: "(NULL)"),
                    NivelDeAcessoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario_UsuarioId", x => x.UsuarioId);
                    table.ForeignKey(
                        name: "FK_Usuario_NivelDeAcesso",
                        column: x => x.NivelDeAcessoId,
                        principalTable: "NivelDeAcessos",
                        principalColumn: "NivelDeAcessoId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "Usuario$fk_Usuario_Cliente",
                        column: x => x.ClienteId,
                        principalSchema: "fastbox-db",
                        principalTable: "Cliente",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Veiculo",
                schema: "fastbox-db",
                columns: table => new
                {
                    VeiculoId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClienteId = table.Column<long>(type: "bigint", nullable: true, defaultValueSql: "(NULL)"),
                    Marca = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Modelo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Ano = table.Column<int>(type: "int", nullable: false),
                    Matricula = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Observacoes = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Veiculo_VeiculoId", x => x.VeiculoId);
                    table.ForeignKey(
                        name: "Veiculo$fk_Veiculo_Cliente",
                        column: x => x.ClienteId,
                        principalSchema: "fastbox-db",
                        principalTable: "Cliente",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "EstoquePeca",
                schema: "fastbox-db",
                columns: table => new
                {
                    EstoquePecaId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Quantidade = table.Column<long>(type: "bigint", nullable: false),
                    PrecoUnitario = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Margem = table.Column<short>(type: "smallint", nullable: true, defaultValueSql: "(NULL)"),
                    FornecedorId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstoquePeca_EstoquePecaId", x => x.EstoquePecaId);
                    table.ForeignKey(
                        name: "EstoquePeca$fk_EstoquePeca_Fornecedor",
                        column: x => x.FornecedorId,
                        principalSchema: "fastbox-db",
                        principalTable: "Fornecedor",
                        principalColumn: "FornecedorId");
                });

            migrationBuilder.CreateTable(
                name: "OrdemDeServico",
                schema: "fastbox-db",
                columns: table => new
                {
                    OrdemDeServicoId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClienteId = table.Column<long>(type: "bigint", nullable: true, defaultValueSql: "(NULL)"),
                    VeiculoId = table.Column<long>(type: "bigint", nullable: true, defaultValueSql: "(NULL)"),
                    StatusOrdemDeServicoId = table.Column<long>(type: "bigint", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    DataAbertura = table.Column<DateTime>(type: "datetime2(0)", precision: 0, nullable: false, defaultValueSql: "(getdate())"),
                    DataConclusao = table.Column<DateTime>(type: "datetime2(0)", precision: 0, nullable: true, defaultValueSql: "(NULL)"),
                    GarantiaEmDias = table.Column<int>(type: "int", nullable: true, defaultValueSql: "(NULL)"),
                    ObservacoesGarantia = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdemDeServico_OrdemDeServicoId", x => x.OrdemDeServicoId);
                    table.ForeignKey(
                        name: "OrdemDeServico$fk_OrdemDeServico_Cliente",
                        column: x => x.ClienteId,
                        principalSchema: "fastbox-db",
                        principalTable: "Cliente",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "OrdemDeServico$fk_OrdemDeServico_StatusOrdemDeServico",
                        column: x => x.StatusOrdemDeServicoId,
                        principalSchema: "fastbox-db",
                        principalTable: "StatusOrdemDeServico",
                        principalColumn: "StatusOrdemDeServicoId");
                    table.ForeignKey(
                        name: "OrdemDeServico$fk_OrdemDeServico_Veiculo",
                        column: x => x.VeiculoId,
                        principalSchema: "fastbox-db",
                        principalTable: "Veiculo",
                        principalColumn: "VeiculoId");
                });

            migrationBuilder.CreateTable(
                name: "Orcamento",
                schema: "fastbox-db",
                columns: table => new
                {
                    OrcamentoId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrdemDeServicoId = table.Column<long>(type: "bigint", nullable: false),
                    StatusOrcamento = table.Column<byte>(type: "tinyint", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2(0)", precision: 0, nullable: false, defaultValueSql: "(getdate())"),
                    Descricao = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orcamento_OrcamentoId", x => x.OrcamentoId);
                    table.ForeignKey(
                        name: "Orcamento$fk_Orcamento_OrdemDeServico",
                        column: x => x.OrdemDeServicoId,
                        principalSchema: "fastbox-db",
                        principalTable: "OrdemDeServico",
                        principalColumn: "OrdemDeServicoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pagamento",
                schema: "fastbox-db",
                columns: table => new
                {
                    PagamentoId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrdemDeServicoId = table.Column<long>(type: "bigint", nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    DataPagamento = table.Column<DateTime>(type: "datetime2(0)", precision: 0, nullable: false, defaultValueSql: "(getdate())"),
                    MetodoPagamentoId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pagamento_PagamentoId", x => x.PagamentoId);
                    table.ForeignKey(
                        name: "Pagamento$fk_Pagamento_MetodoPagamento",
                        column: x => x.MetodoPagamentoId,
                        principalSchema: "fastbox-db",
                        principalTable: "MetodoPagamento",
                        principalColumn: "MetodoPagamentoId");
                    table.ForeignKey(
                        name: "Pagamento$fk_Pagamento_OrdemDeServico",
                        column: x => x.OrdemDeServicoId,
                        principalSchema: "fastbox-db",
                        principalTable: "OrdemDeServico",
                        principalColumn: "OrdemDeServicoId");
                });

            migrationBuilder.CreateTable(
                name: "ItemOrcamento",
                schema: "fastbox-db",
                columns: table => new
                {
                    ItemOrcamentoId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrcamentoId = table.Column<long>(type: "bigint", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Quantidade = table.Column<int>(type: "int", nullable: false),
                    PrecoUnitario = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Margem = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemOrcamento_ItemOrcamentoId", x => x.ItemOrcamentoId);
                    table.ForeignKey(
                        name: "ItemOrcamento$fk_ItemOrcamento_Orcamento",
                        column: x => x.OrcamentoId,
                        principalSchema: "fastbox-db",
                        principalTable: "Orcamento",
                        principalColumn: "OrcamentoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "Cliente$EnderecoId_UNIQUE",
                schema: "fastbox-db",
                table: "Cliente",
                column: "EnderecoId",
                unique: true,
                filter: "[EnderecoId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "Cliente$Nif_UNIQUE",
                schema: "fastbox-db",
                table: "Cliente",
                column: "Nif",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "Cliente$Nome_Sobrenome_UNIQUE",
                schema: "fastbox-db",
                table: "Cliente",
                columns: new[] { "Nome", "Sobrenome" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "fk_Cliente_Endereco_idx",
                schema: "fastbox-db",
                table: "Cliente",
                column: "EnderecoId");

            migrationBuilder.CreateIndex(
                name: "fk_Concelho_Distrito1_idx",
                schema: "fastbox-db",
                table: "Concelho",
                column: "DistritoId");

            migrationBuilder.CreateIndex(
                name: "fk_Endereco_Concelho1_idx",
                schema: "fastbox-db",
                table: "Endereco",
                column: "ConcelhoId");

            migrationBuilder.CreateIndex(
                name: "fk_EstoquePeca_Fornecedor1_idx",
                schema: "fastbox-db",
                table: "EstoquePeca",
                column: "FornecedorId");

            migrationBuilder.CreateIndex(
                name: "fk_Fornecedor_Endereco1_idx",
                schema: "fastbox-db",
                table: "Fornecedor",
                column: "EnderecoId");

            migrationBuilder.CreateIndex(
                name: "Fornecedor$EnderecoId_UNIQUE",
                schema: "fastbox-db",
                table: "Fornecedor",
                column: "EnderecoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "Fornecedor$Nome_UNIQUE",
                schema: "fastbox-db",
                table: "Fornecedor",
                column: "Nome",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "fk_ItemOrcamento_Orcamento1_idx",
                schema: "fastbox-db",
                table: "ItemOrcamento",
                column: "OrcamentoId");

            migrationBuilder.CreateIndex(
                name: "fk_Orcamento_OrdemDeServico1_idx",
                schema: "fastbox-db",
                table: "Orcamento",
                column: "OrdemDeServicoId");

            migrationBuilder.CreateIndex(
                name: "fk_OrdemDeServico_Cliente1_idx",
                schema: "fastbox-db",
                table: "OrdemDeServico",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "fk_OrdemDeServico_StatusOrdemDeServico1_idx",
                schema: "fastbox-db",
                table: "OrdemDeServico",
                column: "StatusOrdemDeServicoId");

            migrationBuilder.CreateIndex(
                name: "fk_OrdemDeServico_Veiculo1_idx",
                schema: "fastbox-db",
                table: "OrdemDeServico",
                column: "VeiculoId");

            migrationBuilder.CreateIndex(
                name: "fk_Pagamento_MetodoPagamento1_idx",
                schema: "fastbox-db",
                table: "Pagamento",
                column: "MetodoPagamentoId");

            migrationBuilder.CreateIndex(
                name: "fk_Pagamento_OrdemDeServico1_idx",
                schema: "fastbox-db",
                table: "Pagamento",
                column: "OrdemDeServicoId");

            migrationBuilder.CreateIndex(
                name: "StatusOrdemDeServico$StatusOrdemDeServicoId_UNIQUE",
                schema: "fastbox-db",
                table: "StatusOrdemDeServico",
                column: "StatusOrdemDeServicoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "fk_Usuario_Cliente1_idx",
                schema: "fastbox-db",
                table: "Usuario",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_NivelDeAcessoId",
                schema: "fastbox-db",
                table: "Usuario",
                column: "NivelDeAcessoId");

            migrationBuilder.CreateIndex(
                name: "Usuario$Email_UNIQUE",
                schema: "fastbox-db",
                table: "Usuario",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "Usuario$Login_UNIQUE",
                schema: "fastbox-db",
                table: "Usuario",
                column: "Login",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "fk_Veiculo_Cliente1_idx",
                schema: "fastbox-db",
                table: "Veiculo",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "Veiculo$Matricula_UNIQUE",
                schema: "fastbox-db",
                table: "Veiculo",
                column: "Matricula",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EstoquePeca",
                schema: "fastbox-db");

            migrationBuilder.DropTable(
                name: "ItemOrcamento",
                schema: "fastbox-db");

            migrationBuilder.DropTable(
                name: "Pagamento",
                schema: "fastbox-db");

            migrationBuilder.DropTable(
                name: "Usuario",
                schema: "fastbox-db");

            migrationBuilder.DropTable(
                name: "Fornecedor",
                schema: "fastbox-db");

            migrationBuilder.DropTable(
                name: "Orcamento",
                schema: "fastbox-db");

            migrationBuilder.DropTable(
                name: "MetodoPagamento",
                schema: "fastbox-db");

            migrationBuilder.DropTable(
                name: "NivelDeAcessos");

            migrationBuilder.DropTable(
                name: "OrdemDeServico",
                schema: "fastbox-db");

            migrationBuilder.DropTable(
                name: "StatusOrdemDeServico",
                schema: "fastbox-db");

            migrationBuilder.DropTable(
                name: "Veiculo",
                schema: "fastbox-db");

            migrationBuilder.DropTable(
                name: "Cliente",
                schema: "fastbox-db");

            migrationBuilder.DropTable(
                name: "Endereco",
                schema: "fastbox-db");

            migrationBuilder.DropTable(
                name: "Concelho",
                schema: "fastbox-db");

            migrationBuilder.DropTable(
                name: "Distrito",
                schema: "fastbox-db");
        }
    }
}
