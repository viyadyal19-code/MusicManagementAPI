using AppManagement.Application.Abstractions.Repositories;
using AppManagement.Application.Model;
using AppManagement.Infrastructure.Identity.DbContext;
using Microsoft.EntityFrameworkCore;

namespace AppManagement.Infrastructure.Repositories;

internal class AlbumRepository : IAlbumRepository
{
    private readonly ApplicationIdentityDbContext _context;

    public AlbumRepository(ApplicationIdentityDbContext context)
    {
        _context = context;
    }

    public async Task<Album> CreateAsync(Album album)
    {
        _context.Albums.Add(album);

        await _context.SaveChangesAsync();

        return album;
    }
    public async Task<Album?> GetByIdAsync(int id)
    {
        return await _context.Albums
            .Include(a => a.Songs)
            .FirstOrDefaultAsync(a => a.Id == id);
    }
    public async Task<bool> DeleteAsync(Album album)
    {
        _context.Albums.Remove(album);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<IEnumerable<Album>> GetAllAsync()
    {
        return await _context.Albums.ToListAsync();
    }

    public async Task<Album> UpdateAsync(Album album)
    {
        _context.Albums.Update(album);
        await _context.SaveChangesAsync();
        return (album);
    }
    public async Task<IEnumerable<Album>> SearchAsync(string keyword)
    {
        return await _context.Albums
            .Where(a => a.Title.Contains(keyword))
            .ToListAsync();
    }
}