using System.Collections.Generic;

namespace PizzaProjectBlank.Models;

public class Order
{
    public int OrderId { get; set; }
    public bool Favorite { get; set; } = false;
    public Pizza Pizza { get; set; }
    public List<Ingredient>? Ingredient { get; set; }
}