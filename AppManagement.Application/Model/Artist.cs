using System.Text.Json.Serialization;

namespace AppManagement.Application.Model;

public class Artist
{
    public int Id { get; set; }

    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public string Country { get; set; } = string.Empty;

    [JsonIgnore]
    public List<Song> Songs { get; set; } = new();
}
