using System.Collections.Generic;
using System.Threading.Tasks;
using Persistence.Exceptions;
using Persistence.Models;
using Persistence.Repositories.IRepositories;

namespace Persistence.Services;

class NotesService
{
    private readonly IGenericRepository<Note> _repository;

    public NotesService(IGenericRepository<Note> repository)
    {
        _repository = repository;
    }

    public async Task<Note> AddAsync(Note obj)
    {
        return await _repository.AddAsync(obj);
    }

    public async void DeleteAsync(int id)
    {
        if (await _repository.ExistsAsync(id))
            _repository.DeleteAsync(id);
        throw new NotFoundException();
    }

    public async Task<IEnumerable<Note>> GetAsync()
    {
        return await _repository.GetAsync();
    }

    public async Task<Note> GetAsync(int id)
    {
        if (await _repository.ExistsAsync(id))
            return await _repository.GetAsync(id);
        throw new NotFoundException();
    }

    public async void UpdateAsync(int id, Note newObj)
    {
        if (await _repository.ExistsAsync(id))
            _repository.UpdateAsync(id, newObj);
        throw new NotFoundException();
    }
}
