using System.Collections;
using System.Collections.Generic;

namespace Models
{
    public class DishCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }

        public virtual IEnumerable<Dish> Dishes { get; set; }  
        
    }
}