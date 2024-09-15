using AutoMapper;
using BookStore.Models;

namespace BookStore;

public class BookStoreApplicationAutoMapperProfile : Profile
{
    public BookStoreApplicationAutoMapperProfile()
    {
     CreateMap<Book, BookDto>();
     CreateMap<CreateBookDto, Book>();
     CreateMap<UpdateBookDto, Book>();
    }
}
