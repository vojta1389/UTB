using System.Collections.Generic;

namespace PizzaProjectBlank.Models;

public class Order
{
    public int OrderId { get; set; }    // Primary Key
    public bool Favorite { get; set; } = false;


    public int PizzaId { get; set; }
    public Pizza Pizza { get; set; }
    public ICollection<Ingredient>? ExtraIngredients { get; set; }

    public Order(int orderId, bool favorite, Pizza pizza)
    {
        OrderId = orderId;
        Favorite = favorite;
        Pizza = pizza;
    }

    public Order()
    {
        
    }
}