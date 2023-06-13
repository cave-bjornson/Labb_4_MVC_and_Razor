using System.ComponentModel.DataAnnotations;
using Volo.Abp.Application.Dtos;

namespace LibraryWebApp.Services.Dtos;

public class CreateUpdateCustomerDto : EntityDto
{
    [Required]
    [StringLength(50)]
    public string Name { get; set; }
    
    [Required]
    public Guid UserId { get; set; }
}
