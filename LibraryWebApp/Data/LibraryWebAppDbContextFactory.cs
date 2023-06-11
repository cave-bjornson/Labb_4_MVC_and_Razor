using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace LibraryWebApp.Data;

public class LibraryWebAppDbContextFactory : IDesignTimeDbContextFactory<LibraryWebAppDbContext>
{
    public LibraryWebAppDbContext CreateDbContext(string[] args)
    {

        var configuration = BuildConfiguration();

        var builder = new DbContextOptionsBuilder<LibraryWebAppDbContext>()
            .UseSqlite(configuration.GetConnectionString("Default"));

        return new LibraryWebAppDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}
