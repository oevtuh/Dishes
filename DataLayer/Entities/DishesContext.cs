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
        }
    }
}