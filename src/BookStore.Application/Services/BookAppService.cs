using System;
using BookStore.Interfaces;
using BookStore.Models;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace BookStore.Services;

public class BookAppService : CrudAppService<Book, BookDto, Guid, PagedAndSortedResultRequestDto, CreateBookDto,UpdateBookDto>,IBookAppService 
{
    public BookAppService(IRepository<Book, Guid> repository) : base(repository){}
    
}