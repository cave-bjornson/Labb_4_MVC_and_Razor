using Volo.Abp.Application.Dtos;

namespace LibraryWebApp.Services.Dtos;

public class LoanDto : EntityDto<Guid>
{
    public required Guid LoanId { get; set; }

    public required Guid CustomerId { get; set; }

    public required string CustomerUserName { get; set; }

    public required Guid BookId { get; set; }

    public required string BookName { get; set; }

    public required DateTime LoanDate { get; set; }

    public required DateTime DueDate { get; set; }

    public DateTime? ReturnDate { get; set; }

    public bool Returned => ReturnDate.HasValue;
}
