using LibraryWebApp.Shared;
using Volo.Abp.Application.Dtos;

namespace LibraryWebApp.Services.Dtos;

public class BookDto : EntityDto<Guid>
{
    public required string Name { get; set; }
    
    public required BookType Type { get; set; }
    
    public required DateTime PublishDate { get; set; }
}