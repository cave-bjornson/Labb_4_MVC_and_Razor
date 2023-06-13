using LibraryWebApp.Services;
using LibraryWebApp.Services.Dtos;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Identity;
using Volo.Abp.Identity.Web.Pages.Identity.Users;

namespace LibraryWebApp.Pages.Identity.Users;

[Dependency(ReplaceServices = true)]
[ExposeServices(typeof(CreateModalModel))]
public class LibraryCreateModalModel : CreateModalModel
{
    private readonly ICustomerService _customerService;
    
    /// <inheritdoc />
    public LibraryCreateModalModel(IIdentityUserAppService identityUserAppService, ICustomerService customerService) : base(identityUserAppService)
    {
        _customerService = customerService;
    }

    /// <inheritdoc />
    public override async Task<NoContentResult> OnPostAsync()
    {
        await base.OnPostAsync();
        
        if (Roles.Any(role => role.IsAssigned && role.Name == "customer"))
        {
            var newCustomer = new CreateUpdateCustomerDto
            {
                UserName = UserInfo.UserName,
                Name = UserInfo.Name,
                Surname = UserInfo.Surname
            };

            await _customerService.CreateAsync(newCustomer);
        } 
        
        return NoContent();
    }
}