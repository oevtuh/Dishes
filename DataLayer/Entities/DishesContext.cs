using System.Data.Entity;

namespace DataLayer.Entities
{
    public class DishesContext : DbContext, IDishesContext
    {
        public DishesContext(): 
            base("dishes10")
        {
            
        }
        public IDbSet<Dish> Dishes { get; set; }
        public IDbSet<Ingredient> Ingredients { get; set; }
        public IDbSet<DishCategory> DishCategories { get; set; }
        public IDbSet<IngredientCategory> IngredientCategories { get; set; }
        new public void SaveChanges()
        {
            base.SaveChanges();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
           modelBuilder.Entity<Ingredient>().HasMany(c => c.Dishes).

           WithMany(p => p.Ingredients).
           Map(
           m =>
           {
               m.MapLeftKey("IngredientId");
               m.MapRightKey("DishId");
               m.ToTable("DishIngredients");
            });


          //modelBuilder.Entity<DishCategory>().HasMany(c => c.Dishes).

          //WithMany(p => p.Categories).
          //Map(
          //m =>
          //{
          //    m.MapLeftKey("CategoryId");
          //    m.MapRightKey("DishId");
          //    m.ToTable("DishCategories");
          //});


        }



    }
}