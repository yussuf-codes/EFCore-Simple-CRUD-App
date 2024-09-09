using Microsoft.EntityFrameworkCore;
using Models;

namespace Persistence;

class ApplicationDbContext : DbContext
{
    private static string _connectionString = ""; 
    protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseSqlServer(_connectionString);
    public DbSet<Note> Notes { get; set; }
}
