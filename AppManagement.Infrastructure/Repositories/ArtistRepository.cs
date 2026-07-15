using AppManagement.Application.Abstractions.Repositories;
using AppManagement.Application.Model;
using AppManagement.Infrastructure.Identity.DbContext;
using Microsoft.EntityFrameworkCore;

namespace AppManagement.Infrastructure.Repositories;

internal class ArtistRepository : IArtistRepository
{
    private readonly ApplicationIdentityDbContext _context;

    public ArtistRepository(ApplicationIdentityDbContext context)
    {
        _context = context;
    }

    public async Task<Artist> CreateAsync(Artist artist)
    {
        _context.Artists.Add(artist);
        await _context.SaveChangesAsync();
        return (artist);
    }
    public async Task<Artist?> GetByIdAsync(int id)
    {
        return await _context.Artists
            .Include(a => a.Songs)
            .FirstOrDefaultAsync(a => a.Id == id);
    }
    public async Task<bool> DeleteAsync(Artist artist)
    {
        _context.Artists.Remove(artist);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<IEnumerable<Artist>> GetAllAsync()
    {
        return await _context.Artists.ToListAsync();
    }

    public async Task<Artist> UpdateAsync(Artist artist)
    {
        _context.Artists.Update(artist);
        await _context.SaveChangesAsync();
        return (artist);
    }
    public async Task<IEnumerable<Artist>> SearchAsync(string keyword)
    {
        return await _context.Artists
            .Where(a =>
                a.FirstName.Contains(keyword) ||
                a.LastName.Contains(keyword))
            .ToListAsync();
    }
}