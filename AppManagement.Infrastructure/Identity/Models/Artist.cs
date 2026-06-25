using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace AppManagement.Infrastructure.Identity.Models
{
    public class Artist
    {
        public int Id { get; set; }   

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string Country { get; set; } = string.Empty;

        [JsonIgnore]
        public List<Song> Songs { get; set; } = new();
    }
}
