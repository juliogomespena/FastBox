using FastBox.BLL.Services;
using FastBox.DAL;
using FastBox.UI.Helper;
using Microsoft.Extensions.DependencyInjection;
using System.Drawing.Text;
using System.Globalization;

namespace FastBox.UI;

internal static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        var cultureInfo = new CultureInfo("pt-PT");

        Thread.CurrentThread.CurrentCulture = cultureInfo;
        Thread.CurrentThread.CurrentUICulture = cultureInfo;

        CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
        CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;

        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);

        var serviceProvider = Startup.ConfigureServices(GlobalConfiguration.connectionString);
        var formPrincipal = serviceProvider.GetRequiredService<FormLogin>();

        Application.Run(formPrincipal);
    }


}