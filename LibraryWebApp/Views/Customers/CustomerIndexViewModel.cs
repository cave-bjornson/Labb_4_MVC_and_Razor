using System.ComponentModel.DataAnnotations;
using LibraryWebApp.Services.Dtos;
using LibraryWebApp.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NUglify.JavaScript.Syntax;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;
using Volo.Abp.Identity;
using Volo.Abp.Identity.Settings;
using Volo.Abp.Users;

namespace LibraryWebApp.Views.Customers;

public class CustomerIndexViewModel
{
    [DynamicFormIgnore]
    public IEnumerable<CustomerViewModel> Customers { get; set; }

    [DynamicFormIgnore]
    public IEnumerable<SelectListItem> CustomerUserIds { get; set; }

    [Required]
    [StringLength(50)]
    public string Name { get; set; }

    [Required]
    [SelectItems(nameof(CustomerUserIds))]
    public string UserId { get; set; }
}

public class CustomerViewModel
{
    [Required]
    [StringLength(50)]
    public string Name { get; set; }

    [Required]
    public string UserName { get; set; }
}
