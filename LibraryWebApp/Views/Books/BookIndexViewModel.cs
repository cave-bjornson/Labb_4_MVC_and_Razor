using System.ComponentModel.DataAnnotations;
using LibraryWebApp.Services.Dtos;
using LibraryWebApp.Shared;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;

namespace LibraryWebApp.Views.Books;

public class BookIndexViewModel
{
    [DynamicFormIgnore]
    public IEnumerable<BookViewModel> Books { get; set; }

    public BookViewModel Book { get; set; }
}

public class BookViewModel
{
    [Required]
    public string BookId { get; set; }
    
    [Required]
    [StringLength(128)]
    public string Name { get; set; }

    [Required]
    public BookType Type { get; set; } = BookType.Undefined;

    [Required]
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    public DateTime PublishDate { get; set; } = DateTime.Today;
}
