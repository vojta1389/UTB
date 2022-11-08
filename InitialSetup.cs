// This file will setup initial database and pizza + ingredient list in case database doesn't exist

using System;
using Path = System.IO.Path;
using Microsoft.VisualBasic.FileIO;
using PizzaProjectBlank.Models;

namespace PizzaProjectBlank;

public class InitialSetup
{
    private string _dbPath = Path.Combine(FileSystem.CurrentDirectory, "Pizza.db");
    
    public InitialSetup()
    {
        // Data filling

        if (!FileSystem.FileExists(Path.Combine(_dbPath)))
        {
            DatabaseServices _databaseServices = new DatabaseServices();

            _databaseServices.Insert(new Pizza(1, "Margharita", 189.00));
            _databaseServices.Insert(new Pizza(2, "Proscuitto", 199.00));
            _databaseServices.Insert(new Pizza(3, "Hawai", 199.00));
            _databaseServices.Insert(new Pizza(4, "Quatro Formaggi", 219.00));

            _databaseServices.Insert(new Ingredient(1, "Olives", 19.00));
            _databaseServices.Insert(new Ingredient(2, "Cheese", 15.00));
            _databaseServices.Insert(new Ingredient(3, "Pineapple", 25.00));
            _databaseServices.Insert(new Ingredient(4, "Corn", 9.00));   
        }
    }

}