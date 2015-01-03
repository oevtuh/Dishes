//using System.Data.Entity;
//using DataLayer.Entities;

//namespace Tests.FakeData
//{
//    public class FakeDbContext : IDishesContext
//    {
//        public DbSet<Dish> Dishes {
//            get
//            {
//                return new DbSet<Dish>
//                {
//                    new Dish
//                    {
//                        Description = "Desc"
//                    }
//                };
//            };
//            set { } ;
//        }
//        public DbSet<Ingredient> Ingredients { get; set; }
//        public DbSet<DishCategory> DishCategories { get; set; }
//        public DbSet<IngredientCategory> IngredientCategories { get; set; }

//        public void SaveChanges()
//        {
//            throw new System.NotImplementedException();
//        }
//    }
//}