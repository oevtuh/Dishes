using System.Collections.Generic;
using System.Linq;
using DataLayer.Entities;
using Dish = Models.Dish;
using Ingredient = Models.Ingredient;

namespace DataLayer.Repositories.Dishes
{
    public class DishesRepository : IDishesRepository
    {
        private readonly IDishesContext _context;

        public DishesRepository(IDishesContext context)
        {
            _context = context;
        }

        public IEnumerable<Dish> GetDishes(int ingredientId)
        {
            return _context.Dishes
                .Where(dish => dish.Ingredients.Any(x => x.ID == ingredientId))
                .Select(x => new Dish
                {
                    Id = x.ID,
                    Ingredients = x.Ingredients.Select(i => new Ingredient
                    {
                        Id = i.ID,
                        Name = i.Name,
                        Description = i.Description
                    }),
                    Description = x.Description,
                    Name = x.Name,
                    Image = x.Image
                });
        }

        public IEnumerable<Dish> GetDishes()
        {
            return _context.Dishes.Select(x=> new Models.Dish
               {Id = x.ID, 
                Description = x.Description,
                Name = x.Name,
                Image = x.Image 
               });
        }

        public Dish GetDish(int id)
        {

            return _context.Dishes.Select(x => new Models.Dish
            {
                Id = x.ID,
                Description = x.Description,
                Name = x.Name,
                Image = x.Image
            }).FirstOrDefault(dish => dish.Id == id);
            
        }

        public IEnumerable<Dish> GetDishes(IEnumerable<int> ingredients)
        {
            return _context.Dishes
                .Where(dish => dish.Ingredients.All(y => ingredients.Contains(y.ID))).
                Select(x => new Models.Dish
                {
                    Id = x.ID,
                    Description = x.Description,
                    Name = x.Name,
                    Image = x.Image
                });
        }

        public IEnumerable<Ingredient> GetIngredients()
        {
            return _context.Ingredients.Select(x => new Models.Ingredient()
            {
                Id = x.ID,
                Description = x.Description,
                Name = x.Name,
                
            });
        }

    }
}