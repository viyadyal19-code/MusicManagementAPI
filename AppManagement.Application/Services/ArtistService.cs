using AppManagement.Application.Abstractions.Repositories;
using AppManagement.Application.Abstractions.Services;
using AppManagement.Application.DTOs.Artist;
using AppManagement.Application.Mappers;
using AppManagement.Application.Model;

namespace AppManagement.Application.Services;

internal class ArtistService : IArtistService
{
    private readonly IArtistRepository _repository;
    public ArtistService(IArtistRepository repository)
    {
        _repository = repository;
    }

    public async Task<ArtistResponse> CreateAsync(ArtistRequest request)
    {
        var artistToCreate = request.MapToArtist();

        var artist = await _repository.CreateAsync(artistToCreate);
        return artist.MapToResponse();
    }

    public async Task<IEnumerable<Song>> GetSongsByArtistAsync(int id)
    {
        var artist = await _repository.GetByIdAsync(id);

        if (artist is null)
            return Enumerable.Empty<Song>();

        return artist.Songs;
    }

    public async Task<ArtistResponse> UpdateAsync(int id, ArtistRequest request)
    {
        var artist = await _repository.GetByIdAsync(id);

        if (artist is null)
        {
            throw new ArgumentException("Artist not found");
        }

        artist.FirstName = request.FirstName;
        artist.LastName = request.LastName;
        artist.Country = request.Country;

        return (await _repository.UpdateAsync(artist)).MapToResponse();
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var artist = await _repository.GetByIdAsync(id);
        if (artist is null) return false;

        if (artist.Songs.Any())
        {
            throw new ArgumentException("Cannot delete Artist with at least one song");
        }

        return await _repository.DeleteAsync(artist);
    }

    public async Task<IEnumerable<ArtistResponse>> GetAllAsync()
    {
        var artists = await _repository.GetAllAsync();

        return artists.Select(a => a.MapToResponse());
    }
    public async Task<ArtistResponse?> GetByIdAsync(int id)
    {
        var artist = await _repository.GetByIdAsync(id);

        if (artist is null)
            return null;

        return artist.MapToResponse();
    }
}
