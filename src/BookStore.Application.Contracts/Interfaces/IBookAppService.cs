using System;
using BookStore.Models;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace BookStore.Interfaces;

public interface IBookAppService : ICrudAppService <BookDto, Guid, PagedAndSortedResultRequestDto, CreateBookDto, UpdateBookDto>
{
    
}