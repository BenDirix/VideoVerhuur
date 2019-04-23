using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VideoVerhuur.Controllers;

namespace VideoVerhuur
{
    public class UserLoggedInFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            HttpContext ctx = HttpContext.Current;
            if(ctx.Session != null)
            {
                if(ctx.Session["klant"] == null)
                {
                    ctx.Response.Redirect("~/Home/Index");

                    //filterContext.Result = new RedirectToRouteResult(
                    //  new System.Web.Routing.RouteValueDictionary { { "controller", "Home" }, { "action", "Index" } });

                    //var controller = (HomeController)filterContext.Controller;

                    //filterContext.Result = controller.RedirectToAction("Index", "Home");
                }

            }
            base.OnActionExecuting(filterContext);
        }
    }
}