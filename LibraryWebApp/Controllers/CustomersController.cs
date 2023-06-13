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
    private readonly IIdentityUserAppService _userService;
    private readonly IIdentityRoleAppService _roleService;

    public CustomersController(
        ICustomerService service,
        IdentityUserManager userManager,
        IIdentityUserAppService userService,
        IIdentityRoleAppService roleService
    )
    {
        _service = service;
        _userManager = userManager;
        _userService = userService;
        _roleService = roleService;
    }

    // GET
    public async Task<IActionResult> Index()
    {
        var customers = await _service.GetListAsync(new PagedAndSortedResultRequestDto());

        var customerModels = customers.Items.Select(
            c =>
                new CustomerViewModel
                {
                    UserName = c.UserName,
                    Name = c.Name,
                    Surname = c.Surname
                }
        );

        var selectListItems = customers.Items.Select(
            c => new SelectListItem { Value = c.UserName, Text = c.UserName }
        );

        var model = new CustomerIndexViewModel
        {
            Customers = customerModels,
            CustomerUserNames = selectListItems
        };

        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(
        [Bind("UserName, Name, SurName")] CustomerIndexViewModel model
    )
    {
        // Logger.LogInformation("CreateCustomer {@Customer}", model);

        await _service.CreateAsync(
            new CreateUpdateCustomerDto
            {
                UserName = model.UserName,
                Name = model.Name,
                Surname = model.Surname
            }
        );

        return RedirectToAction("Index");
    }
}
