﻿// <auto-generated />
using System;
using FastBox.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FastBox.DAL.Migrations
{
    [DbContext(typeof(FastBoxDbContext))]
    partial class FastBoxDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FastBox.DAL.Models.Cliente", b =>
                {
                    b.Property<long>("ClienteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("ClienteId"));

                    b.Property<DateTime>("DataCadastro")
                        .ValueGeneratedOnAdd()
                        .HasPrecision(0)
                        .HasColumnType("datetime2(0)")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<string>("Email")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasDefaultValueSql("(NULL)");

                    b.Property<long?>("EnderecoId")
                        .HasColumnType("bigint");

                    b.Property<string>("Nif")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("nvarchar(45)");

                    b.Property<string>("Sobrenome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Telemovel")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("ClienteId")
                        .HasName("PK_Cliente_ClienteId");

                    b.HasIndex(new[] { "EnderecoId" }, "Cliente$EnderecoId_UNIQUE")
                        .IsUnique()
                        .HasFilter("[EnderecoId] IS NOT NULL");

                    b.HasIndex(new[] { "Nif" }, "Cliente$Nif_UNIQUE")
                        .IsUnique()
                        .HasFilter("[Nif] IS NOT NULL");

                    b.HasIndex(new[] { "Nome", "Sobrenome" }, "Cliente$Nome_Sobrenome_UNIQUE")
                        .IsUnique();

                    b.HasIndex(new[] { "EnderecoId" }, "fk_Cliente_Endereco_idx");

                    b.ToTable("Cliente", "fastbox-db", t =>
                        {
                            t.HasTrigger("Cliente_AFTER_DELETE_AfterDelete");
                        });

                    b.HasAnnotation("SqlServer:UseSqlOutputClause", false);
                });

            modelBuilder.Entity("FastBox.DAL.Models.Concelho", b =>
                {
                    b.Property<long>("ConcelhoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("ConcelhoId"));

                    b.Property<long>("DistritoId")
                        .HasColumnType("bigint");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("ConcelhoId")
                        .HasName("PK_Concelho_ConcelhoId");

                    b.HasIndex(new[] { "DistritoId" }, "fk_Concelho_Distrito1_idx");

                    b.ToTable("Concelho", "fastbox-db");
                });

            modelBuilder.Entity("FastBox.DAL.Models.Distrito", b =>
                {
                    b.Property<long>("DistritoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("DistritoId"));

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("DistritoId")
                        .HasName("PK_Distrito_DistritoId");

                    b.ToTable("Distrito", "fastbox-db");
                });

            modelBuilder.Entity("FastBox.DAL.Models.Endereco", b =>
                {
                    b.Property<long>("EnderecoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("EnderecoId"));

                    b.Property<string>("CodigoPostal")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Complemento")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasDefaultValueSql("(NULL)");

                    b.Property<long>("ConcelhoId")
                        .HasColumnType("bigint");

                    b.Property<string>("Freguesia")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Logradouro")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Pais")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasDefaultValue("Portugal");

                    b.HasKey("EnderecoId")
                        .HasName("PK_Endereco_EnderecoId");

                    b.HasIndex(new[] { "ConcelhoId" }, "fk_Endereco_Concelho1_idx");

                    b.ToTable("Endereco", "fastbox-db");
                });

            modelBuilder.Entity("FastBox.DAL.Models.EstoquePeca", b =>
                {
                    b.Property<long>("EstoquePecaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("EstoquePecaId"));

                    b.Property<long>("FornecedorId")
                        .HasColumnType("bigint");

                    b.Property<short?>("Margem")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("smallint")
                        .HasDefaultValueSql("(NULL)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<decimal>("PrecoUnitario")
                        .HasColumnType("decimal(10, 2)");

                    b.Property<long>("Quantidade")
                        .HasColumnType("bigint");

                    b.HasKey("EstoquePecaId")
                        .HasName("PK_EstoquePeca_EstoquePecaId");

                    b.HasIndex(new[] { "FornecedorId" }, "fk_EstoquePeca_Fornecedor1_idx");

                    b.ToTable("EstoquePeca", "fastbox-db");
                });

            modelBuilder.Entity("FastBox.DAL.Models.Fornecedor", b =>
                {
                    b.Property<long>("FornecedorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("FornecedorId"));

                    b.Property<string>("Email")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasDefaultValueSql("(NULL)");

                    b.Property<long?>("EnderecoId")
                        .HasColumnType("bigint");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Telemovel")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("FornecedorId")
                        .HasName("PK_Fornecedor_FornecedorId");

                    b.HasIndex(new[] { "EnderecoId" }, "Fornecedor$EnderecoId_UNIQUE")
                        .IsUnique()
                        .HasFilter("[EnderecoId] IS NOT NULL");

                    b.HasIndex(new[] { "Nome" }, "Fornecedor$Nome_UNIQUE")
                        .IsUnique();

                    b.HasIndex(new[] { "EnderecoId" }, "fk_Fornecedor_Endereco1_idx");

                    b.ToTable("Fornecedor", "fastbox-db", t =>
                        {
                            t.HasTrigger("Fornecedor_AFTER_DELETE_AfterDelete");
                        });

                    b.HasAnnotation("SqlServer:UseSqlOutputClause", false);
                });

            modelBuilder.Entity("FastBox.DAL.Models.ItemOrcamento", b =>
                {
                    b.Property<long>("ItemOrcamentoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("ItemOrcamentoId"));

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<long>("FornecedorId")
                        .HasColumnType("bigint");

                    b.Property<decimal>("Margem")
                        .HasColumnType("decimal(5, 2)");

                    b.Property<int?>("NumeroFatura")
                        .HasColumnType("int");

                    b.Property<long>("OrcamentoId")
                        .HasColumnType("bigint");

                    b.Property<decimal>("PrecoUnitario")
                        .HasColumnType("decimal(10, 2)");

                    b.Property<int>("Quantidade")
                        .HasColumnType("int");

                    b.HasKey("ItemOrcamentoId")
                        .HasName("PK_ItemOrcamento_ItemOrcamentoId");

                    b.HasIndex("FornecedorId");

                    b.HasIndex(new[] { "OrcamentoId" }, "fk_ItemOrcamento_Orcamento1_idx");

                    b.ToTable("ItemOrcamento", "fastbox-db");
                });

            modelBuilder.Entity("FastBox.DAL.Models.MetodoPagamento", b =>
                {
                    b.Property<long>("MetodoPagamentoId")
                        .HasColumnType("bigint");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("nvarchar(45)");

                    b.HasKey("MetodoPagamentoId")
                        .HasName("PK_MetodoPagamento_MetodoPagamentoId");

                    b.ToTable("MetodoPagamento", "fastbox-db");

                    b.HasData(
                        new
                        {
                            MetodoPagamentoId = 1L,
                            Nome = "MULTIBANCO"
                        },
                        new
                        {
                            MetodoPagamentoId = 2L,
                            Nome = "MBWAY STD"
                        },
                        new
                        {
                            MetodoPagamentoId = 3L,
                            Nome = "MBWAY NB"
                        },
                        new
                        {
                            MetodoPagamentoId = 4L,
                            Nome = "NUMERÁRIO"
                        });
                });

            modelBuilder.Entity("FastBox.DAL.Models.NivelDeAcesso", b =>
                {
                    b.Property<int>("NivelDeAcessoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("NivelDeAcessoId"));

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("NivelDeAcessoId");

                    b.ToTable("NivelDeAcessos");
                });

            modelBuilder.Entity("FastBox.DAL.Models.Orcamento", b =>
                {
                    b.Property<long>("OrcamentoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("OrcamentoId"));

                    b.Property<DateTime>("DataCriacao")
                        .ValueGeneratedOnAdd()
                        .HasPrecision(0)
                        .HasColumnType("datetime2(0)")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<string>("Descricao")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<long>("OrdemDeServicoId")
                        .HasColumnType("bigint");

                    b.Property<byte>("StatusOrcamento")
                        .HasColumnType("tinyint");

                    b.HasKey("OrcamentoId")
                        .HasName("PK_Orcamento_OrcamentoId");

                    b.HasIndex(new[] { "OrdemDeServicoId" }, "fk_Orcamento_OrdemDeServico1_idx");

                    b.ToTable("Orcamento", "fastbox-db");
                });

            modelBuilder.Entity("FastBox.DAL.Models.OrdemDeServico", b =>
                {
                    b.Property<long>("OrdemDeServicoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("OrdemDeServicoId"));

                    b.Property<long?>("ClienteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasDefaultValueSql("(NULL)");

                    b.Property<DateTime>("DataAbertura")
                        .ValueGeneratedOnAdd()
                        .HasPrecision(0)
                        .HasColumnType("datetime2(0)")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<DateTime?>("DataConclusao")
                        .ValueGeneratedOnAdd()
                        .HasPrecision(0)
                        .HasColumnType("datetime2(0)")
                        .HasDefaultValueSql("(NULL)");

                    b.Property<DateTime?>("DataGarantia")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("(NULL)");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime?>("EstimativaConclusao")
                        .ValueGeneratedOnAdd()
                        .HasPrecision(0)
                        .HasColumnType("datetime2(0)")
                        .HasDefaultValueSql("(NULL)");

                    b.Property<bool>("IncluirIva")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("ObservacoesGarantia")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<long>("StatusOrdemDeServicoId")
                        .HasColumnType("bigint");

                    b.Property<decimal?>("ValorTotal")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("decimal(10, 2)")
                        .HasDefaultValueSql("(NULL)");

                    b.Property<long?>("VeiculoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasDefaultValueSql("(NULL)");

                    b.HasKey("OrdemDeServicoId")
                        .HasName("PK_OrdemDeServico_OrdemDeServicoId");

                    b.HasIndex(new[] { "ClienteId" }, "fk_OrdemDeServico_Cliente1_idx");

                    b.HasIndex(new[] { "StatusOrdemDeServicoId" }, "fk_OrdemDeServico_StatusOrdemDeServico1_idx");

                    b.HasIndex(new[] { "VeiculoId" }, "fk_OrdemDeServico_Veiculo1_idx");

                    b.ToTable("OrdemDeServico", "fastbox-db");
                });

            modelBuilder.Entity("FastBox.DAL.Models.Pagamento", b =>
                {
                    b.Property<long>("PagamentoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("PagamentoId"));

                    b.Property<DateTime>("DataPagamento")
                        .ValueGeneratedOnAdd()
                        .HasPrecision(0)
                        .HasColumnType("datetime2(0)")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<long>("MetodoPagamentoId")
                        .HasColumnType("bigint");

                    b.Property<long>("OrdemDeServicoId")
                        .HasColumnType("bigint");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(10, 2)");

                    b.HasKey("PagamentoId")
                        .HasName("PK_Pagamento_PagamentoId");

                    b.HasIndex(new[] { "MetodoPagamentoId" }, "fk_Pagamento_MetodoPagamento1_idx");

                    b.HasIndex(new[] { "OrdemDeServicoId" }, "fk_Pagamento_OrdemDeServico1_idx");

                    b.ToTable("Pagamento", "fastbox-db");
                });

            modelBuilder.Entity("FastBox.DAL.Models.StatusOrdemDeServico", b =>
                {
                    b.Property<long>("StatusOrdemDeServicoId")
                        .HasColumnType("bigint");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("StatusOrdemDeServicoId")
                        .HasName("PK_StatusOrdemDeServico_StatusOrdemDeServicoId");

                    b.HasIndex(new[] { "StatusOrdemDeServicoId" }, "StatusOrdemDeServico$StatusOrdemDeServicoId_UNIQUE")
                        .IsUnique();

                    b.ToTable("StatusOrdemDeServico", "fastbox-db");
                });

            modelBuilder.Entity("FastBox.DAL.Models.Usuario", b =>
                {
                    b.Property<long>("UsuarioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("UsuarioId"));

                    b.Property<long?>("ClienteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasDefaultValueSql("(NULL)");

                    b.Property<DateTime>("DataCadastro")
                        .ValueGeneratedOnAdd()
                        .HasPrecision(0)
                        .HasColumnType("datetime2(0)")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("NivelDeAcessoId")
                        .HasColumnType("int");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("UsuarioId")
                        .HasName("PK_Usuario_UsuarioId");

                    b.HasIndex("NivelDeAcessoId");

                    b.HasIndex(new[] { "Email" }, "Usuario$Email_UNIQUE")
                        .IsUnique();

                    b.HasIndex(new[] { "Login" }, "Usuario$Login_UNIQUE")
                        .IsUnique();

                    b.HasIndex(new[] { "ClienteId" }, "fk_Usuario_Cliente1_idx");

                    b.ToTable("Usuario", "fastbox-db");
                });

            modelBuilder.Entity("FastBox.DAL.Models.Veiculo", b =>
                {
                    b.Property<long>("VeiculoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("VeiculoId"));

                    b.Property<int>("Ano")
                        .HasColumnType("int");

                    b.Property<long?>("ClienteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasDefaultValueSql("(NULL)");

                    b.Property<string>("Marca")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Matricula")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Modelo")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Observacoes")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("VeiculoId")
                        .HasName("PK_Veiculo_VeiculoId");

                    b.HasIndex(new[] { "Matricula" }, "Veiculo$Matricula_UNIQUE")
                        .IsUnique();

                    b.HasIndex(new[] { "ClienteId" }, "fk_Veiculo_Cliente1_idx");

                    b.ToTable("Veiculo", "fastbox-db");
                });

            modelBuilder.Entity("FastBox.DAL.Models.Cliente", b =>
                {
                    b.HasOne("FastBox.DAL.Models.Endereco", "Endereco")
                        .WithOne("Cliente")
                        .HasForeignKey("FastBox.DAL.Models.Cliente", "EnderecoId")
                        .HasConstraintName("Cliente$fk_Cliente_Endereco");

                    b.Navigation("Endereco");
                });

            modelBuilder.Entity("FastBox.DAL.Models.Concelho", b =>
                {
                    b.HasOne("FastBox.DAL.Models.Distrito", "Distrito")
                        .WithMany("Concelhos")
                        .HasForeignKey("DistritoId")
                        .IsRequired()
                        .HasConstraintName("Concelho$fk_Concelho_Distrito");

                    b.Navigation("Distrito");
                });

            modelBuilder.Entity("FastBox.DAL.Models.Endereco", b =>
                {
                    b.HasOne("FastBox.DAL.Models.Concelho", "Concelho")
                        .WithMany("Enderecos")
                        .HasForeignKey("ConcelhoId")
                        .IsRequired()
                        .HasConstraintName("Endereco$fk_Endereco_Concelho");

                    b.Navigation("Concelho");
                });

            modelBuilder.Entity("FastBox.DAL.Models.EstoquePeca", b =>
                {
                    b.HasOne("FastBox.DAL.Models.Fornecedor", "Fornecedor")
                        .WithMany("EstoquePecas")
                        .HasForeignKey("FornecedorId")
                        .IsRequired()
                        .HasConstraintName("EstoquePeca$fk_EstoquePeca_Fornecedor");

                    b.Navigation("Fornecedor");
                });

            modelBuilder.Entity("FastBox.DAL.Models.Fornecedor", b =>
                {
                    b.HasOne("FastBox.DAL.Models.Endereco", "Endereco")
                        .WithOne("Fornecedor")
                        .HasForeignKey("FastBox.DAL.Models.Fornecedor", "EnderecoId")
                        .HasConstraintName("Fornecedor$fk_Fornecedor_Endereco");

                    b.Navigation("Endereco");
                });

            modelBuilder.Entity("FastBox.DAL.Models.ItemOrcamento", b =>
                {
                    b.HasOne("FastBox.DAL.Models.Fornecedor", "Fornecedor")
                        .WithMany("ItensOrcamento")
                        .HasForeignKey("FornecedorId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("ItemOrcamento$fk_ItemOrcamento_Fornecedor");

                    b.HasOne("FastBox.DAL.Models.Orcamento", "Orcamento")
                        .WithMany("ItensOrcamento")
                        .HasForeignKey("OrcamentoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("ItemOrcamento$fk_ItemOrcamento_Orcamento");

                    b.Navigation("Fornecedor");

                    b.Navigation("Orcamento");
                });

            modelBuilder.Entity("FastBox.DAL.Models.Orcamento", b =>
                {
                    b.HasOne("FastBox.DAL.Models.OrdemDeServico", "OrdemDeServico")
                        .WithMany("Orcamentos")
                        .HasForeignKey("OrdemDeServicoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("Orcamento$fk_Orcamento_OrdemDeServico");

                    b.Navigation("OrdemDeServico");
                });

            modelBuilder.Entity("FastBox.DAL.Models.OrdemDeServico", b =>
                {
                    b.HasOne("FastBox.DAL.Models.Cliente", "Cliente")
                        .WithMany("OrdemDeServicos")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.SetNull)
                        .HasConstraintName("OrdemDeServico$fk_OrdemDeServico_Cliente");

                    b.HasOne("FastBox.DAL.Models.StatusOrdemDeServico", "StatusOrdemDeServico")
                        .WithMany("OrdemDeServicos")
                        .HasForeignKey("StatusOrdemDeServicoId")
                        .IsRequired()
                        .HasConstraintName("OrdemDeServico$fk_OrdemDeServico_StatusOrdemDeServico");

                    b.HasOne("FastBox.DAL.Models.Veiculo", "Veiculo")
                        .WithMany("OrdemDeServicos")
                        .HasForeignKey("VeiculoId")
                        .HasConstraintName("OrdemDeServico$fk_OrdemDeServico_Veiculo");

                    b.Navigation("Cliente");

                    b.Navigation("StatusOrdemDeServico");

                    b.Navigation("Veiculo");
                });

            modelBuilder.Entity("FastBox.DAL.Models.Pagamento", b =>
                {
                    b.HasOne("FastBox.DAL.Models.MetodoPagamento", "MetodoPagamento")
                        .WithMany("Pagamentos")
                        .HasForeignKey("MetodoPagamentoId")
                        .IsRequired()
                        .HasConstraintName("Pagamento$fk_Pagamento_MetodoPagamento");

                    b.HasOne("FastBox.DAL.Models.OrdemDeServico", "OrdemDeServico")
                        .WithMany("Pagamentos")
                        .HasForeignKey("OrdemDeServicoId")
                        .IsRequired()
                        .HasConstraintName("Pagamento$fk_Pagamento_OrdemDeServico");

                    b.Navigation("MetodoPagamento");

                    b.Navigation("OrdemDeServico");
                });

            modelBuilder.Entity("FastBox.DAL.Models.Usuario", b =>
                {
                    b.HasOne("FastBox.DAL.Models.Cliente", "Cliente")
                        .WithMany("Usuarios")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("Usuario$fk_Usuario_Cliente");

                    b.HasOne("FastBox.DAL.Models.NivelDeAcesso", "NivelDeAcesso")
                        .WithMany("Usuarios")
                        .HasForeignKey("NivelDeAcessoId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("FK_Usuario_NivelDeAcesso");

                    b.Navigation("Cliente");

                    b.Navigation("NivelDeAcesso");
                });

            modelBuilder.Entity("FastBox.DAL.Models.Veiculo", b =>
                {
                    b.HasOne("FastBox.DAL.Models.Cliente", "Cliente")
                        .WithMany("Veiculos")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.SetNull)
                        .HasConstraintName("Veiculo$fk_Veiculo_Cliente");

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("FastBox.DAL.Models.Cliente", b =>
                {
                    b.Navigation("OrdemDeServicos");

                    b.Navigation("Usuarios");

                    b.Navigation("Veiculos");
                });

            modelBuilder.Entity("FastBox.DAL.Models.Concelho", b =>
                {
                    b.Navigation("Enderecos");
                });

            modelBuilder.Entity("FastBox.DAL.Models.Distrito", b =>
                {
                    b.Navigation("Concelhos");
                });

            modelBuilder.Entity("FastBox.DAL.Models.Endereco", b =>
                {
                    b.Navigation("Cliente");

                    b.Navigation("Fornecedor");
                });

            modelBuilder.Entity("FastBox.DAL.Models.Fornecedor", b =>
                {
                    b.Navigation("EstoquePecas");

                    b.Navigation("ItensOrcamento");
                });

            modelBuilder.Entity("FastBox.DAL.Models.MetodoPagamento", b =>
                {
                    b.Navigation("Pagamentos");
                });

            modelBuilder.Entity("FastBox.DAL.Models.NivelDeAcesso", b =>
                {
                    b.Navigation("Usuarios");
                });

            modelBuilder.Entity("FastBox.DAL.Models.Orcamento", b =>
                {
                    b.Navigation("ItensOrcamento");
                });

            modelBuilder.Entity("FastBox.DAL.Models.OrdemDeServico", b =>
                {
                    b.Navigation("Orcamentos");

                    b.Navigation("Pagamentos");
                });

            modelBuilder.Entity("FastBox.DAL.Models.StatusOrdemDeServico", b =>
                {
                    b.Navigation("OrdemDeServicos");
                });

            modelBuilder.Entity("FastBox.DAL.Models.Veiculo", b =>
                {
                    b.Navigation("OrdemDeServicos");
                });
#pragma warning restore 612, 618
        }
    }
}
