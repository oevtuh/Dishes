using System;
using System.Collections.Generic;
using Models;

namespace DataLayer.Repositories.Dishes
{
    public interface IDishesRepository
    {
        IEnumerable<Dish> GetDishes(int ingredientId);
        IEnumerable<Dish> GetDishes();
        Dish GetDish(int id);
        IEnumerable<Dish> GetDishes(IEnumerable<int> ingredients);
     

    }

    
}