using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace FastBox.DAL;

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<FastBoxDbContext>
{
    public FastBoxDbContext CreateDbContext(string[] args)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../FastBox.UI/Helper"))
            .AddJsonFile("appsettings.json")
            .Build();

        var connectionString = configuration.GetConnectionString("LocalDbConnection");

        var optionsBuilder = new DbContextOptionsBuilder<FastBoxDbContext>();
        optionsBuilder.UseSqlServer(connectionString);

        return new FastBoxDbContext(optionsBuilder.Options);
    }
}
