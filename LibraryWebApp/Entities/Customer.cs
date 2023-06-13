using Volo.Abp.Domain.Entities;
using Volo.Abp.Users;

namespace LibraryWebApp.Entities;

public class Customer : Entity<Guid>
{
    public required string Name { get; set; }

    public required Guid UserId { get; set; }
}