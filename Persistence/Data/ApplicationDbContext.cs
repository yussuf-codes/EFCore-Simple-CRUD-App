using Microsoft.EntityFrameworkCore;
using Persistence.Models;

namespace Persistence.Data;

public class ApplicationDbContext : DbContext
{
    public DbSet<Note> Notes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer();
    }
}
