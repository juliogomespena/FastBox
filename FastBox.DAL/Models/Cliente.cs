using System;
using System.Collections.Generic;

namespace FastBox.DAL.Models;

public partial class Cliente
{
    public long ClienteId { get; set; }

    public string Nome { get; set; } = null!;

    public string Sobrenome { get; set; } = null!;

    public string Telemovel { get; set; } = null!;

    public string? Email { get; set; }

    public string Nif { get; set; } = null!;

    public long? EnderecoId { get; set; }

    public DateTime DataCadastro { get; set; }

    public virtual Endereco Endereco { get; set; } = null!;

    public virtual ICollection<OrdemDeServico> OrdemDeServicos { get; set; } = new List<OrdemDeServico>();

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();

    public virtual ICollection<Veiculo> Veiculos { get; set; } = new List<Veiculo>();
}
