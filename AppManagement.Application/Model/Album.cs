using System.Text.Json.Serialization;

namespace AppManagement.Application.Model;

public class Album
{
    public int Id { get; set; }

    public string Title { get; set; } = string.Empty;

    public int ReleaseYear { get; set; }

    public ICollection<Song> Songs { get; set; } = new List<Song>();
}
