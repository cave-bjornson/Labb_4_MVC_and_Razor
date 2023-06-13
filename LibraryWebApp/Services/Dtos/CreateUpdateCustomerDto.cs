using System.ComponentModel.DataAnnotations;
using Volo.Abp.Application.Dtos;

namespace LibraryWebApp.Services.Dtos;

public class CreateUpdateCustomerDto : EntityDto
{
    [Required]
    public string UserName { get; set; }
    
    [Required]
    [StringLength(50)]
    public string Name { get; set; }
    
    [Required]
    [StringLength(50)]
    public string Surname { get; set; }
}
