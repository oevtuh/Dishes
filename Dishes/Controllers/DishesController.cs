using System;
using System.Collections.Generic;
using System.Web.Mvc;
using DataLayer.Repositories.Dishes;
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
           var model = _dishesRepository.GetIngredients();
            return View(model);
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

        /*public JsonResult FindByIngredients()
        {
            IEnumerable<int> ingredients = new List<int> {1,2,4};

            var model = _dishesRepository.GetDishes(ingredients);
            return Json(model, JsonRequestBehavior.AllowGet);
        }*/

        //[AcceptVerbs(HttpVerbs.Post)]
        //[HttpPost]
        public ActionResult FindByIngredients(List<int> dishes)
        {
            //var deserializedObject = JsonConvert.DeserializeObject<List<int>>(json);

           // string myobj = JsonConvert.SerializeObject(json);
           // ICollection<int> ingredients2 = new List<int>();

            //List<int> idList= new List<int>();
            //foreach (var i in Name)
            //{
            //    idList.Add(Convert.ToInt32(i)-48);
            //}
            

            //IList<int> ingredients = new List<int> { 1,2,3 };
            //if (Name.Length < 5)
            //{
            //    ingredients = new List<int> {1, 2};
            //}
            //else
            //{
            //    ingredients = new List<int> {1, 2, 3, 4};
            //}
            // ingredients.Add(2);


            var model = _dishesRepository.GetDishes(dishes);

            return Json(model, JsonRequestBehavior.AllowGet);
        }


        
    }
}