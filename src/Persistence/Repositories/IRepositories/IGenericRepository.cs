using System.Collections.Generic;
using System.Threading.Tasks;
using Persistence.Models.Abstractions;

namespace Persistence.Repositories.IRepositories;

public interface IGenericRepository<T> where T: BaseModel
{
    Task<T> AddAsync(T obj);
    Task DeleteAsync(int id);
    Task<bool> ExistsAsync(int id);
    Task<IEnumerable<T>> GetAsync();
    Task<T> GetAsync(int id);
    Task UpdateAsync(int id, T obj);
}
