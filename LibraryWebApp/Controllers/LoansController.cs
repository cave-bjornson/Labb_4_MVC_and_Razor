using System.Collections;
using LibraryWebApp.Services;
using LibraryWebApp.Services.Dtos;
using LibraryWebApp.Views.Loans;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using Volo.Abp.AspNetCore.Mvc;

namespace LibraryWebApp.Controllers;

public class LoansController : AbpController
{
    private readonly ILoanService _service;

    public LoansController(ILoanService service)
    {
        _service = service;
    }

    // GET
    public async Task<IActionResult> Index()
    {
        var loans = await _service.GetListWithNames();
        var model = new LoanIndexViewModel
        {
            Loans = ObjectMapper.Map<IEnumerable<LoanDto>, IEnumerable<LoanViewModel>>(loans)
        };

        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> MakeLoan(string customerUserName, string bookId)
    {
        await _service.MakeLoan(customerUserName, Guid.Parse(bookId));

        return RedirectToAction("Index", "Books");
    }

    [HttpPost]
    public async Task<IActionResult> ReturnLoan(string loanId)
    {
        await _service.ReturnLoan(Guid.Parse(loanId));

        return RedirectToAction("Index", "Loans");
    }
}
