using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Persistence.Models;
using Persistence.Data;
using Persistence.Repositories.IRepositories;

namespace Persistence.Repositories;

public class NotesRepository : INotesRepository
{
    private readonly ApplicationDbContext _dbContext;

    public NotesRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Note> AddAsync(Note obj)
    {
        await _dbContext.Notes.AddAsync(obj);
        await _dbContext.SaveChangesAsync();
        return obj;
    }

    public async Task DeleteAsync(int id)
    {
        Note obj = await _dbContext.Notes.SingleAsync(obj => obj.Id == id);
        _dbContext.Notes.Remove(obj);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<bool> ExistsAsync(int id)
    {
        Note? obj = await _dbContext.Notes.SingleOrDefaultAsync(obj => obj.Id == id);
        if (obj is null)
            return false;
        return true;
    }

    public async Task<IEnumerable<Note>> GetAsync() => await _dbContext.Notes.AsNoTracking().ToListAsync();

    public async Task<Note> GetAsync(int id) => await _dbContext.Notes.AsNoTracking().SingleAsync(obj => obj.Id == id);

    public async Task UpdateAsync(int id, Note obj)
    {
        _dbContext.Notes.Entry(await _dbContext.Notes.SingleAsync(note => note.Id == id)).CurrentValues.SetValues(obj);
        await _dbContext.SaveChangesAsync();
    }
}
