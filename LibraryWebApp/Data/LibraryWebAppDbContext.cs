using LibraryWebApp.Entities;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Volo.Abp.FeatureManagement.EntityFrameworkCore;
using Volo.Abp.Identity;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.OpenIddict.EntityFrameworkCore;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Volo.Abp.TenantManagement.EntityFrameworkCore;

namespace LibraryWebApp.Data;

public class LibraryWebAppDbContext : AbpDbContext<LibraryWebAppDbContext>
{
    public DbSet<Book> Books { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Loan> Loans { get; set; }

    public LibraryWebAppDbContext(DbContextOptions<LibraryWebAppDbContext> options)
        : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        /* Include modules to your migration db context */

        builder.ConfigurePermissionManagement();
        builder.ConfigureSettingManagement();
        builder.ConfigureAuditLogging();
        builder.ConfigureIdentity();
        builder.ConfigureOpenIddict();
        builder.ConfigureFeatureManagement();
        builder.ConfigureTenantManagement();

        /* Configure your own entities here */

        builder.Entity<Book>(book =>
        {
            book.ConfigureByConvention();
            book.Property(b => b.Name).IsRequired().HasMaxLength(128);
        });

        builder.Entity<Customer>(customer =>
        {
            customer.ConfigureByConvention();
            customer.HasIndex(c => c.UserName);
            customer.Property(c => c.Name).IsRequired().HasMaxLength(50);
        });

        builder.Entity<Loan>(loan =>
        {
            loan.ConfigureByConvention();
            loan.HasIndex(l => new { l.CustomerId, l.BookId });

            loan.HasOne<Customer>().WithMany().HasForeignKey(l => l.CustomerId).IsRequired();
            loan.HasOne<Book>().WithMany().HasForeignKey(b => b.BookId).IsRequired();
        });
    }
}
