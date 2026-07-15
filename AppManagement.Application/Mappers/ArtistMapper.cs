using AppManagement.Application.DTOs.Artist;
using AppManagement.Application.Model;

namespace AppManagement.Application.Mappers;

public static class ArtistMapper
{
    public static Artist MapToArtist(this ArtistRequest request)
    {
        return new Artist
        {
            Country = request.Country,
            FirstName = request.FirstName,
            LastName = request.LastName,
        };
    }

    public static ArtistResponse MapToResponse(this Artist artist)
    {
        return new ArtistResponse
        {
            LastName = artist.LastName,
            FirstName = artist.FirstName,
            Country = artist.Country
        };
    }
}
