using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Course.Controllers
{
    public class ARController : Controller
    {
        // GET: AR
        public ActionResult Index()
        {
            return View("123");
        }

        public ActionResult View1()
        {
            return PartialView("View2");
        }

        public ActionResult View2()
        {
            return File(Server.MapPath("~/Content/bbc_news_logo.png"), "image/png");
        }

        public ActionResult View3()
        {
            return File(Server.MapPath("~/Content/bbc_news_logo.png"), "image/png","圖片下載.png");
        }
    }
}