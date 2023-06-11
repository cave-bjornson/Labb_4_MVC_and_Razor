using Volo.Abp.Application.Dtos;

namespace LibraryWebApp.Services.Dtos;

public class CustomerDto : EntityDto<Guid>
{
    public required string Name { get; set; }
}
