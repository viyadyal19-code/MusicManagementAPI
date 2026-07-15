using AppManagement.Application.DTOs.Song;
using AppManagement.Application.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppManagement.Application.Abstractions.Repositories
{
    public interface ISongRepository
    {
        Task<IEnumerable<Song>> GetAllAsync();
        Task<Song?> GetByIDAsync(int id);
        Task<Song> CreateAsync(Song song);
        Task<Song> UpdateAsync(Song song);
        Task<bool> DeleteAsync(Song song);
        Task<IEnumerable<Song>> SearchAsync(string keyword);
    }
}
