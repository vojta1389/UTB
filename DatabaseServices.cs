using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.FileIO;
using PizzaProjectBlank.Models;
using Path = System.IO.Path;

namespace PizzaProjectBlank;

public class DatabaseServices : DbContext
{
    public DbSet<Pizza> Pizza { get; set; }
    public DbSet<Order> Order { get; set; }
    public DbSet<Ingredient> Ingredient { get; set; }

    private readonly string _dbName = "Pizza.db";
    
    public DatabaseServices()
    {
        Database.EnsureCreated();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var dbPath = Path.Combine(FileSystem.CurrentDirectory, _dbName);
        optionsBuilder.UseSqlite($"Filename={dbPath}"); // Where database is saved
    }
}
