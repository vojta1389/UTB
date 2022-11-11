using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace PizzaProjectBlank.Models;

public class Pizza
{
    public int PizzaId { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }
    
    public Pizza(int pizzaId, string name, double price)
    {
        PizzaId = pizzaId;
        Name = name;
        Price = price;
    }
}





