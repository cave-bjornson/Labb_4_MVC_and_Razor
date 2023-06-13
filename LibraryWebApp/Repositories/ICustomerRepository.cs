using LibraryWebApp.Entities;
using Volo.Abp.Domain.Repositories;

namespace LibraryWebApp.Repositories;

public interface ICustomerRepository : IRepository<Customer, Guid>
{
    
}