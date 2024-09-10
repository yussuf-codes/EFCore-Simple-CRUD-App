using System.Collections.Generic;
using System.Threading.Tasks;
using Persistence.Models.Abstractions;

namespace Persistence.Repositories.IRepositories;

interface IGenericRepository<T> where T: BaseModel
{
    Task<T> AddAsync(T obj);
    void DeleteAsync(int id);
    Task<bool> ExistsAsync(int id);
    Task<IEnumerable<T>> GetAsync();
    Task<T> GetAsync(int id);
    void UpdateAsync(int id, T obj);
}
