using AutoMapper;
using LibraryWebApp.Entities;
using LibraryWebApp.Services.Dtos;
using LibraryWebApp.Views.Books;
using LibraryWebApp.Views.Customers;
using LibraryWebApp.Views.Loans;
using Volo.Abp.Identity.Web.Pages.Identity.Users;

namespace LibraryWebApp.ObjectMapping;

public class LibraryWebAppAutoMapperProfile : Profile
{
    public LibraryWebAppAutoMapperProfile()
    {
        /* Create your AutoMapper object mappings here */
        CreateMap<Book, BookDto>();
        CreateMap<CreateUpdateBookDto, Book>();
        CreateMap<Customer, CustomerDto>();
        CreateMap<CreateUpdateCustomerDto, Customer>();
        CreateMap<BookDto, BookViewModel>()
            .ForMember(
                destinationMember: model => model.BookId,
                dto => dto.MapFrom(bookDto => bookDto.Id.ToString())
            );
        CreateMap<BookViewModel, CreateUpdateBookDto>();
        CreateMap<CustomerDto, CustomerViewModel>();
        CreateMap<CustomerViewModel, CreateUpdateCustomerDto>();
        CreateMap<Loan, LoanDto>();
        CreateMap<LoanDto, LoanViewModel>();
        CreateMap<LoanCreateUpdateDto, Loan>();
    }
}
