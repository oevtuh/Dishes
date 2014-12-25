using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using DataLayer.Repositories.Ingredients;

namespace Dishes.Controllers
{
    public class IngredientsController : Controller
    {
           private readonly IIngredientsRepository _ingredientsRepository;

           public IngredientsController (IIngredientsRepository ingredientsRepository)
            {
                _ingredientsRepository = ingredientsRepository;
            }


           public ActionResult Choose()
           {
               
               var model = _ingredientsRepository.GetCategories();
               return View(model);
           }

        //public ActionResult GetIngredientsByCategory(int id)
        //{
        //    var model = _ingredientsRepository.GetCategoryByCategoryId(id);
        //    return View(model);
        //}
	}
}