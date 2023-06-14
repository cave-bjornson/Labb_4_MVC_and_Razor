using LibraryWebApp.Entities;
using LibraryWebApp.Repositories;
using LibraryWebApp.Services.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.ObjectMapping;

namespace LibraryWebApp.Services;

public class LoanService
    : CrudAppService<Loan, LoanDto, Guid, PagedAndSortedResultRequestDto, LoanCreateUpdateDto>,
        ILoanService
{
    private readonly ILoanRepository _loanRepository;
    private readonly IRepository<Customer, Guid> _customerRepository;

    /// <inheritdoc />
    public LoanService(ILoanRepository repository, IRepository<Customer, Guid> customerRepository)
        : base(repository)
    {
        _loanRepository = repository;
        _customerRepository = customerRepository;
    }

    /// <inheritdoc />
    public async Task<List<LoanDto>> GetListByCustomerId(Guid id)
    {
        var loans = await ReadOnlyRepository.GetListAsync(predicate: loan => loan.CustomerId == id);
        return ObjectMapper.Map<List<Loan>, List<LoanDto>>(loans);
    }

    /// <inheritdoc />
    public async Task<List<LoanDto>> GetListByBookId(Guid id)
    {
        var loans = await ReadOnlyRepository.GetListAsync(predicate: loan => loan.BookId == id);
        return ObjectMapper.Map<List<Loan>, List<LoanDto>>(loans);
    }

    /// <inheritdoc />
    public async Task<LoanDto> ReturnLoan(Guid id)
    {
        var loan = await Repository.FindAsync(id);
        loan.ReturnDate = DateTime.Now;
        var updatedLoan = await Repository.UpdateAsync(loan, autoSave: true);
        return ObjectMapper.Map<Loan, LoanDto>(updatedLoan);
    }

    /// <inheritdoc />
    public async Task<List<LoanDto>> GetListWithNames()
    {
        return await _loanRepository.GetListWithNamesAsync();
    }

    /// <inheritdoc />
    public async Task<LoanDto> MakeLoan(string CustomerUserName, Guid BookId)
    {
        var customer = await _customerRepository.FindAsync(
            customer => customer.UserName == CustomerUserName
        );

        var newLoan = await CreateAsync(
            new LoanCreateUpdateDto { CustomerId = customer.Id, BookId = BookId }
        );

        return newLoan;
    }
}
