using Microsoft.EntityFrameworkCore;
using Volo.Abp.DependencyInjection;

namespace LibraryWebApp.Data;

public class LibraryWebAppEFCoreDbSchemaMigrator : ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public LibraryWebAppEFCoreDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolving the LibraryWebAppDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<LibraryWebAppDbContext>()
            .Database
            .MigrateAsync();
    }
}
