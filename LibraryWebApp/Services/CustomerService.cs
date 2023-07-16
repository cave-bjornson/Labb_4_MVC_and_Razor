using System.Linq.Dynamic.Core;
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

    /// <inheritdoc />
    public async Task<List<string>> GetCustomerUserNames()
    {
        var queryable = await ReadOnlyRepository.GetQueryableAsync();

        var query = queryable.Select(customer => customer.UserName);

        return await AsyncExecuter.ToListAsync(query);
    }
}
