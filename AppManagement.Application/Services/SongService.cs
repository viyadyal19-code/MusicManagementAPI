using AppManagement.Application.Abstractions.Repositories;
using AppManagement.Application.Abstractions.Services;
using AppManagement.Application.DTOs.Song;
using AppManagement.Application.Exceptions;
using AppManagement.Application.Mappers;

namespace AppManagement.Application.Services
{
    internal class SongService : ISongService
    {
        private readonly ISongRepository _songRepository;
        private readonly IArtistRepository _artistRepository;
        private readonly IAlbumRepository _albumRepository;
        public SongService(ISongRepository songRepository, IArtistRepository artistRepository, IAlbumRepository albumRepository)
        {
            _songRepository = songRepository;
            _artistRepository = artistRepository;
            _albumRepository = albumRepository;
        }

        public async Task<SongResponse> CreateAsync(SongRequest request)
        {
            var artist = await _artistRepository.GetByIdAsync(request.ArtistId);

            if (artist == null)
            {
                throw new NotFoundException("Artist not found");
            }

            var album = await _albumRepository.GetByIdAsync(request.AlbumId);

            if (album == null)
            {
                throw new NotFoundException("Album not found");
            }

            var song = request.MapToSong();

            var createdSong = await _songRepository.CreateAsync(song);

            return createdSong.MapToResponse();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var song = await _songRepository.GetByIDAsync(id);

            if (song == null)
                return false;

            return await _songRepository.DeleteAsync(song);

        }

        public async Task<IEnumerable<SongResponse>> GetAllAsync()
        {
            var songs = await _songRepository.GetAllAsync();

            return songs.Select(s => s.MapToResponse());
        }

        public async Task<IEnumerable<SongResponse>> SearchAsync(string keyword)
        {
            var songs = await _songRepository.SearchAsync(keyword);

            return songs.Select(s => s.MapToResponse());
        }

        public async Task<SongResponse> UpdateAsync(int id, SongRequest request)
        {
            var song = await _songRepository.GetByIDAsync(id);

            if (song == null)
            {
                throw new NotFoundException("Song not found");
            }

            song.Title = request.Title;
            song.Duration = request.Duration;
            song.ArtistId = request.ArtistId;
            song.AlbumId = request.AlbumId;

            var updatedSong = await _songRepository.UpdateAsync(song);

            return updatedSong.MapToResponse();
        }
    }
}
