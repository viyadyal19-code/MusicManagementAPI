using AppManagement.Application.Abstractions.Repositories;
using AppManagement.Infrastructure.Identity.DbContext;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AppManagement.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SearchController : ControllerBase
{
    private readonly ISearchService _searchService;

    public SearchController(ISearchService searchService)
    {
        _searchService = searchService;
    }

    [HttpGet]
    public async Task<IActionResult> Search(string keyword)
    {
        var result = await _searchService.SearchAsync(keyword);

        return Ok(result);
    }

}



