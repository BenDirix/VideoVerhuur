using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VideoVerhuur
{
    public class UserLoggedInFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if(HttpContext.Current.Session != null)
            {
                if(HttpContext.Current.Session["klant"] == null)
                {
                    filterContext.Result = new RedirectToRouteResult(
                       new System.Web.Routing.RouteValueDictionary { { "Controller", "Home" }, { "Action", "Index" } });
                }

            }
            base.OnActionExecuting(filterContext);
        }
    }
}