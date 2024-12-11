using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using FastBox.DAL;
using FastBox.DAL.Repositories;
using FastBox.BLL.Services;
using FastBox.BLL.Services.Interfaces;
using FastBox.UI.Forms;

namespace FastBox.UI;

internal class Startup
{
    public static ServiceProvider ConfigureServices(string connectionString)
    {
        var services = new ServiceCollection();

        services.AddDbContext<FastBoxDbContext>(options => options.UseAzureSql(connectionString));

        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        services.AddScoped<IClienteService, ClienteService>();
        services.AddScoped<IUsuarioService, UsuarioService>();
        services.AddScoped<IConcelhoService, ConcelhoService>();
        services.AddScoped<IEnderecoService, EnderecoService>();

        services.AddTransient<FormLogin>();
        services.AddTransient<FormDashboard>();
        services.AddTransient<FormClientes>();
        services.AddTransient<FormOrdensDeServico>();
        services.AddTransient<FormRelatorios>();
        services.AddTransient<FormSummary>();
        services.AddTransient<FormVeiculos>();
        services.AddTransient<FormCadastrarCliente>();
        services.AddTransient<FormAtualizarCliente>();

        return services.BuildServiceProvider();

    }
}
