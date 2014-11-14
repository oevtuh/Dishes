using System.Data.Entity;

namespace DataLayer.Entities
{
    public class DishesContext: DbContext
    {
        public DishesContext(): base("DishesContext")
        {
            
        }
        public DbSet<Dish> Dishes { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            
        }
    }
}