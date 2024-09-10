using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Persistence.Models;
using Persistence.Data;
using Persistence.Repositories.IRepositories;

namespace Persistence.Repositories;

class NotesRepository : IGenericRepository<Note>
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

    public async void DeleteAsync(int id)
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

    public async Task<IEnumerable<Note>> GetAsync()
    {
        return await _dbContext.Notes.AsNoTracking().ToListAsync();
    }

    public async Task<Note> GetAsync(int id)
    {
        return await _dbContext.Notes.AsNoTracking().SingleAsync(obj => obj.Id == id);
    }

    public async void UpdateAsync(int id, Note newObj)
    {
        Note existingObj = await _dbContext.Notes.SingleAsync(obj => obj.Id == id);
        _dbContext.Notes.Entry(existingObj).CurrentValues.SetValues(newObj);
        await _dbContext.SaveChangesAsync();
    }
}
