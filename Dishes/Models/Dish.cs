using System.Collections;
using System.Collections.Generic;


namespace Dishes.Models
{
    public class Dish
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }

        public IEnumerable<Ingredient> Ingredients;

        

    }
}