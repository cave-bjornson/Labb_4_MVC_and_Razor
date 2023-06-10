using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Labb_4_MVC_and_Razor.Data;

public class Labb_4_MVC_and_RazorDbContextFactory : IDesignTimeDbContextFactory<Labb_4_MVC_and_RazorDbContext>
{
    public Labb_4_MVC_and_RazorDbContext CreateDbContext(string[] args)
    {

        var configuration = BuildConfiguration();

        var builder = new DbContextOptionsBuilder<Labb_4_MVC_and_RazorDbContext>()
            .UseSqlite(configuration.GetConnectionString("Default"));

        return new Labb_4_MVC_and_RazorDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}
