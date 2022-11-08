using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Avalonia.Controls.Shapes;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.FileIO;
using PizzaProjectBlank.Models;
using Path = System.IO.Path;

namespace PizzaProjectBlank;

public class DatabaseServices : DbContext
{
    private DbSet<Pizza> Pizza { get; set; }
    private DbSet<Order> Order { get; set; }
    private DbSet<Ingredient> Ingredient { get; set; }

    private readonly string _dbName = "Pizza.db";
    
    public DatabaseServices()
    {
        this.Database.EnsureCreated();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string dbPath = Path.Combine(FileSystem.CurrentDirectory, _dbName);
        optionsBuilder.UseSqlite($"Filename={dbPath}");  // Where database is saved
    }
    
    public async Task<List<Pizza>> GetPizzas() 
    {
        await using DatabaseServices connection = new DatabaseServices();
        List<Pizza> pizzas = connection.Pizza.ToList();

        return pizzas;
    }
    
    public async Task<List<Ingredient>> GetIngredient()
    {
        await using DatabaseServices connection = new DatabaseServices();
        List<Ingredient> ingredients = connection.Ingredient.ToList();

        return ingredients;
    }
    
    public async Task<List<Order>> GetOrders()
    {
        await using var connection = new DatabaseServices();
        List<Order> orders = connection.Order.ToList();

        return orders;
    }
    
    public async Task Insert<T>(T item)
    {
        await using DatabaseServices connection = new DatabaseServices();
        
        if (item != null)
        {
            connection.Add(item);
        }

        try
        {
            await connection.SaveChangesAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine($"Entering: {item.ToString()} ERROR: {e}");
        }
        
    }
}