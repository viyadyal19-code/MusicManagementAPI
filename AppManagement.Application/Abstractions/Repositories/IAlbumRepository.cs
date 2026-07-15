using AppManagement.Application.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppManagement.Application.Abstractions.Repositories
{
    public interface IAlbumRepository
    {
        Task<IEnumerable<Album>> GetAllAsync();
        Task<Album?> GetByIdAsync(int id);
        Task<Album> CreateAsync(Album album);
        Task<Album> UpdateAsync(Album album);
        Task<bool> DeleteAsync(Album album);
        Task<IEnumerable<Album>> SearchAsync(string keyword);
    }
}