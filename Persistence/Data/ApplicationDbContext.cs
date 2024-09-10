using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Persistence.Models;

namespace Persistence.Data;

class ApplicationDbContext : DbContext
{
    public DbSet<Note> Notes { get; set; }

    private readonly IConfiguration _configuration;

    public ApplicationDbContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlServer(_configuration["ConnectionStrings:DefaultConnection"]);
    }
}
