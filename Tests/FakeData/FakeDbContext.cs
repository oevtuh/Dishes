using System.Data.Entity;
using DataLayer.Entities;

namespace Tests.FakeData
{
    public class FakeDbContext : IDishesContext
    {
        //public IDbSet<Dish> Dishes
        //{
        //    get
        //    {
        //        return new FakeDbSet<Dish>
        //        {
        //            new Dish
        //            {
        //                ID = 1,
        //                Name = "Test Dish"
        //            }
        //        };
        //    }
        //    set
        //    {
                
        //    } 
        //}
       
        public virtual IDbSet<Dish> Dishes { get; set; }

        public virtual IDbSet<Ingredient> Ingredients { get; set; }
        public virtual IDbSet<DishCategory> DishCategories { get; set; }
        public virtual IDbSet<IngredientCategory> IngredientCategories { get; set; }

        public void SaveChanges()
        {
            
        }
    }
}