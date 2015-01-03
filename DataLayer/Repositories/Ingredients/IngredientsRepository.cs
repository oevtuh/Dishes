using System.Collections.Generic;
using System.Linq;
using DataLayer.Entities;
using IngredientCategory = Models.IngredientCategory;
using Ingredient = Models.Ingredient;


namespace DataLayer.Repositories.Ingredients
{
    public class IngredientsRepository : IIngredientsRepository
    {
          private readonly IDishesContext _context;

          public IngredientsRepository(IDishesContext context)
        {
            _context = context;
        }

          public IEnumerable<IngredientCategory> GetCategories()
          {
              //var temp = _context.Ingredients.All(t => t.ID == 5);

              return _context.IngredientCategories.Select(x => new IngredientCategory
              {
                  Id = x.ID,
                  Name = x.Name,



                  Ingredients = _context.Ingredients.Where(t => t.Category.ID == x.ID).Select(y => new Ingredient
                  {
                      Id = y.ID,
                      Name = y.Name,
                      

                  })

              });

          }

          //public IEnumerable<Ingredient> GetCategoryByCategoryId(int id)
          //{
          //    return _context.Ingredients.Where(i => i.ID==id).Select(x => new Ingredient
          //    {
          //        Id = x.ID,
          //        Name = x.Name

          //    });
          //}

        
        public IEnumerable<Ingredient> GetIngredients()
        {
            return _context.Ingredients.Select(x => new Ingredient()
            {
                Id = x.ID,
                Description = x.Description,
                Name = x.Name,

            }).ToList();
        }

     
    }
}