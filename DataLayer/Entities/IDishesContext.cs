using System.Collections.Generic;
using System.Data.Entity;

namespace DataLayer.Entities
{
    public interface IDishesContext
    {
        DbSet<Dish> Dishes { get; set; }
        DbSet<Ingredient> Ingredients { get; set; }
        DbSet<DishCategory> DishCategories { get; set; }
        DbSet<IngredientCategory> IngredientCategories { get; set; }
    }
}