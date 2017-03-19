using MVC5Course.ActionFilters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Course.Controllers
{
    public class TestController : BaseController
    {
        // GET: Test
        [本機測試用]
        public ActionResult Index(string ex = "")
        {
            if (ex == "err")
            {
                throw new ArgumentOutOfRangeException("ex");
            }

            return View();
        }
    }
}