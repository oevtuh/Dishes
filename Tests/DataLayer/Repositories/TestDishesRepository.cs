using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web.Mvc;
using DataLayer.Entities;
using DataLayer.Repositories.Dishes;
using DataLayer.Repositories.Ingredients;
using Dishes.Controllers;
using Moq;
using Ninject;
using NUnit.Framework;
using Tests.FakeData;

namespace Tests.DataLayer.Repositories
{

    public class TestDishesRepository
    {
        private IDishesRepository r;
        private IDishesRepository _repository;
        
        private FakeDbContext s;
        private Mock<FakeDbContext> _contextMock;
        private DishesController c;
        //private List<> 


        [SetUp]
        public void SetUp()
        {
            var ingredients = new FakeDbSet<Ingredient>();

            var dishes = new FakeDbSet<Dish>();

            var dishesCategories = new FakeDbSet<DishCategory>();

            

            ingredients = new FakeDbSet<Ingredient>
            {
                new Ingredient
                {
                    Name = "Test ingredient 1",
                    ID = 1,
                    Dishes = dishes.Where(d => d.ID == 2 || d.ID == 3).ToList()
                },
                new Ingredient
                {
                    Name = "Test ingredient 2",
                    ID = 2,
                    Dishes = dishes.Where(d => d.ID == 1 || d.ID == 4).ToList()
                },
                new Ingredient
                {
                    Name = "Test ingredient 3",
                    ID = 3,
                    Dishes = dishes.Where(d => d.ID == 3 || d.ID == 4).ToList()
                },
                new Ingredient
                {
                    Name = "Test ingredient 4",
                    ID = 4,
                    Dishes = dishes.Where(d => d.ID == 1 || d.ID == 2).ToList()
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


            dishes = new FakeDbSet<Dish>
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
            _contextMock.Setup(i => i.Ingredients).Returns(ingredients);
            _contextMock.Setup(d => d.DishCategories).Returns(dishesCategories);
            _contextMock.Setup(x => x.Dishes).Returns(dishes);
            
            
            

           
        }
        
        public void SetUp2()
        {
            var ingredients = new FakeDbSet<Ingredient>();

            var dishes = new FakeDbSet<Dish>();

            var dishesCategories = new FakeDbSet<DishCategory>();




            _contextMock = new Mock<FakeDbContext>();
            _contextMock.Setup(x => x.Dishes).Returns(dishes);
            _contextMock.Setup(i => i.Ingredients).Returns(ingredients);
            _contextMock.Setup(d => d.DishCategories).Returns(dishesCategories);
        }

        [SetUp]
        public void Setup2()
        {
           

            //_repository = DependencyResolver.Current.GetService<IDishesRepository>(_contextMock);
            _repository = new DishesRepository(_contextMock.Object);
        }


        [Test]
        public void Test_GetDishes()
        {
            //Assert.IsTrue(_repository.GetDish(1).Ingredients.Count() == 2);
            //Assert.IsTrue(!_repository.GetDish(5).Ingredients.Any());

            var x = _repository.GetDish(1);

            Assert.IsNotNull(_repository.GetDish(1));
            Assert.IsTrue(_repository.GetDishes().Count() == 6);
        }

        [Test]
        public void Test_GetDishesByingredients()
        {
            //Assert.IsTrue(_repository.GetDish(1).Ingredients.Count() == 2);
            //Assert.IsTrue(!_repository.GetDish(5).Ingredients.Any());
            int[] arrayEmpty = new int[] {};
            int[] array = new int[] {2, 3};
            int[] arrayWrong = new[] {8, 6, 9};
           

            Assert.IsTrue(_repository.GetDishes(arrayEmpty).Count() == 2);

            Assert.IsTrue(_repository.GetDishes(array).Count() == 3);//  4, 5, 6

            Assert.IsTrue(_repository.GetDishes(arrayWrong).Count()==2);
        }

        

        [Test]
        public void Test_GetDishesCategories()
        {
           
            Assert.IsTrue(_repository.GetCategories().Count()==4);
        }

        [Test]
        public void Test_GetDishesByCategory()
        {
         
            Assert.IsTrue(_repository.GetDishesByCategory(1).Count()== 2);
            Assert.IsFalse(_repository.GetDishesByCategory(5).Any());
        }

        [Test]
        public void Test_GetIngredintsInDish()
        {
            var y = _repository.GetDish(2);
            var x = _repository.GetDish(1).Ingredients;

            Assert.IsTrue(_repository.GetDish(1).Ingredients.Count() == 4);

        }
        
        
    }

    public partial class MockRepository : Mock<IDishesRepository>
    {
        private FakeDbSet<Ingredient> ingredients;

        private FakeDbSet<Dish> dishes;
        public MockRepository(MockBehavior mockBehavior = MockBehavior.Strict)
            : base(mockBehavior)
        {
            GenerateDishes();
           

        }
    }

    public partial class MockRepository
    {
        


        public void GenerateDishes()
        {
            ingredients = new FakeDbSet<Ingredient>();

            dishes = new FakeDbSet<Dish>();

            ingredients = new FakeDbSet<Ingredient>
            {
                new Ingredient
                {
                    Name = "Test ingredient 1",
                    ID = 1,
                    Dishes = dishes.Where(d => d.ID == 2 || d.ID == 3).ToList()
                },
                new Ingredient
                {
                    Name = "Test ingredient 2",
                    ID = 2,
                    Dishes = dishes.Where(d => d.ID == 1 || d.ID == 4).ToList()
                },
                new Ingredient
                {
                    Name = "Test ingredient 3",
                    ID = 3,
                    Dishes = dishes.Where(d => d.ID == 3 || d.ID == 4).ToList()
                },
                new Ingredient
                {
                    Name = "Test ingredient 4",
                    ID = 4,
                    Dishes = dishes.Where(d => d.ID == 1 || d.ID == 2).ToList()
                },
            };

            dishes =
            new FakeDbSet<Dish>
            {
                new Dish
                {
                    Name = "Test dish 1",
                    ID = 1,
                    Ingredients = ingredients.ToList()
                },
                new Dish
                {
                    Name = "Test dish 2",
                    ID = 2,
                    Ingredients = ingredients.Where(i => i.ID == 4 || i.ID==1).ToList()
                },
                new Dish
                {
                    Name = "Test dish 3",
                    ID = 3,
                    Ingredients = ingredients.Where(i => i.ID == 3 || i.ID==1).ToList()
                },
                new Dish
                {
                    Name = "Test dish 4",
                    ID = 4,
                    Ingredients = ingredients.Where(i => i.ID == 3 || i.ID==2).ToList()
                },
                new Dish
                {
                    Name = "Test dish 5",
                    ID = 5,
                    Ingredients = new List<Ingredient>()
                },
                new Dish
                {
                    Name = "Test dish 6",
                    ID = 6,
                    Ingredients = new List<Ingredient>()
                }
            };
        }
    }
}