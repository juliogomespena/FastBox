using Microsoft.EntityFrameworkCore;
using FastBox.DAL.Models;

namespace FastBox.DAL;

public partial class FastBoxDbContext : DbContext
{
    public FastBoxDbContext(DbContextOptions<FastBoxDbContext> options)
            : base(options)
    {
    }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Concelho> Concelhos { get; set; }

    public virtual DbSet<Distrito> Distritos { get; set; }

    public virtual DbSet<Endereco> Enderecos { get; set; }

    public virtual DbSet<EstoquePeca> EstoquePecas { get; set; }

    public virtual DbSet<Fornecedor> Fornecedors { get; set; }

    public virtual DbSet<ItemOrcamento> ItemOrcamentos { get; set; }
    public virtual DbSet<Orcamento> Orcamentos { get; set; }

    public virtual DbSet<MetodoPagamento> MetodoPagamentos { get; set; }

    public virtual DbSet<OrdemDeServico> OrdemDeServicos { get; set; }

    public virtual DbSet<Pagamento> Pagamentos { get; set; }

    public virtual DbSet<StatusOrdemDeServico> StatusOrdemDeServicos { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<Veiculo> Veiculos { get; set; }

    public virtual DbSet<NivelDeAcesso> NivelDeAcessos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.ClienteId).HasName("PK_Cliente_ClienteId");

            entity.ToTable("Cliente", "fastbox-db", tb => tb.HasTrigger("Cliente_AFTER_DELETE_AfterDelete"));

            entity.HasIndex(e => e.EnderecoId, "Cliente$EnderecoId_UNIQUE").IsUnique();

            entity.HasIndex(e => e.Nif, "Cliente$Nif_UNIQUE").IsUnique();

            entity.HasIndex(e => new { e.Nome, e.Sobrenome }, "Cliente$Nome_Sobrenome_UNIQUE").IsUnique();

            entity.HasIndex(e => e.EnderecoId, "fk_Cliente_Endereco_idx");

            entity.Property(e => e.DataCadastro)
                .HasPrecision(0)
                .HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasDefaultValueSql("(NULL)");
            entity.Property(e => e.Nif).HasMaxLength(50);
            entity.Property(e => e.Nome).HasMaxLength(45);
            entity.Property(e => e.Sobrenome).HasMaxLength(100);
            entity.Property(e => e.Telemovel).HasMaxLength(30);

            entity.HasOne(d => d.Endereco).WithOne(p => p.Cliente)
                .HasForeignKey<Cliente>(d => d.EnderecoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Cliente$fk_Cliente_Endereco");
        });

        modelBuilder.Entity<Concelho>(entity =>
        {
            entity.HasKey(e => e.ConcelhoId).HasName("PK_Concelho_ConcelhoId");

            entity.ToTable("Concelho", "fastbox-db");

            entity.HasIndex(e => e.DistritoId, "fk_Concelho_Distrito1_idx");

            entity.Property(e => e.Nome).HasMaxLength(100);

            entity.HasOne(d => d.Distrito).WithMany(p => p.Concelhos)
                .HasForeignKey(d => d.DistritoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Concelho$fk_Concelho_Distrito1");
        });

        modelBuilder.Entity<Distrito>(entity =>
        {
            entity.HasKey(e => e.DistritoId).HasName("PK_Distrito_DistritoId");

            entity.ToTable("Distrito", "fastbox-db");

            entity.Property(e => e.Nome).HasMaxLength(100);

            entity.HasMany(d => d.Concelhos).WithOne(c => c.Distrito)
            .HasForeignKey(c => c.DistritoId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("Concelho$fk_Concelho_Distrito");
        });

        modelBuilder.Entity<Endereco>(entity =>
        {
            entity.HasKey(e => e.EnderecoId).HasName("PK_Endereco_EnderecoId");

            entity.ToTable("Endereco", "fastbox-db");

            entity.HasIndex(e => e.ConcelhoId, "fk_Endereco_Concelho1_idx");

            entity.Property(e => e.CodigoPostal).HasMaxLength(10);
            entity.Property(e => e.Complemento)
                .HasMaxLength(50)
                .HasDefaultValueSql("(NULL)");
            entity.Property(e => e.Freguesia).HasMaxLength(100);
            entity.Property(e => e.Logradouro).HasMaxLength(255);
            entity.Property(e => e.Numero).HasMaxLength(50);
            entity.Property(e => e.Pais)
                .HasMaxLength(100)
                .HasDefaultValue("Portugal");

            entity.HasOne(d => d.Concelho).WithMany(p => p.Enderecos)
                .HasForeignKey(d => d.ConcelhoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Endereco$fk_Endereco_Concelho");
        });

        modelBuilder.Entity<EstoquePeca>(entity =>
        {
            entity.HasKey(e => e.EstoquePecaId).HasName("PK_EstoquePeca_EstoquePecaId");

            entity.ToTable("EstoquePeca", "fastbox-db");

            entity.HasIndex(e => e.FornecedorId, "fk_EstoquePeca_Fornecedor1_idx");

            entity.Property(e => e.Margem).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.Nome).HasMaxLength(255);
            entity.Property(e => e.PrecoUnitario).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.Fornecedor).WithMany(p => p.EstoquePecas)
                .HasForeignKey(d => d.FornecedorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("EstoquePeca$fk_EstoquePeca_Fornecedor");
        });

        modelBuilder.Entity<Fornecedor>(entity =>
        {
            entity.HasKey(e => e.FornecedorId).HasName("PK_Fornecedor_FornecedorId");

            entity.ToTable("Fornecedor", "fastbox-db", tb => tb.HasTrigger("Fornecedor_AFTER_DELETE_AfterDelete"));

            entity.HasIndex(e => e.EnderecoId, "Fornecedor$EnderecoId_UNIQUE").IsUnique();

            entity.HasIndex(e => e.Nome, "Fornecedor$Nome_UNIQUE").IsUnique();

            entity.HasIndex(e => e.EnderecoId, "fk_Fornecedor_Endereco1_idx");

            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasDefaultValueSql("(NULL)");
            entity.Property(e => e.Nome).HasMaxLength(255);
            entity.Property(e => e.Telemovel).HasMaxLength(30);

            entity.HasOne(d => d.Endereco).WithOne(p => p.Fornecedor)
                .HasForeignKey<Fornecedor>(d => d.EnderecoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Fornecedor$fk_Fornecedor_Endereco");
        });

        modelBuilder.Entity<ItemOrcamento>(entity =>
        {
            entity.HasKey(e => e.ItemOrcamentoId).HasName("PK_ItemOrcamento_ItemOrcamentoId");

            entity.ToTable("ItemOrcamento", "fastbox-db");

            entity.HasIndex(e => e.OrcamentoId, "fk_ItemOrcamento_Orcamento1_idx");

            entity.Property(e => e.Descricao).HasMaxLength(255);
            entity.Property(e => e.PrecoUnitario).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Margem).HasColumnType("decimal(10, 5)");

            entity.HasOne(d => d.Orcamento).WithMany(p => p.ItensOrcamento)
                .HasForeignKey(d => d.OrcamentoId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("ItemOrcamento$fk_ItemOrcamento_Orcamento");

            entity.HasOne(d => d.Fornecedor).WithMany(p => p.ItensOrcamento)
                .HasForeignKey(d => d.FornecedorId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("ItemOrcamento$fk_ItemOrcamento_Fornecedor");
        });

        modelBuilder.Entity<Orcamento>(entity =>
        {
            entity.HasKey(e => e.OrcamentoId).HasName("PK_Orcamento_OrcamentoId");

            entity.ToTable("Orcamento", "fastbox-db");

            entity.HasIndex(e => e.OrdemDeServicoId, "fk_Orcamento_OrdemDeServico1_idx");

            entity.Property(e => e.DataCriacao).HasPrecision(0).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Descricao).HasMaxLength(255);

            entity.HasOne(d => d.OrdemDeServico).WithMany(p => p.Orcamentos)
                .HasForeignKey(d => d.OrdemDeServicoId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("Orcamento$fk_Orcamento_OrdemDeServico");
        });

        modelBuilder.Entity<MetodoPagamento>(entity =>
        {
            entity.HasKey(e => e.MetodoPagamentoId).HasName("PK_MetodoPagamento_MetodoPagamentoId");

            entity.ToTable("MetodoPagamento", "fastbox-db");

            entity.Property(e => e.MetodoPagamentoId).ValueGeneratedNever();
            entity.Property(e => e.Nome).HasMaxLength(45);
            entity.HasData(
                new MetodoPagamento { MetodoPagamentoId = 1, Nome = "MULTIBANCO" },
                new MetodoPagamento { MetodoPagamentoId = 2, Nome = "MBWAY STD" },
                new MetodoPagamento { MetodoPagamentoId = 3, Nome = "MBWAY NB" },
                new MetodoPagamento { MetodoPagamentoId = 4, Nome = "NUMERÁRIO" });
    });

        modelBuilder.Entity<OrdemDeServico>(entity =>
        {
            entity.HasKey(e => e.OrdemDeServicoId).HasName("PK_OrdemDeServico_OrdemDeServicoId");

            entity.ToTable("OrdemDeServico", "fastbox-db");

            entity.HasIndex(e => e.ClienteId, "fk_OrdemDeServico_Cliente1_idx");

            entity.HasIndex(e => e.StatusOrdemDeServicoId, "fk_OrdemDeServico_StatusOrdemDeServico1_idx");

            entity.HasIndex(e => e.VeiculoId, "fk_OrdemDeServico_Veiculo1_idx");

            entity.Property(e => e.ClienteId).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.DataAbertura)
                .HasPrecision(0)
                .HasDefaultValueSql("(getdate())");
            entity.Property(e => e.EstimativaConclusao)
                .HasPrecision(0)
                .HasDefaultValueSql("(NULL)");
            entity.Property(e => e.DataConclusao)
                .HasPrecision(0)
                .HasDefaultValueSql("(NULL)");
            entity.Property(e => e.ValorTotal).HasColumnType("decimal(10, 2)")
                .HasDefaultValueSql("(NULL)");
            entity.Property(e => e.IncluirIva)
            .HasDefaultValue(false);
            entity.Property(e => e.Descricao).HasMaxLength(255);
            entity.Property(e => e.DataGarantia).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.ObservacoesGarantia).HasMaxLength(255);
            entity.Property(e => e.VeiculoId).HasDefaultValueSql("(NULL)");

            entity.HasOne(d => d.Cliente).WithMany(p => p.OrdemDeServicos)
                .HasForeignKey(d => d.ClienteId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("OrdemDeServico$fk_OrdemDeServico_Cliente");

            entity.HasOne(d => d.StatusOrdemDeServico).WithMany(p => p.OrdemDeServicos)
                .HasForeignKey(d => d.StatusOrdemDeServicoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("OrdemDeServico$fk_OrdemDeServico_StatusOrdemDeServico");

            entity.HasOne(d => d.Veiculo).WithMany(p => p.OrdemDeServicos)
                .HasForeignKey(d => d.VeiculoId)
                .HasConstraintName("OrdemDeServico$fk_OrdemDeServico_Veiculo");
        });

        modelBuilder.Entity<Pagamento>(entity =>
        {
            entity.HasKey(e => e.PagamentoId).HasName("PK_Pagamento_PagamentoId");

            entity.ToTable("Pagamento", "fastbox-db");

            entity.HasIndex(e => e.MetodoPagamentoId, "fk_Pagamento_MetodoPagamento1_idx");

            entity.HasIndex(e => e.OrdemDeServicoId, "fk_Pagamento_OrdemDeServico1_idx");

            entity.Property(e => e.DataPagamento)
                .HasPrecision(0)
                .HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Valor).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.MetodoPagamento).WithMany(p => p.Pagamentos)
                .HasForeignKey(d => d.MetodoPagamentoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Pagamento$fk_Pagamento_MetodoPagamento");

            entity.HasOne(d => d.OrdemDeServico).WithMany(p => p.Pagamentos)
                .HasForeignKey(d => d.OrdemDeServicoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Pagamento$fk_Pagamento_OrdemDeServico");
        });

        modelBuilder.Entity<StatusOrdemDeServico>(entity =>
        {
            entity.HasKey(e => e.StatusOrdemDeServicoId).HasName("PK_StatusOrdemDeServico_StatusOrdemDeServicoId");

            entity.ToTable("StatusOrdemDeServico", "fastbox-db");

            entity.HasIndex(e => e.StatusOrdemDeServicoId, "StatusOrdemDeServico$StatusOrdemDeServicoId_UNIQUE").IsUnique();

            entity.Property(e => e.StatusOrdemDeServicoId).ValueGeneratedNever();
            entity.Property(e => e.Descricao).HasMaxLength(60);
            entity.Property(e => e.Nome).HasMaxLength(30);
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.UsuarioId).HasName("PK_Usuario_UsuarioId");

            entity.ToTable("Usuario", "fastbox-db");

            entity.HasIndex(e => e.Email, "Usuario$Email_UNIQUE").IsUnique();

            entity.HasIndex(e => e.Login, "Usuario$Login_UNIQUE").IsUnique();

            entity.HasIndex(e => e.ClienteId, "fk_Usuario_Cliente1_idx");

            entity.Property(e => e.ClienteId).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.DataCadastro)
                .HasPrecision(0)
                .HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.Login).HasMaxLength(255);
            entity.Property(e => e.Senha).HasMaxLength(255);

            entity.HasOne(d => d.Cliente).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.ClienteId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("Usuario$fk_Usuario_Cliente");

            entity.HasOne(d => d.NivelDeAcesso)
                .WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.NivelDeAcessoId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_Usuario_NivelDeAcesso");
        });

        modelBuilder.Entity<Veiculo>(entity =>
        {
            entity.HasKey(e => e.VeiculoId).HasName("PK_Veiculo_VeiculoId");

            entity.ToTable("Veiculo", "fastbox-db");

            entity.HasIndex(e => e.Matricula, "Veiculo$Matricula_UNIQUE").IsUnique();

            entity.HasIndex(e => e.ClienteId, "fk_Veiculo_Cliente1_idx");

            entity.Property(e => e.ClienteId).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.Marca).HasMaxLength(100);
            entity.Property(e => e.Matricula).HasMaxLength(20);
            entity.Property(e => e.Modelo).HasMaxLength(100);
            entity.Property(e => e.Observacoes).HasMaxLength(255);

            entity.HasOne(d => d.Cliente).WithMany(p => p.Veiculos)
                .HasForeignKey(d => d.ClienteId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("Veiculo$fk_Veiculo_Cliente");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}