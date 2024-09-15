using System.Threading.Tasks;
using Asp.Versioning;
using BookStore.Interfaces;
using BookStore.Models;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.AspNetCore.Mvc;

namespace BookStore.Controllers;

[RemoteService]
[Area("app")]
[ControllerName("Book")]
[Microsoft.AspNetCore.Components.Route("api/app/books")]
public class BookController(IBookAppService bookAppService) : AbpController
{
    protected IBookAppService _bookAppService = bookAppService;

    [HttpGet]
    public async Task <PagedResultDto<BookDto>> GetBookAsync(PagedAndSortedResultRequestDto input)
    {
        return await _bookAppService.GetListAsync(input);
    }
}