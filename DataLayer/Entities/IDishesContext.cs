using System.Collections.Generic;
using System.Data.Entity;

namespace DataLayer.Entities
{
    public interface IDishesContext
    {
        IDbSet<Dish> Dishes { get; set; }
        IDbSet<Ingredient> Ingredients { get; set; }
        IDbSet<DishCategory> DishCategories { get; set; }
        IDbSet<IngredientCategory> IngredientCategories { get; set; }
        void SaveChanges();
    }
}