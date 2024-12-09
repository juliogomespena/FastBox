using FastBox.UI.Helper;
using Microsoft.Extensions.DependencyInjection;

namespace FastBox.UI
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            string connectionString = Configuration.GetConnectionString("FastBoxDbConnection");
            var serviceProvider = Startup.ConfigureServices(connectionString);
            var formPrincipal = serviceProvider.GetRequiredService<FormLogin>();

            Application.Run(formPrincipal);
        }
    }
}