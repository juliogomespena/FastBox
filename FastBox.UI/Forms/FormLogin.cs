using FastBox.BLL.Services.Interfaces;
using FastBox.DAL.Models;
using FastBox.UI.Helper;
using Microsoft.Extensions.DependencyInjection;

namespace FastBox.UI;

public partial class FormLogin : Form
{
    private readonly IUsuarioService _userService;
    private readonly IServiceProvider _serviceProvider;

    public FormLogin(IUsuarioService userService, IServiceProvider serviceProvider)
    {
        InitializeComponent();

        _userService = userService;
        this.AcceptButton = BtnEntrar;
        _serviceProvider = serviceProvider;
    }

    private async void btnEntrar_Click(object sender, EventArgs e)
    {
        Usuario user = new Usuario
        {
            Login = "fastboxadm",
            Email = "fastboxsetubal@gmail.com",
            Senha = "gabi#1957",
            DataCadastro = DateTime.Now,
            NivelDeAcessoId = 3,
        };
        try
        {
            BtnEntrar.Enabled = false;
            string loginOrEmail = TxtLogin.Text.Trim();
            string password = TxtPassword.Text;

            var usuario = await _userService.ValidateLoginAsync(loginOrEmail, password);

            Session.Initiate(usuario);

            var frmDashboard = _serviceProvider.GetRequiredService<FormDashboard>();
            this.Hide();
        }
        catch (UnauthorizedAccessException)
        {
            MessageBox.Show("Usuário ou senha incorretos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Erro: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            BtnEntrar.Enabled = true;
        }
    }

    private void FormDashboard_FormClosing(object sender, FormClosingEventArgs e)
    {
        if (!Session.ActiveSession())
            this.Show();
    }

    private void FormLogin_FormClosing(object sender, FormClosingEventArgs e)
    {
        Environment.Exit(0);
    }
}
