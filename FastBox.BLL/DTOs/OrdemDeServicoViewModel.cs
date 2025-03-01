﻿using FastBox.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastBox.BLL.DTOs;

public class OrdemDeServicoViewModel
{
    private DateTime? _dataGarantia;
    private string? _observacoesGarantia;

    public long OrdemDeServicoId { get; set; }

    public long StatusOrdemDeServicoId { get; set; }

    public string Status => StatusOrdemDeServico.Nome;

    public long? ClienteId { get; set; }

    public string? NomeCliente => Cliente == null ? "Não cadastrado" : $"{Cliente.Nome} {Cliente.Sobrenome}";

    public long? VeiculoId { get; set; }

    public string? ModeloMatricula => Veiculo == null ? "Não cadastrado" : $"{Veiculo.Modelo} ({Veiculo.Matricula})";

    public string Descricao { get; set; } = null!;

    public DateTime DataAbertura { get; set; }

    public DateTime? EstimativaConclusao { get; set; }

    public DateTime? DataConclusao { get; set; }

    public string DataGarantiaStatus => StatusOrdemDeServicoId == 7 ? "Cancelada" : DataGarantia != null ? DataGarantia.Value.ToString("d") : "Aguardando conclusão";

    public string? ObservacoesGarantia 
    {
        get
        {
            return String.IsNullOrWhiteSpace(_observacoesGarantia) ? "Sem observações" : _observacoesGarantia;
        }
        set
        {
            _observacoesGarantia = value;
        }
    }

    public DateTime? DataGarantia { get; set; }

    public decimal? ValorTotal { get; set; }

    public string? ValorPago => StatusOrdemDeServicoId == 7 ? "Cancelada" : Pagamentos.Any() ? Pagamentos.Sum(p => p.Valor).ToString("C2") : "Aguardando conclusão";

    public decimal? ValorPagoDecimal => Pagamentos.Any() ? Pagamentos.Sum(p => p.Valor) : 0;

	public string? ValorDevido => StatusOrdemDeServicoId == 7 ? "Cancelada" : Pagamentos.Any() ? (ValorTotal - Pagamentos.Sum(p => p.Valor))?.ToString("C2") : "Aguardando conclusão";

    public decimal? ValorDevidoDecimal => Pagamentos.Any() ? (ValorTotal - Pagamentos.Sum(p => p.Valor)) : 0;

	public decimal? MaoDeObra => Orcamentos.Count != 0 ? Orcamentos.Select(orcamento => orcamento.ItensOrcamento.Where(item => item.Descricao == "Mão de obra")).Sum(item => item.Sum(i => i.PrecoUnitario * (decimal)i.Quantidade)) : 0;

	public decimal? Pecas => Orcamentos.Count != 0 ? Orcamentos.Select(orcamento => orcamento.ItensOrcamento.Where(item => item.Descricao != "Mão de obra")).Sum(item => item.Sum(i => i.PrecoUnitario * (decimal)i.Quantidade)) : 0;

    public decimal? LucroPecas => IncluirIva ? (ValorTotal / (decimal)1.23) - MaoDeObra - Pecas : ValorTotal - MaoDeObra - Pecas;

	public decimal? Lucro => IncluirIva ? (ValorTotal/(decimal)1.23) - Pecas : ValorTotal - Pecas;

	public virtual Cliente? Cliente { get; set; }

    public virtual ICollection<Orcamento> Orcamentos { get; set; } = new List<Orcamento>();

    public virtual ICollection<Pagamento> Pagamentos { get; set; } = new List<Pagamento>();

    public virtual StatusOrdemDeServico StatusOrdemDeServico { get; set; } = null!;

    public virtual Veiculo? Veiculo { get; set; }

    public bool IncluirIva {  get; set; }
}
