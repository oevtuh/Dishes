using System.Collections.Generic;
using System.Linq;

using DataLayer.Repositories.Dishes;
using Models;
using Moq;

namespace Tests
{
    public class MockRepository : Mock<IDishesRepository>
    {
        public MockRepository(MockBehavior mockBehavior = MockBehavior.Strict)
            : base(mockBehavior)
        {
            GenerateDishes();

        }

         public List<Dish> Dishes { get; set; }


        public void GenerateDishes()
        {
            Dishes = new List<Dish>();
            Dishes.Add(new Dish()
            {
                Id = 1,
                Name = "English"
            });
            Dishes.Add(new Dish()
            {
                Id = 2,
                Name = "Русский"
            });

            this.Setup(p => p.GetDishes()).Returns(Dishes.AsQueryable());
        }
    }
    }
