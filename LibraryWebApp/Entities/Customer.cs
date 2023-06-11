using Volo.Abp.Domain.Entities;

namespace LibraryWebApp.Entities;

public class Customer : Entity<Guid>
{
    public required string Name { get; set; }
}