using System.Collections.Generic;
using System.Linq;
using DataLayer.Entities;
using Dish = Models.Dish;
using Ingredient = Models.Ingredient;
using DishCategory = Models.DishCategory;


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
                    Categories = x.Categories.Select(i => new DishCategory
                    {
                        Id = i.ID,
                        Name = i.Name
                    }),
                    Description = x.Description,
                    ShortDescription = x.ShortDescription,
                    Name = x.Name,
                    Image = x.Image
                });
        }

        public IEnumerable<Dish> GetDishes()
        {
            return _context.Dishes.Select(x=> new Models.Dish
               {Id = x.ID, 
                Description = x.Description,
                ShortDescription = x.ShortDescription,
                Name = x.Name,
                Image = x.Image 
               }).ToList();
        }

        public Dish GetDish(int id)
        {

            return _context.Dishes.Select(x => new Models.Dish
            {
                Id = x.ID,
                Description = x.Description,
                ShortDescription = x.ShortDescription,
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
                    ShortDescription = x.ShortDescription,
                    Name = x.Name,
                    Image = x.Image
                }).ToList();
        }

       
        public void AddDish(Dish dish)
        {
            _context.Dishes.Add(new Entities.Dish
            {
                Name = dish.Name
            });

            _context.SaveChanges();
        }


        public IEnumerable<DishCategory> GetCategories()
        {


            return _context.DishCategories.Select(x => new DishCategory
            {
                Id = x.ID,
                Name = x.Name,
                Image = x.Image
                //Dishes = x.Dishes.Select(d => new Dish
                //{
                //    Id = d.ID,
                //    Description = d.Description,
                //    ShortDescription = d.ShortDescription,
                //    Name = d.Name,
                //    Image = d.Image
                //}),
                //Dishes = _context.Dishes.Where(y => y.Categories.Any(v => v.ID == x.ID)).Select(p => new Models.Dish
                //{
                //    Id = p.ID,
                //    Description = p.Description,
                //    ShortDescription = p.ShortDescription,
                //    Name = x.Name,
                //    Image = x.Image
                //})
            }).ToList();



        }

        public IEnumerable<Dish> GetDishesByCategory(int categoryId)
        {
            var dishes =  _context.Dishes.Where(x => x.Categories.Any(c => categoryId==0 || c.ID == categoryId))
                .Select(x => new Dish
                {
                    Id = x.ID,
                    Image = x.Image,
                    Description = x.Description,
                    Name = x.Name,
                    ShortDescription = x.ShortDescription
                }).ToList();

            return dishes;
        }
    }
}