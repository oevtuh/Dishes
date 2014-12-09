using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Dishes
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

           routes.MapRoute(
              null,
              "",
              new { controller = "Dishes", action = "Index", id = UrlParameter.Optional }
           );


           

           routes.MapRoute(
               null,
               "dishes",
               new { controller = "Dishes", action = "Alldishes" }
           );

           routes.MapRoute(
               null,
               "dishes/choose",
               new { controller = "Dishes", action = "Choose" }
           );

           routes.MapRoute(
               null,
               "dishes/create",
               new { controller = "Dishes", action = "Create" }
           );

           routes.MapRoute(
               null,
               "dishes/find",
               new { controller = "Dishes", action = "Find" }
           );

           routes.MapRoute(
         null,
         "dishes/FindByIngredients",
         new { controller = "Dishes", action = "FindByIngredients" }
        );

           routes.MapRoute(
           null,
           "FindByIngredients",
           new { controller = "Dishes", action = "FindByIngredients" }
          );

           
         
            routes.MapRoute(
            null,
            "dishes/{id}",
            new { controller = "Dishes", action = "Dish" }
           );
            
           // //for the ulr.action
           // routes.MapRoute(
           // null,
           // "dishes/",
           // new { controller = "Dishes", action = "Dish" }
           //);


            routes.MapRoute(
            null,
            "FindByIngredient/{id}",
            new { controller = "Dishes", action = "FindByIngredient" }
           );

           //2 

           
            
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Dishes", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
