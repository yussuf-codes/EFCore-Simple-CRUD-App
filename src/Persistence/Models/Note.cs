using Persistence.Models.Abstractions;

namespace Persistence.Models;

public class Note : BaseModel
{
    public required string Title { get; set; }

    public required string Body { get; set; }
}
