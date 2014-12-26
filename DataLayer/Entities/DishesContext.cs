using System.Data.Entity;

namespace DataLayer.Entities
{
    public class DishesContext : DbContext, IDishesContext
    {
        public DishesContext(): 
            base("dishes10")
        {
            
        }
        public DbSet<Dish> Dishes { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<DishCategory> DishCategories { get; set; }
        public DbSet<IngredientCategory> IngredientCategories { get; set; }
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