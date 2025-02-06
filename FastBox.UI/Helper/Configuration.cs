using Microsoft.Extensions.Configuration;

namespace FastBox.UI.Helper;

internal class Configuration
{
    public static IConfigurationRoot GetConfiguration()
    {
        return new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("Helper/appsettings.json", optional: false, reloadOnChange: true)
            .Build();
    }

    public static string GetConnectionString(string name)
    {
        var configuration = GetConfiguration();

        return configuration.GetConnectionString(name);
    }
}
