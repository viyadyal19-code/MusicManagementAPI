using AppManagement.Application.Abstractions.Repositories;
using AppManagement.Application.Abstractions.Services;
using AppManagement.Application.DTOs.Album;
using AppManagement.Application.DTOs.Song;
using AppManagement.Application.Mappers;
using AppManagement.Application.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppManagement.Application.Services
{
    internal class AlbumService : IAlbumService
    {
        private readonly IAlbumRepository _repository;
        public AlbumService(IAlbumRepository repository)
        {
            _repository = repository;
        }

        public async Task<AlbumResponse> CreateAsync(AlbumRequest request)
        {
            var album = request.MapToALbum();

            return (await _repository.CreateAsync(album))
                .MapToResponse();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var album = await _repository.GetByIdAsync(id);

            if (album is null)
                return false;

            if (album.Songs.Any())
                throw new ArgumentException(
                    "Cannot delete album with songs");

            return await _repository.DeleteAsync(album);
        }

        public async Task<IEnumerable<AlbumResponse>> GetAllAsync()
        {

            var albums = await _repository.GetAllAsync();

            return albums.Select(a => a.MapToResponse());

        }

        public Task<IEnumerable<SongResponse>> GetSongsByAlbumAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<AlbumResponse> UpdateAsync(int id, AlbumRequest request)
      
        {
            var album = await _repository.GetByIdAsync(id);

            if (album is null)
                throw new ArgumentException("Album not found");

            album.Title = request.Title;
            album.ReleaseYear = request.ReleaseYear;

            return (await _repository.UpdateAsync(album))
                .MapToResponse();
        }
    }
}