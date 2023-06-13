using LibraryWebApp.Entities;
using LibraryWebApp.Permissions;
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
    >,
        ICustomerService
{
    /// <inheritdoc />
    public CustomerService(IRepository<Customer, Guid> repository)
        : base(repository)
    {
        GetPolicyName = LibraryPermissions.Customers.Default;
        GetListPolicyName = LibraryPermissions.Customers.Default;
        CreatePolicyName = LibraryPermissions.Customers.Create;
        UpdatePolicyName = LibraryPermissions.Customers.Edit;
        DeletePolicyName = LibraryPermissions.Customers.Delete;
    }
}
