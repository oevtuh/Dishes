using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;
using DataLayer.Repositories.Dishes;
using Dishes.Models;

namespace Dishes.Controllers
{
    public class DishesController : Controller
    {
        private IDishesRepository _dishesRepository;

        public DishesController()
        {
            _dishesRepository = new DishesRepository();
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
            var model = _dishesRepository.GetDishes();
            return View(model);
        }

        public ActionResult FindByIngredient(int id)
        {
            var model = _dishesRepository.GetDishes(id);
            return View(model);
        }

        [HttpPost]
        public JsonResult FindByIngredients()
        {
            IEnumerable<int> ingredients = new List<int> {1,3,4};

            var model = _dishesRepository.GetDishes(ingredients);
            return Json(model);
        }

        
    }
}