using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using PizzaProjectBlank.Models;

namespace PizzaProjectBlank;

public class MainViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;
    private readonly DatabaseServices _databaseServices = new DatabaseServices();

    private Order? _finalOrder;
    public Order? FinalOrder
    {
        get => _finalOrder;
        set
        {
            _finalOrder = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(FinalOrder)));
        }
    }

    private List<Pizza>? _pizzaList;
    public List<Pizza>? PizzaList
    {
        get => _pizzaList;
        set
        {
            _pizzaList = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(PizzaList)));
        }
    }

    private Pizza? _selectedPizza;
    public Pizza? SelectedPizza
    {
        get => _selectedPizza;
        set
        {
            _selectedPizza = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedPizza)));
        }
    }
    
    private List<Ingredient>? _ingredients;
    public List<Ingredient>? Ingredients
    {
        get => _ingredients;
        set
        {
            _ingredients = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Ingredients)));
        }
    }

    private List<Ingredient> _extraIngredients = new List<Ingredient>();
    public List<Ingredient> ExtraIngredient
    {
        get => _extraIngredients;
        set
        {
            _extraIngredients = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ExtraIngredient)));   // Might not be needed if we dont use it in UI
        }
    }

    public void LoadPizzas()
    {
        PizzaList = _databaseServices.GetPizzas().Result;
        SelectedPizza = PizzaList?.FirstOrDefault();
    }
    
    public void LoadIngredients()
    {
        Ingredients = _databaseServices.GetIngredient().Result;
    }
    
    public void AddIngredient(Ingredient ingredient)
    {
        if (!ExtraIngredient.Contains(ingredient))
        {
            ExtraIngredient?.Add(ingredient);    
        }
        else
        {
            ExtraIngredient.Remove(ingredient);
        }
    }

    public async Task OrderPizza()
    {
        FinalOrder = new Order();
        DatabaseServices _databaseServices = new DatabaseServices();
        
        if (_selectedPizza != null)
        {
            FinalOrder.PizzaId = _selectedPizza.PizzaId;
            FinalOrder.Pizza = _selectedPizza;
        }
        
        if (ExtraIngredient != null)    // Maybe cancel IF later
        {
            FinalOrder.ExtraIngredients = ExtraIngredient;
        }
        await _databaseServices.Insert(FinalOrder);
    }
}