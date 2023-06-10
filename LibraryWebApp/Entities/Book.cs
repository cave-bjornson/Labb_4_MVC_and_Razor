using Volo.Abp.Domain.Entities;

namespace LibraryWebApp.Entities;

public class Book : Entity<Guid>
{
    public string Name { get; set; }
    
    public DateTime PublishDate { get; set; }
}