using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppManagement.Application.DTOs.Song
{
    public class SongResponse
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public int Duration { get; set; }
        public int ArtistId { get; set; }
        public int? AlbumId { get; set; }
    }
}
