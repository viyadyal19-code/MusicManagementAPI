using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppManagement.Infrastructure.Identity.Models
{

    public class Song
    {
        public int Id { get; set; }  

        public string Title { get; set; } = string.Empty;

        public int Duration { get; set; }

        public int ArtistId { get; set; }

        public Artist? Artist { get; set; }

        public int? AlbumId { get; set; }

        public Album? Album { get; set; }
    }

}
