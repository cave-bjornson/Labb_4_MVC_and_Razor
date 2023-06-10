using Microsoft.EntityFrameworkCore;
using Volo.Abp.DependencyInjection;

namespace LibraryWebApp.Data;

public class LibraryEFCoreDbSchemaMigrator : ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public LibraryEFCoreDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolving the LibraryDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<LibraryDbContext>()
            .Database
            .MigrateAsync();
    }
}
