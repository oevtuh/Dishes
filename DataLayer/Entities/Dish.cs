using System.Collections.Generic;

namespace DataLayer.Entities
{
    public class Dish
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public virtual IEnumerable<Ingredient> Ingredients { get; set; } 
    }
}