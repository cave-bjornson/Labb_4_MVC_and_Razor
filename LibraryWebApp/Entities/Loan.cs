using Volo.Abp.Domain.Entities;

namespace LibraryWebApp.Entities;

public class Loan : Entity<Guid>
{
    public required Guid CustomerId { get; set; }

    public required Guid BookId { get; set; }

    public required DateTime LoanDate { get; set; }

    public required DateTime DueDate { get; set; }

    public DateTime? ReturnDate { get; set; }
}
