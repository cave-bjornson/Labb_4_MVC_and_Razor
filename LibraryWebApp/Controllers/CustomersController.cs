using System.Linq.Dynamic.Core;
using AutoMapper;
using LibraryWebApp.Services;
using LibraryWebApp.Services.Dtos;
using LibraryWebApp.Views.Books;
using LibraryWebApp.Views.Customers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
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
        // var customerModels = customers.Items.Select(
        //     c =>
        //         new CustomerViewModel
        //         {
        //             UserName = c.UserName,
        //             Name = c.Name,
        //             Surname = c.Surname
        //         }
        // );

        var customerModels = ObjectMapper.Map<
            IReadOnlyList<CustomerDto>,
            IEnumerable<CustomerViewModel>
        >(customers.Items);

        var customerRoleId = _roleService
            .GetAllListAsync()
            .Result.Items.FirstOrDefault(dto => dto.Name == "customer")!
            .Id;

        var users = await _userManager.GetUsersInRoleAsync("customer");

        var customerUserNames = users.Select(user => user.UserName);

        var selectListItems = customerUserNames.Select(
            c => new SelectListItem { Value = c, Text = c }
        );

        var model = new CustomerIndexViewModel
        {
            Customers = customerModels,
            CustomerUserNames = selectListItems
        };

        return View(model);
    }

    public async Task<IActionResult> Details(string id)
    {
        var customer = await _service.GetAsync(Guid.Parse(id));

        var customerUserNames = await _service.GetCustomerUserNames();

        var model = ObjectMapper.Map<CustomerDto, EditCustomerViewModel>(customer);

        model.CustomerUserNames = customerUserNames.Select(
            c => new SelectListItem { Value = c, Text = c }
        );

        Logger.LogInformation("editmodel {Model}", model.Dump());

        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Details(
        [Bind("Id, UserName, Name, Surname")] EditCustomerViewModel model
    )
    {
        await _service.UpdateAsync(
            Guid.Parse(model.Id),
            new CreateUpdateCustomerDto
            {
                UserName = model.UserName,
                Name = model.Name,
                Surname = model.Surname
            }
        );
        return RedirectToAction("Index");
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(
        [Bind("UserName, Name, Surname")] CustomerIndexViewModel model
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

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(string CustomerId)
    {
        await _service.DeleteAsync(Guid.Parse(CustomerId));

        return RedirectToAction("Index");
    }
}
