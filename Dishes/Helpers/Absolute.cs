using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dishes.Helpers
{
    public static class Absolute
    {
        public static string AbsoluteAction(this UrlHelper helper,
             string actionName, string controllerName, object routeValues = null)
        {
            string scheme = helper.RequestContext.HttpContext.Request.Url.Scheme;



            var url = helper.Action(actionName, controllerName, new { id = "temp" });

            url=url.Replace("temp", "");

            return ( url + "{id}");

        }
    }


}