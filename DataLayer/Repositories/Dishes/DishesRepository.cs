using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using Models;

namespace DataLayer.Repositories.Dishes
{
    public class DishesRepository : IDishesRepository
    {
        private readonly IEnumerable<Dish> _dishes;

        public DishesRepository()
        {
            _dishes = new List<Dish>
            {
                
                new Dish
                {
                    Id = 1,
                    Name = "Борщ украинский",
                    Description = "Описание",
                    Image = "borshh.jpg",
                    Ingredients = new List<Ingredient>
                    {
                        new Ingredient
                            {
                                Id = 1,
                                Name = "Картошка",
                            },
                        new Ingredient
                            {
                                Id = 3,
                                Name = "Свекла",
                            }
                    }
                        
                },

                new Dish
                {
                    Id = 2,
                    Name = "Салат Оливье",
                    Description = "Описание",
                    Image = "olive-po-sovetski.jpg",
                    Ingredients = new List<Ingredient>
                    {
                        new Ingredient
                            {
                                Id = 1,
                                Name = "Картошка",
                            },
                        new Ingredient
                            {
                                Id = 4,
                                Name = "Майонез",
                            }
                    }
                    
                },

                new Dish
                {
                    Id = 3,
                    Name = "Утка с яблоками",
                    Description = "Описание",
                    Image = "utka-s-jablokami.jpg",
                    Ingredients = new List<Ingredient>
                    {
                        new Ingredient
                            {
                                Id = 2,
                                Name = "Лук",
                            }
                       
                    }
                },

                new Dish
                {
                    Id = 4,
                    Name = "Салат Мимоза",
                    Description = "Описание",
                    Image = "klassicheskij-salat-mimoza.jpg",
                    Ingredients = new List<Ingredient>
                    {
                         new Ingredient
                            {
                                Id = 2,
                                Name = "Лук",
                            },
                        new Ingredient
                            {
                                Id = 1,
                                Name = "Картошка",
                            },
                        new Ingredient
                            {
                                Id = 4,
                                Name = "Майонез",
                            }

                    }
                },

                new Dish
                {
                    Id = 5,
                    Name = "Котлеты мясные",
                    Description = "Описание",
                    Image = "kotleti-mjasnie.jpg",
                    Ingredients = new List<Ingredient>
                    {
                         new Ingredient
                            {
                                Id = 2,
                                Name = "Лук",
                            },
                        new Ingredient
                            {
                                Id = 4,
                                Name = "Майонез",
                            }

                    }
                }

            };
        }
        public IEnumerable<Dish> GetDishes(int ingredientId)
        {
           return _dishes.Where(dish => dish.Ingredients.Any(x => x.Id == ingredientId));
        }

        public IEnumerable<Dish> GetDishes()
        {
            return _dishes;
        }

        public Dish GetDish(int id)
        {
            return _dishes.FirstOrDefault(dish => dish.Id == id);
        }

        public IEnumerable<Dish> GetDishes(IEnumerable<int> ingredients)
        {
            //return _dishes.Where(dish => dish.Ingredients.Any(x => ingredients.Any(ing=> dish.Id==ing)));

            //return _dishes.Where(dish => dish.Ingredients.Any(x => ingredients.Any(y => x.Id==y)));

            //!!!
          // return _dishes.Where(dish => ingredients.All(y => dish.Ingredients.All(x => x.Id== y)));
            return _dishes.Where(dish => dish.Ingredients.All(y => ingredients.Contains(y.Id)));

            //return _dishes.Where(dish => ingredients.All(x => dish.Ingredients()));
            //return _dishes.Where(dish => ingredients.Any(y => dish.Ingredients.All(x => x.Id == y)));
        }

        //public bool Contains(Dish dish, IEnumerable<int> ingredients)
        //{
        //    foreach (int id in ingredients)
        //    {
        //        foreach (Ingredient ingr in dish.Ingredients)
        //        {
        //            //ingr.Id == id;
        //        }
        //    }
            
        //    return _dishes.Where(dish=> )
        //}
    }
}