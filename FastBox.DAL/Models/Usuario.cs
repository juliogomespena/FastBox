using System;
using System.Collections.Generic;

namespace FastBox.DAL.Models;

public partial class Usuario
{
    public long UsuarioId { get; set; }

    public string Login { get; set; } = null!;

    public string Senha { get; set; } = null!;

    public string Email { get; set; } = null!;

    public DateTime DataCadastro { get; set; }

    public long? ClienteId { get; set; }

    public virtual Cliente? Cliente { get; set; }
    public int NivelDeAcessoId { get; set; }
    public NivelDeAcesso NivelDeAcesso { get; set; } = null!;
}
