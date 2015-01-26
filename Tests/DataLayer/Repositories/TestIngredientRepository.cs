using System.Collections.Generic;
using System.Linq;
using DataLayer.Entities;
using DataLayer.Repositories.Dishes;
using DataLayer.Repositories.Ingredients;
using Moq;
using NUnit.Framework;
using Tests.FakeData;

namespace Tests.DataLayer.Repositories
{
    public class TestIngredientRepository
    {
        private IIngredientsRepository _ingredientsRepository;
        private Mock<FakeDbContext> _contextMock;

        [SetUp]
        public void SetUp()
        {
            var ingredients = new FakeDbSet<Ingredient>();

            var dishes = new FakeDbSet<Dish>();

            var dishesCategories = new FakeDbSet<DishCategory>();

            var ingredientsCategories = new FakeDbSet<IngredientCategory>();

            ingredientsCategories = new FakeDbSet<IngredientCategory>
            {
                new IngredientCategory()
                {
                    Name = "Test ingredientCategory 1",
                    ID = 1
                    
                },

                 new IngredientCategory()
                {
                    Name = "Test ingredientCategory 2",
                    ID = 2
                },

                 new IngredientCategory()
                {
                    Name = "Test ingredientCategory 3",
                    ID = 3
                },
            };



            ingredients = new FakeDbSet<Ingredient>
            {
                new Ingredient
                {
                    Name = "Test ingredient 1",
                    ID = 1,
                    Dishes = dishes.Where(d => d.ID == 2 || d.ID == 3).ToList(),
                    Category = ingredientsCategories.FirstOrDefault(x => x.ID==1)
                },
                new Ingredient
                {
                    Name = "Test ingredient 2",
                    ID = 2,
                    Dishes = dishes.Where(d => d.ID == 1 || d.ID == 4).ToList(),
                     Category = ingredientsCategories.FirstOrDefault(x => x.ID==2)
                },
                new Ingredient
                {
                    Name = "Test ingredient 3",
                    ID = 3,
                    Dishes = dishes.Where(d => d.ID == 3 || d.ID == 4).ToList(),
                     Category = ingredientsCategories.FirstOrDefault(x => x.ID==3)
                },
                new Ingredient
                {
                    Name = "Test ingredient 4",
                    ID = 4,
                    Dishes = dishes.Where(d => d.ID == 1 || d.ID == 2).ToList(),
                    Category = ingredientsCategories.FirstOrDefault(x => x.ID==3)
                },
            };

            dishesCategories = new FakeDbSet<DishCategory>()
            {
                new DishCategory()
                {
                    Name = "Test dish category 1",
                    ID = 1,
                    Dishes = dishes.Where(d => d.ID == 1 || d.ID == 2).ToList()
                },

                new DishCategory()
                {
                    Name = "Test dish category 2",
                    ID = 2,
                    Dishes = dishes.Where(d => d.ID == 3 || d.ID == 4).ToList()
                },

                new DishCategory()
                {
                    Name = "Test dish category 3",
                    ID = 3,
                    Dishes = dishes.Where(d => d.ID == 5 || d.ID == 6).ToList()
                },

                new DishCategory()
                {
                    Name = "Test dish category 4",
                    ID = 4,
                     Dishes = new List<Dish>()
                }

            };


            dishes =
            new FakeDbSet<Dish>
            {
                new Dish
                {
                    Name = "Test dish 1",
                    ID = 1,
                    Ingredients = ingredients.ToList(),
                    Categories = dishesCategories.Where(x=> x.ID==1).ToList()
                },
                new Dish
                {
                    Name = "Test dish 2",
                    ID = 2,
                    Ingredients = ingredients.Where(i => i.ID == 4 || i.ID==1).ToList(),
                    Categories = dishesCategories.Where(x=> x.ID==1).ToList()
                },
                new Dish
                {
                    Name = "Test dish 3",
                    ID = 3,
                    Ingredients = ingredients.Where(i => i.ID == 3 || i.ID==1).ToList(),
                    Categories = dishesCategories.Where(x=> x.ID==2).ToList()
                },
                new Dish
                {
                    Name = "Test dish 4",
                    ID = 4,
                    Ingredients = ingredients.Where(i => i.ID == 3 || i.ID==2).ToList(),
                    Categories = dishesCategories.Where(x=> x.ID==2).ToList()
                },
                new Dish
                {
                    Name = "Test dish 5",
                    ID = 5,
                    Ingredients = new List<Ingredient>(),
                    Categories = dishesCategories.Where(x=> x.ID==3).ToList()
                },
                new Dish
                {
                    Name = "Test dish 6",
                    ID = 6,
                    Ingredients = new List<Ingredient>(),
                    Categories = dishesCategories.Where(x=> x.ID==3).ToList()
                }
            };


            _contextMock = new Mock<FakeDbContext>();
            _contextMock.Setup(x => x.Dishes).Returns(dishes);
            _contextMock.Setup(i => i.Ingredients).Returns(ingredients);
            _contextMock.Setup(d => d.DishCategories).Returns(dishesCategories);
            _contextMock.Setup(e => e.IngredientCategories).Returns(ingredientsCategories);

            //_repository = DependencyResolver.Current.GetService<IDishesRepository>(_contextMock);
           
            _ingredientsRepository = new IngredientsRepository(_contextMock.Object);

        }

        [Test]
        public void Test_GetIngredients()
        {

            Assert.IsTrue(_ingredientsRepository.GetIngredients().Count() == 4);
        }

        [Test]
        public void Test_GetIngredintCategories()
        {
            Assert.IsTrue(_ingredientsRepository.GetCategories().Count()==3);
        }

 

    }
}