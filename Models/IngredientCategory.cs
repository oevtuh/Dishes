using System.Collections.Generic;

namespace Models
{
    public class IngredientCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public IEnumerable<Ingredient> Ingredients;
    }
}