using AutoMapper;
using LibraryWebApp.Services;
using LibraryWebApp.Services.Dtos;
using LibraryWebApp.Views.Books;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.ObjectMapping;

namespace LibraryWebApp.Controllers;

public class BooksController : AbpController
{
    private readonly IBookAppService _service;
    private readonly ILoanService _loanService;

    public BooksController(IBookAppService service, ILoanService loanService)
    {
        _service = service;
        _loanService = loanService;
    }

    // GET
    public async Task<IActionResult> Index()
    {
        var books = await _service.GetListAsync(new PagedAndSortedResultRequestDto());
        var model = new BookIndexViewModel
        {
            Books = ObjectMapper.Map<IEnumerable<BookDto>, IEnumerable<BookViewModel>>(books.Items),
        };

        foreach (var bookViewModel in model.Books)
        {
            bookViewModel.OnLoan = _loanService.IsOnLoan(Guid.Parse(bookViewModel.BookId)).Result;
        }

        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Book")] BookIndexViewModel model)
    {
        var book = ObjectMapper.Map<BookViewModel, CreateUpdateBookDto>(model.Book);
        await _service.CreateAsync(book);

        return RedirectToAction("Index");
    }
}
