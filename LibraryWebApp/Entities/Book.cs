using Volo.Abp.Domain.Entities;

namespace Labb_4_MVC_and_Razor.Entities;

public class Book : Entity<Guid>
{
    public string Name { get; set; }
    
    public DateTime PublishDate { get; set; }
}