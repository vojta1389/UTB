using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace PizzaProjectBlank.Models;

public class Pizza
{
    public int PizzaId { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }

    public Pizza(int id, string name, double price)
    {
        PizzaId = id;
        Name = name;
        Price = price;
    }

    public Pizza()
    {
        
    }
}





