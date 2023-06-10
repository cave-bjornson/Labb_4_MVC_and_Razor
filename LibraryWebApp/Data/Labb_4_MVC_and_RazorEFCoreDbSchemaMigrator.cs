using Microsoft.EntityFrameworkCore;
using Volo.Abp.DependencyInjection;

namespace Labb_4_MVC_and_Razor.Data;

public class Labb_4_MVC_and_RazorEFCoreDbSchemaMigrator : ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public Labb_4_MVC_and_RazorEFCoreDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolving the Labb_4_MVC_and_RazorDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<Labb_4_MVC_and_RazorDbContext>()
            .Database
            .MigrateAsync();
    }
}
