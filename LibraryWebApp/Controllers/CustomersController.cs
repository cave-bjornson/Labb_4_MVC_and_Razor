using AutoMapper;
using LibraryWebApp.Services;
using LibraryWebApp.Services.Dtos;
using LibraryWebApp.Views.Books;
using LibraryWebApp.Views.Customers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Volo.Abp.Application.Dtos;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Identity;
using Volo.Abp.ObjectMapping;

namespace LibraryWebApp.Controllers;

public class CustomersController : AbpController
{
    private readonly ICustomerService _service;
    private readonly IdentityUserManager _userManager;

    public CustomersController(ICustomerService service, IdentityUserManager userManager)
    {
        _service = service;
        _userManager = userManager;
    }

    // GET
    public async Task<IActionResult> Index()
    {
        var customers = await _service.GetListAsync(new PagedAndSortedResultRequestDto());
        var customerUsers = await _userManager.GetUsersInRoleAsync("customer");

        var customerModels = customers.Items.Join(
            customerUsers,
            dto => dto.UserId,
            user => user.Id,
            (dto, user) => new CustomerViewModel { Name = dto.Name, UserName = user.UserName }
        );

        var selectListItems = customerUsers.Select(
            cu => new SelectListItem { Value = cu.Id.ToString(), Text = cu.UserName }
        );

        var model = new CustomerIndexViewModel
        {
            Customers = customerModels,
            CustomerUserIds = selectListItems
        };

        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Name, UserId")] CustomerIndexViewModel model)
    {
        Logger.LogInformation("CreateCustomer {@Customer}", model);

        await _service.CreateAsync(
            new CreateUpdateCustomerDto { UserId = Guid.Parse(model.UserId), Name = model.Name }
        );

        return RedirectToAction("Index");
    }
}
