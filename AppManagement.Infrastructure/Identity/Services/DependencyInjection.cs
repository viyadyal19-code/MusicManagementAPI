using AppManagement.Application.Abstractions.Repositories;
using AppManagement.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppManagement.Infrastructure.Identity.Services
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<IArtistRepository, ArtistRepository>();
            services.AddScoped<IAlbumRepository, AlbumRepository>();
            services.AddScoped<ISongRepository, SongRepository>();

            return services;
        }
    }
}
