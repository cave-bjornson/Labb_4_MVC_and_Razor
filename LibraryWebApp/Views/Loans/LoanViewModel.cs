using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LibraryWebApp.Views.Loans;

public class LoanViewModel
{
    [DisplayName("Book")]
    public string BookName { get; set; }
    
    [DisplayName("Customer")]
    public string CustomerUserName {get; set; }
    
    [Required]
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    public DateOnly LoanDate { get; set; }
    
    [Required]
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    public DateOnly DueDate { get; set; }
    
    [Required]
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    public DateOnly ReturnDate { get; set; }
}

public class MakeLoanViewModel
{
    public required string CustomerId { get; set; }
    
    public required string BookId { get; set; }
}