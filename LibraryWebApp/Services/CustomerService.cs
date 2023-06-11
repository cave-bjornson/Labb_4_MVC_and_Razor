using LibraryWebApp.Entities;
using LibraryWebApp.Services.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace LibraryWebApp.Services;

public class CustomerService
    : CrudAppService<
        Customer,
        CustomerDto,
        Guid,
        PagedAndSortedResultRequestDto,
        CreateUpdateCustomerDto
    >
{
    /// <inheritdoc />
    public CustomerService(IRepository<Customer, Guid> repository)
        : base(repository) { }
}
