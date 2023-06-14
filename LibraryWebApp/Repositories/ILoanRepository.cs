using LibraryWebApp.Entities;
using LibraryWebApp.Services.Dtos;
using Volo.Abp.Domain.Repositories;

namespace LibraryWebApp.Repositories;

public interface ILoanRepository : IRepository<Loan, Guid>
{
   public Task<List<LoanDto>> GetListWithNamesAsync();
}
