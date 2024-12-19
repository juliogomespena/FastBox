using System;
using System.Collections.Generic;

namespace FastBox.DAL.Models;

public class FornecedorViewModel
{
    private string? _email;

    public long FornecedorId { get; set; }

    public string Nome { get; set; } = null!;

    public string Telemovel { get; set; } = null!;

    public string? Email
    {
        get
        {
            return String.IsNullOrWhiteSpace(_email) ? "Não cadastrado" : _email;
        }
        set
        {
            _email = value;
        }
    }

    public long? EnderecoId { get; set; }

    public virtual Endereco? Endereco { get; set; } = null!;

    public string? EnderecoResumido => Endereco == null ? "Não cadastrado" : $"{Endereco.Logradouro}, {Endereco.Numero}";

    public string? EnderecoCompleto => Endereco == null ? "Não cadastrado" : $"{Endereco.Logradouro}, {Endereco.Numero}, {(!string.IsNullOrWhiteSpace(Endereco.Complemento) ? Endereco.Complemento : "Sem complemento")}, {Endereco.Freguesia}, Concelho: {Endereco.Concelho.Nome}, Distrito: {Endereco.Concelho.Distrito.Nome}, {Endereco.CodigoPostal}, {Endereco.Pais}";

    public string? InfoFornecedor => $"Id: {FornecedorId} - {Nome} - {Telemovel} - {Email}";

    public virtual ICollection<EstoquePeca> EstoquePecas { get; set; } = new List<EstoquePeca>();

    public ICollection<ItemOrcamento> ItensOrcamento { get; set; } = new List<ItemOrcamento>();
}
