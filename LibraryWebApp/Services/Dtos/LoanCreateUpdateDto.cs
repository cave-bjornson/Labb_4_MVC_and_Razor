using System.ComponentModel.DataAnnotations;
using Volo.Abp.Application.Dtos;

namespace LibraryWebApp.Services.Dtos;

public class LoanCreateUpdateDto : EntityDto
{
    [Required]
    public Guid CustomerId { get; set; }

    [Required]
    public Guid BookId { get; set; }

    [Required]
    public DateTime LoanDate { get; set; } = DateTime.Today;

    [Required]
    public DateTime DueDate { get; set; } = DateTime.Today.AddDays(30);

    public DateTime? ReturnDate { get; set; }
}
