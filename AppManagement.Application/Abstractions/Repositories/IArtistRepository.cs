using AppManagement.Application.Model;

namespace AppManagement.Application.Abstractions.Repositories;

public interface IArtistRepository
{
    Task<IEnumerable<Artist>> GetAllAsync();
    Task<Artist?> GetByIdAsync(int id);
    Task<Artist> CreateAsync(Artist artist);
    Task<Artist> UpdateAsync(Artist artist);
    Task<bool> DeleteAsync(Artist artist);
    Task<IEnumerable<Artist>> SearchAsync(string keyword);
}