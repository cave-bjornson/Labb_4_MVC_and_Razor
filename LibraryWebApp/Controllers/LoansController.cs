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

        return View();
    }

    [HttpPost]
    public async Task<IActionResult> MakeLoan(string customerUserName, string bookId)
    {
        await _service.MakeLoan(customerUserName, Guid.Parse(bookId));

        return RedirectToAction("Index", "Books");
    }
}
