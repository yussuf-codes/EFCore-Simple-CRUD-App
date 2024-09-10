using Persistence.Models.Abstractions;

namespace Persistence.Models;

class Note : BaseModel
{
    public required string Title { get; set; }

    public required string Body { get; set; }
}
