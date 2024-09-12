using System.Collections.Generic;
using System.Threading.Tasks;
using Persistence.Models;

namespace Persistence.Repositories.IRepositories;

public interface INotesRepository
{
    Task<Note> AddAsync(Note obj);
    Task DeleteAsync(int id);
    Task<bool> ExistsAsync(int id);
    Task<IEnumerable<Note>> GetAsync();
    Task<Note> GetAsync(int id);
    Task UpdateAsync(int id, Note obj);
}
