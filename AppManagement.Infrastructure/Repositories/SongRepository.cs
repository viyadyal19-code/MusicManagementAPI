using AppManagement.Application.Abstractions.Repositories;
using AppManagement.Application.DTOs.Song;
using AppManagement.Application.Model;
using AppManagement.Infrastructure.Identity.DbContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppManagement.Infrastructure.Repositories
{
    internal class SongRepository : ISongRepository
    {
        private readonly ApplicationIdentityDbContext _context;

        public SongRepository(ApplicationIdentityDbContext context)
        {
            _context = context;
        }

        public async Task<Song> CreateAsync(Song song)
        {
            _context.Songs.Add(song);
            await _context.SaveChangesAsync();

            return song;
        }

        public async Task<bool> DeleteAsync(Song song)
        {
            _context.Songs.Remove(song);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<Song>> GetAllAsync()
        {
            return await _context.Songs.ToListAsync();
        }

        public async Task<Song?> GetByIDAsync(int id)
        {
            return await _context.Songs
               .FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<IEnumerable<Song>> SearchAsync(string keyword)
        {
            return await _context.Songs
            .Include(s => s.Artist)
            .Include(s => s.Album)
            .Where(s =>
                s.Title.Contains(keyword) ||
                s.Artist!.FirstName.Contains(keyword) ||
                s.Artist!.LastName.Contains(keyword))
            .ToListAsync();

        }

        public async Task<Song> UpdateAsync(Song song)
        {
            _context.Songs.Update(song);
            await _context.SaveChangesAsync();

            return song;
        }
    }
}
