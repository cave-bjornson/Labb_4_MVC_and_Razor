using LibraryWebApp.Services.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace LibraryWebApp.Services;

public interface ILoanService
    : ICrudAppService<LoanDto, Guid, PagedAndSortedResultRequestDto, LoanCreateUpdateDto>
{
    Task<List<LoanDto>> GetListByCustomerId(Guid id);

    Task<List<LoanDto>> GetListByBookId(Guid id);

    Task<LoanDto> ReturnLoan(Guid id);

    Task<List<LoanDto>> GetListWithNames();

    Task<LoanDto> MakeLoan(string CustomerUserName, Guid BookId);
}
