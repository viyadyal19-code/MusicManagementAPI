using AppManagement.Application.DTOs.Album;
using AppManagement.Application.DTOs.Song;
using AppManagement.Application.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppManagement.Application.Abstractions.Services
{
    public interface IAlbumService
    {
        Task<IEnumerable<AlbumResponse>> GetAllAsync();
        Task<IEnumerable<SongResponse>> GetSongsByAlbumAsync(int id);
        Task<AlbumResponse> CreateAsync(AlbumRequest request);
        Task<AlbumResponse> UpdateAsync(int id, AlbumRequest request);
        Task<bool> DeleteAsync(int id);
    }
}