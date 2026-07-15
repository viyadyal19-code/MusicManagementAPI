using System.Security.Cryptography.X509Certificates;

namespace AppManagement.Application.DTOs.Artist;

public class ArtistResponse
{
    public int Id { get; set; }

    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public string FullName => $"{FirstName} {LastName}";

    public string Country { get; set; } = string.Empty;
}
