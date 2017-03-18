using MVC5Course.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MVC5Course.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.222";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Test()
        {
            return View();
        }

        public ActionResult Login(string ReturnUrl)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginVM login, string ReturnUrl)
        {
            FormsAuthentication.RedirectFromLoginPage(login.Username, false);

            if (ModelState.IsValid)
            {
                if (String.IsNullOrEmpty(ReturnUrl))
                {
                    return Redirect("Index");
                }
                if (ReturnUrl.StartsWith("/"))
                {
                    return Redirect(ReturnUrl);
                }
                else
                {
                    return Redirect("Index");
                }
                //return Content(login.Username + ":" + login.Password);
            }

            return View();
        }

        [HttpPost]
        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Index");
        }
    }
}