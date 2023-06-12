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

    public BooksController(IBookAppService service)
    {
        _service = service;
    }

    // GET
    public async Task<IActionResult> Index()
    {
        var books = await _service.GetListAsync(new PagedAndSortedResultRequestDto());
        var model = new BookIndexViewModel
        {
            Books = ObjectMapper.Map<IEnumerable<BookDto>, IEnumerable<BookViewModel>>(books.Items),
        };

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
