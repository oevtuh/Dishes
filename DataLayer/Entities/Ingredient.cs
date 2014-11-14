using System.Collections.Generic;

namespace DataLayer.Entities
{
    public class Ingredient
    {
            public int ID { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public virtual IEnumerable<Dish> Dishes { get; set; } 

    }
}