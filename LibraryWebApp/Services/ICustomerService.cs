using LibraryWebApp.Services.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace LibraryWebApp.Services;

public interface ICustomerService
    : ICrudAppService<
        CustomerDto,
        Guid,
        PagedAndSortedResultRequestDto,
        CreateUpdateCustomerDto
    > { }
