using AppManagement.Application.Abstractions.Repositories;
using AppManagement.Application.Abstractions.Services;
using AppManagement.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace AppManagement.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IArtistService, ArtistService>();
        services.AddScoped<IAlbumService, AlbumService>();
        services.AddScoped<ISongService, SongService>();
        services.AddScoped<ISearchService, SearchService>();
        return services;
    }
}