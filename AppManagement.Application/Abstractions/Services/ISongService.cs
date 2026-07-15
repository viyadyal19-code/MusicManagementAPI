using AppManagement.Application.DTOs.Song;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppManagement.Application.Abstractions.Services
{
    public interface ISongService
    {
        Task<IEnumerable<SongResponse>> GetAllAsync();
        Task<SongResponse>CreateAsync(SongRequest request);
        Task<SongResponse>UpdateAsync(int id, SongRequest request);
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<SongResponse>> SearchAsync(string keyword);
    }
}
