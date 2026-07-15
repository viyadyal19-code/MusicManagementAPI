using AppManagement.Application.DTOs.Song;
using AppManagement.Application.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppManagement.Application.Mappers
{
    public static class SongMapper
    {
        public static Song MapToSong(this SongRequest request)
        {
            return new Song
            {
                Title = request.Title,
                Duration = request.Duration,
                ArtistId = request.ArtistId,
                AlbumId = request.AlbumId
            };
        }

        public static SongResponse MapToResponse(this Song song)
        {
            return new SongResponse
            {
                Id = song.Id,
                Title = song.Title,
                Duration = song.Duration,
                ArtistId= song.ArtistId,
                AlbumId= song.AlbumId
            };
        }
    }
}
