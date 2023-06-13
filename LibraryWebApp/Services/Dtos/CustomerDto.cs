using Volo.Abp.Application.Dtos;

namespace LibraryWebApp.Services.Dtos;

public class CustomerDto : EntityDto<Guid>
{
    public required string UserName { get; set; }
    public required string Name { get; set; }
    
    public required string Surname { get; set; }
}
