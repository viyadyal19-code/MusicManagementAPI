using AppManagement.Application.Abstractions.Repositories;
using AppManagement.Application.DTOs.Search;
using AppManagement.Application.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppManagement.Application.Services
{
    internal class SearchService : ISearchService
    {
        private readonly ISongRepository _songRepository;
        private readonly IAlbumRepository _albumRepository;
        private readonly IArtistRepository _artistRepository;

        public SearchService(ISongRepository songRepository, IAlbumRepository albumRepository, IArtistRepository artistRepository)
        {
            _songRepository = songRepository;
            _albumRepository = albumRepository;
            _artistRepository = artistRepository;
        }

        public async Task<SearchResponse> SearchAsync(string keyword)
        {

            var songs = await _songRepository.SearchAsync(keyword);
            var albums = await _albumRepository.SearchAsync(keyword);
            var artists = await _artistRepository.SearchAsync(keyword);


            return new SearchResponse
            {
                Songs = songs.Select(s => s.MapToResponse()),
                Albums = albums.Select(a => a.MapToResponse()),
                Artists = artists.Select(a => a.MapToResponse())
            };

        }
    }
}
