using LibraryWebApp.Services;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using Volo.Abp.AspNetCore.Mvc;

namespace LibraryWebApp.Controllers;

public class BooksController : Controller
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
        
        return View(books);
    }
}