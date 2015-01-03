using System.Collections.Generic;

namespace DataLayer.Entities
{
    public class DishCategory
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public virtual ICollection<Dish> Dishes { get; set; }  
    }
}