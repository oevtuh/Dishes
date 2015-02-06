using System;
using System.Collections.Generic;
using System.Web.Mvc;
using DataLayer.Repositories.Dishes;

using Dish = Models.Dish;
using Newtonsoft.Json;

namespace Dishes.Controllers
{
    public class DishesController : Controller
    {
        private readonly IDishesRepository _dishesRepository;

        public DishesController(IDishesRepository dishesRepository)
        {
            _dishesRepository = dishesRepository;
        }

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Choose()
        {
            
            return View();
        }
		
        public ActionResult Create()
        {
            return View();
        }
		
        public ActionResult Find()
        {
            return View();
        }

        public ActionResult Dish(int id)
        {
            var model = _dishesRepository.GetDish(id);
            return View(model);
        }
		
        public ActionResult Alldishes()
        {
            var model = _dishesRepository.GetCategories();
            return View(model);
        }
      
        public ActionResult FindByIngredient(int id)
        {
            var model = _dishesRepository.GetDishes(id);
            return View(model);
        }
		
       public ActionResult FindByIngredients(List<int> dishes)
        {
           var model = _dishesRepository.GetDishes(dishes);
           return Json(model, JsonRequestBehavior.AllowGet);
        }
		
        public ViewResult DishesInCategory(int categoryId=0 )
        {
            IEnumerable<Dish> model = _dishesRepository.GetDishesByCategory(categoryId);
            return View(model);
        }


        
    }
}