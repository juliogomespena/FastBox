using FastBox.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastBox.BLL.DTOs;

public class OrdemDeServicoViewModel
{
    public long OrdemDeServicoId { get; set; }

    public long StatusOrdemDeServicoId { get; set; }

    public string Status => StatusOrdemDeServico.Descricao;

    public long? ClienteId { get; set; }

    public string? NomeCliente => Cliente == null ? "Não cadastrado" : $"{Cliente.Nome} {Cliente.Sobrenome}";

    public long? VeiculoId { get; set; }

    public string? ModeloMatricula => Veiculo == null ? "Não cadastrado" : $"{Veiculo.Modelo} ({Veiculo.Matricula})";

    public string Descricao { get; set; } = null!;

    public DateTime DataAbertura { get; set; }

    public DateTime? EstimativaConclusao { get; set; }

    public DateTime? DataConclusao { get; set; }

    public int? GarantiaEmDias { get; set; }

    public string? ObservacoesGarantia { get; set; }

    public virtual Cliente? Cliente { get; set; }

    public virtual ICollection<Orcamento> Orcamentos { get; set; } = new List<Orcamento>();

    public virtual ICollection<Pagamento> Pagamentos { get; set; } = new List<Pagamento>();

    public virtual StatusOrdemDeServico StatusOrdemDeServico { get; set; } = null!;

    public virtual Veiculo? Veiculo { get; set; }
}
