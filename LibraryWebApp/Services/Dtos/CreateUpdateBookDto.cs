using System.ComponentModel.DataAnnotations;
using LibraryWebApp.Shared;
using Volo.Abp.Application.Dtos;

namespace LibraryWebApp.Services.Dtos;

public class CreateUpdateBookDto : EntityDto
{
    [Required]
    [StringLength(128)]
    public string Name { get; set; }

    [Required]
    public BookType Type { get; set; } = BookType.Undefined;

    [Required]
    [DataType(DataType.Date)]
    public DateTime PublishDate { get; set; } = DateTime.Now;
}
