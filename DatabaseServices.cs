using System;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using PizzaProjectBlank.Models;

namespace PizzaProjectBlank;

public class DatabaseServices : DbContext
{
    public DbSet<Pizza> Pizza { get; set; }
    public DbSet<Order> Order { get; set; }
    public DbSet<Ingredient> Ingredient { get; set; }
    
    public DatabaseServices()
    {
        Database.EnsureCreated();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var folder = Environment.SpecialFolder.MyDocuments;
        string folderPath = Environment.GetFolderPath(folder);
        string filePath = System.IO.Path.Join(folderPath, "pizza.db");
        SqliteConnectionStringBuilder builder = new() { DataSource = filePath };

        optionsBuilder.UseSqlite((builder.ConnectionString));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Pizza>().HasData(
            new Pizza(1, "Margharita", 189.00),
            new Pizza(2, "Proscuitto", 199.00),
            new Pizza(3, "Hawai", 199.00),
            new Pizza(4, "Quatro Formaggi", 219.00));
        
        modelBuilder.Entity<Ingredient>().HasData(
            new Ingredient(1, "Olives", 19.00),
            new Ingredient(2, "Cheese", 15.00),
            new Ingredient(3, "Pineapple", 25.00),
            new Ingredient(4, "Corn", 9.00));
    }
}
