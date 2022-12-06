using System.Collections.Generic;

namespace PizzaProjectBlank.Models;

public class Ingredient
{
    public int IngredientId { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }
    public List<Order>? Order { get; set; }

    public Ingredient(int ingredientId, string name, double price)
    {
        IngredientId = ingredientId;
        Name = name;
        Price = price;
    }
}