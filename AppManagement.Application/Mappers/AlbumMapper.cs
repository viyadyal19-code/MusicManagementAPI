using AppManagement.Application.DTOs.Album;
using AppManagement.Application.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AppManagement.Application.Mappers
{
    public static class AlbumMapper
    {
        public static Album MapToALbum(this AlbumRequest request)
        {
            return new Album
            {
                Title = request.Title,
                ReleaseYear = request.ReleaseYear
            };
        }

        public static AlbumResponse MapToResponse(this Album album)
        {
            return new AlbumResponse
            {
                Id = album.Id,
                Title = album.Title,
                ReleaseYear = album.ReleaseYear
            };
        }
    }
}
