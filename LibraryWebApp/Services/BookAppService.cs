using LibraryWebApp.Entities;
using LibraryWebApp.Services.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace LibraryWebApp.Services;

public class BookAppService
    : CrudAppService<Book, BookDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateBookDto>,
        IBookAppService
{
    /// <inheritdoc />
    public BookAppService(IRepository<Book, Guid> repository)
        : base(repository) { }
}
