using System;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Persistence.Models;

namespace Persistence.Data;

public class ApplicationDbContext : DbContext
{
    public DbSet<Note> Notes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        IConfigurationBuilder configurationBuilder = new ConfigurationBuilder()
        .AddUserSecrets(Assembly.GetExecutingAssembly());

        IConfiguration configuration = configurationBuilder.Build();

        string? connectionString = configuration["ConnectionStrings:DefaultConnection"];

        if (connectionString is null)
            throw new NullReferenceException("Connection string is null");

        optionsBuilder.UseSqlServer(connectionString);
    }
}
