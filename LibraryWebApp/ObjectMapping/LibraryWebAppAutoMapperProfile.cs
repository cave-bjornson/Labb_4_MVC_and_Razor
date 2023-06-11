using AutoMapper;
using LibraryWebApp.Entities;
using LibraryWebApp.Services.Dtos;

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
    }
}
