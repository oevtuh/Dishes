using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using DataLayer.Entities;
using DataLayer.Repositories.Dishes;
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

        public TestDishesRepository()
        {




        }

        [SetUp]
        public void SetUp()
        {
            var ingredients = new FakeDbSet<Ingredient>();

            var dishes = new FakeDbSet<Dish>();

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

            _contextMock = new Mock<FakeDbContext>();
            _contextMock.Setup(x => x.Dishes).Returns(dishes);
            _contextMock.Setup(c => c.Ingredients).Returns(ingredients);

            //_repository = DependencyResolver.Current.GetService<IDishesRepository>(_contextMock);
            _repository = new DishesRepository(_contextMock.Object);


            s = new FakeDbContext();
            s.Dishes = new FakeDbSet<Dish>();

            s.Dishes.Add(new Dish()
            {
                ID = 1,
                Name = "One"
            });

            s.Dishes.Add(new Dish()
            {
                ID = 2,
                Name = "Two"
            });

            s.Dishes.Add(new Dish()
            {
                ID = 3,
                Name = "Three"
            });

            r = new DishesRepository(s);

            InitKernel();
        }

        protected virtual IKernel InitKernel()
        {
            var kernel = new StandardKernel();
            DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));
            //InitRepository(kernel); //потом сделаем
            return kernel;
        }

        protected virtual void InitRepository(StandardKernel kernel)
        {
            kernel.Bind<MockRepository>().To<MockRepository>().InThreadScope();
            kernel.Bind<IDishesRepository>().ToMethod(p => kernel.Get<MockRepository>().Object);
        }

        [Test]
        public void Test_GetDishes()
        {
            //Assert.IsTrue(_repository.GetDish(1).Ingredients.Count() == 2);
            //Assert.IsTrue(!_repository.GetDish(5).Ingredients.Any());

            Assert.IsNotNull(_repository.GetDish(1));
            Assert.IsTrue(_repository.GetDishes().Count() == 6);
        }

        //[Test]
        //public void Test_two()
        //{

        //    Mock<IDishesRepository> mock = new Mock<IDishesRepository>();
        //    mock.Setup(m => m.GetDishes()).Returns(new Models.Dish[] { 
        //    new Models.Dish {Id = 1, Name = "P1"}, 
        //    new Models.Dish {Id = 2, Name = "P2"}, 
        //    new Models.Dish {Id = 3, Name = "P3"}, 
        //    new Models.Dish {Id = 4, Name = "P4"}, 
        //    new Models.Dish {Id = 5, Name = "P5"} 
        //    }.AsQueryable());

        //    DishesController controller = new DishesController(mock.Object);

        //    Models.Dish[] arr = (Models.Dish[])controller.DishesInCategory().Model;
        //    Assert.IsTrue(arr.Count() == 5);

        //}
    }
}