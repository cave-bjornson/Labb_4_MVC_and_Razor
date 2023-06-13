using Volo.Abp.Domain.Entities;
using Volo.Abp.Users;

namespace LibraryWebApp.Entities;

public class Customer : Entity<Guid>
{
    public required string UserName { get; set; }
    public required string Name { get; set; }

    public required string Surname { get; set; }
}