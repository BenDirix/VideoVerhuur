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

                }

            }
            base.OnActionExecuting(filterContext);
        }
    }
}