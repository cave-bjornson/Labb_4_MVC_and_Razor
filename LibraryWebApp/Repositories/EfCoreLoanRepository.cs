using LibraryWebApp.Data;
using LibraryWebApp.Entities;
using LibraryWebApp.Services.Dtos;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace LibraryWebApp.Repositories;

public class EfCoreLoanRepository
    : EfCoreRepository<LibraryWebAppDbContext, Loan, Guid>,
        ILoanRepository
{
    /// <inheritdoc />
    public EfCoreLoanRepository(IDbContextProvider<LibraryWebAppDbContext> dbContextProvider)
        : base(dbContextProvider) { }

    /// <inheritdoc />
    public async Task<List<LoanDto>> GetListWithNamesAsync()
    {
        var dbContext = await GetDbContextAsync();
        var books = dbContext.Books;
        var customers = dbContext.Customers;

        var loans = await dbContext.Loans
            .Join(
                customers,
                loan => loan.CustomerId,
                customer => customer.Id,
                (loan, customer) =>
                    new
                    {
                        LoanId = loan.Id,
                        CustomerId = customer.Id,
                        CustomerUserName = customer.UserName,
                        loan.BookId,
                        loan.LoanDate,
                        loan.DueDate,
                        loan.ReturnDate
                    }
            )
            .Join(
                books,
                outer => outer.BookId,
                book => book.Id,
                (outer, book) => new { Outer = outer, BookName = book.Name }
            )
            .Select(
                result =>
                    new LoanDto
                    {
                        LoanId = result.Outer.LoanId,
                        CustomerId = result.Outer.CustomerId,
                        CustomerUserName = result.Outer.CustomerUserName,
                        BookId = result.Outer.BookId,
                        BookName = result.BookName,
                        LoanDate = result.Outer.LoanDate,
                        DueDate = result.Outer.DueDate,
                        ReturnDate = result.Outer.ReturnDate
                    }
            )
            .ToListAsync();

        return loans;
    }
}
