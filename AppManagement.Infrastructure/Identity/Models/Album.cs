using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace AppManagement.Infrastructure.Identity.Models
{
    public class Album
    {
        public int Id { get; set; }   

        public string Title { get; set; } = string.Empty;

        public int ReleaseYear { get; set; }

        [JsonIgnore]
        public List<Song> Songs { get; set; } = new();
    }
}
