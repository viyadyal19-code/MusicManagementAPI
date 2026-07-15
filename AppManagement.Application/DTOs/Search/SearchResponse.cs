using AppManagement.Application.DTOs.Album;
using AppManagement.Application.DTOs.Artist;
using AppManagement.Application.DTOs.Song;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppManagement.Application.DTOs.Search
{
    public class SearchResponse
    {
        public IEnumerable<SongResponse> Songs { get; set; }
            = new List<SongResponse>();

        public IEnumerable<AlbumResponse> Albums { get; set; }
            = new List<AlbumResponse>();

        public IEnumerable<ArtistResponse> Artists { get; set; }
            = new List<ArtistResponse>();
    }
}
