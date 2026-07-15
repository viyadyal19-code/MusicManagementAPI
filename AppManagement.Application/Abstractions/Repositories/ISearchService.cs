using AppManagement.Application.DTOs.Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppManagement.Application.Abstractions.Repositories
{
    public interface ISearchService
    {
        Task<SearchResponse> SearchAsync(string keyword);
    }
}
