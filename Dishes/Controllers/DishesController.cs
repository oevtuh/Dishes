using System.Collections.Generic;
using System.Web.Mvc;
using DataLayer.Repositories.Dishes;

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
            var model = _dishesRepository.GetDishes();
            return View(model);
        }

        public ActionResult FindByIngredient(int id)
        {
            var model = _dishesRepository.GetDishes(id);
            return View(model);
        }

        public JsonResult FindByIngredients()
        {
            IEnumerable<int> ingredients = new List<int> {1,2};

            var model = _dishesRepository.GetDishes(ingredients);
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        
    }
}