using System.Collections.Generic;
using Models;

namespace DataLayer.Repositories.Ingredients
{
    public interface IIngredientsRepository
    {
        IEnumerable<IngredientCategory> GetCategories();

        IEnumerable<Ingredient> GetIngredients();
        //IEnumerable<Ingredient> GetCategoryByCategoryId(int id);
    }
}