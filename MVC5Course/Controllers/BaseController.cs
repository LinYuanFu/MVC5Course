using MVC5Course.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Course.Controllers
{
    [Authorize]
    public abstract class BaseController : Controller
    {
        public ProductRepository repoBase = RepositoryHelper.GetProductRepository();

        protected override void HandleUnknownAction(string actionName)
        {
            //將錯誤的Action導入首頁
            this.Redirect("/").ExecuteResult(this.ControllerContext);
//            base.HandleUnknownAction(actionName);
        }
    }
}