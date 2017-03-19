using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Course.ActionFilters
{
    public class Action執行時間Attribute:ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            filterContext.Controller.ViewBag.StartTime = DateTime.Now;

            base.OnActionExecuting(filterContext);
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            filterContext.Controller.ViewBag.EndTime = DateTime.Now;

            filterContext.Controller.ViewBag.Duration = filterContext.Controller.ViewBag.EndTime - filterContext.Controller.ViewBag.StartTime;

            base.OnActionExecuted(filterContext);
        }
    }
}