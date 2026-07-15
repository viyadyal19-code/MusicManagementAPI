using AppManagement.Application.DTOs.Artist;
using AppManagement.Application.Model;

namespace AppManagement.Application.Abstractions.Services;

public interface IArtistService
{
    Task<IEnumerable<ArtistResponse>> GetAllAsync();
    Task<ArtistResponse?> GetByIdAsync(int id);
    Task<IEnumerable<Song>> GetSongsByArtistAsync(int id);
    Task<ArtistResponse> CreateAsync(ArtistRequest request);
    Task<ArtistResponse> UpdateAsync(int id, ArtistRequest request);
    Task<bool> DeleteAsync(int id);
}
