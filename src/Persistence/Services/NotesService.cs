using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Persistence.Exceptions;
using Persistence.Models;
using Persistence.Repositories.IRepositories;

namespace Persistence.Services;

public class NotesService
{
    private readonly INotesRepository _repository;

    public NotesService(INotesRepository repository)
    {
        _repository = repository;
    }

    public async Task<Note> AddAsync(Note obj) => await _repository.AddAsync(obj);

    public async Task DeleteAsync(int id)
    {
        if (! await _repository.ExistsAsync(id))
            throw new NotFoundException();
        await _repository.DeleteAsync(id);
    }

    public async Task<IEnumerable<Note>> GetAsync() => await _repository.GetAsync();

    public async Task<Note> GetAsync(int id)
    {
        if (! await _repository.ExistsAsync(id))
            throw new NotFoundException();
        return await _repository.GetAsync(id);
    }

    public async Task UpdateAsync(int id, Note obj)
    {
        if (id != obj.Id)
            throw new BadRequestException();
        if (! await _repository.ExistsAsync(id))
            throw new NotFoundException();
        await _repository.UpdateAsync(id, obj);
    }
}
