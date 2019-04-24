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
            if(HttpContext.Current.Session != null)
            {
                if(HttpContext.Current.Session["klant"] == null)
                {
                    HttpContext.Current.Response.Redirect("~/Home/Index");
                }
            }
            base.OnActionExecuting(filterContext);
        }
    }
}