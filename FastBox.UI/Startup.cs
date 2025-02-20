using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using FastBox.DAL;
using FastBox.DAL.Repositories;
using FastBox.BLL.Services;
using FastBox.BLL.Services.Interfaces;
using FastBox.UI.Forms;
using FastBox.DAL.Models;
using FastBox.UI.Helper;

namespace FastBox.UI;

internal class Startup
{
    public static ServiceProvider ConfigureServices(string connectionString)
    {
        var services = new ServiceCollection();

        services.AddDbContext<FastBoxDbContext>(options =>
        {
			if (GlobalConfiguration.IsDevelopment)
				options.UseSqlServer(connectionString);
			else
				options.UseAzureSql(connectionString);
		}, ServiceLifetime.Scoped);

        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        services.AddScoped<IClienteService, ClienteService>();
        services.AddScoped<IUsuarioService, UsuarioService>();
        services.AddScoped<IConcelhoService, ConcelhoService>();
        services.AddScoped<IEnderecoService, EnderecoService>();
        services.AddScoped<IVeiculoService, VeiculoService>();
        services.AddScoped<IOrdemDeServicoService, OrdemDeServicoService>();
        services.AddScoped<IStatusOrdemDeServicoService, StatusOrdemDeServicoService>();
        services.AddScoped<IFornecedorService, FornecedorService>();
        services.AddScoped<IPagamentoService, PagamentoService>();

        services.AddTransient<FormLogin>();
        services.AddTransient<FormDashboard>();
        services.AddTransient<FormSummary>();
        services.AddTransient<FormClientes>();
        services.AddTransient<FormCadastrarCliente>();
        services.AddTransient<FormAtualizarCliente>();
        services.AddTransient<FormVeiculos>();
        services.AddTransient<FormCadastrarVeiculo>();
        services.AddTransient<FormAtualizarVeiculo>();
        services.AddTransient<FormOrdensDeServico>();
        services.AddTransient<FormCadastrarOrdem>();
        services.AddTransient<FormCadastrarOrcamento>();
        services.AddTransient<FormAtualizarOrcamento>();
        services.AddTransient<FormAtualizarOrdem>();        
        services.AddTransient<FormFornecedores>();
        services.AddTransient<FormCadastrarFornecedor>();
        services.AddTransient<FormAtualizarFornecedor>();
        services.AddTransient<FormConcluirOrdem>();
		services.AddTransient<FormRelatorio>();

		return services.BuildServiceProvider();
    }
}
