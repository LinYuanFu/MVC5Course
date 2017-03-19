using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC5Course.Models;
using PagedList;
using System.Data.Entity.Validation;

namespace MVC5Course.Controllers
{
    public class ProductsController : BaseController
    {
        //    private FabricsEntities db = new FabricsEntities();

        // GET: Products
        public ActionResult Index(string sortBy,string keyword,int pageNo = 1)
        {
            //    return View(db.Product.OrderByDescending(p => p.ProductId).Take(10).ToList());
            //    var data = db.Product.AsQueryable();
            DoSearchIndex(sortBy, keyword, pageNo);

            return View();
        }

        private void DoSearchIndex(string sortBy, string keyword, int pageNo)
        {
            var data = repoBase.All().AsQueryable();

            if (!String.IsNullOrEmpty(keyword))
            {
                data = data.Where(p => p.ProductName.Contains(keyword));
            }

            if (sortBy == "+Price")
            {
                data = data.OrderBy(p => p.Price);
            }
            else
            {
                data = data.OrderByDescending(p => p.Price);
            }

            ViewBag.keyword = keyword;

            ViewData.Model = data.ToPagedList(pageNo, 10);
        }

        [HttpPost]
        public ActionResult Index(Product[] data, string sortBy, string keyword, int pageNo = 1)
        {
            if (ModelState.IsValid)
            {
                foreach (var item in data)
                {
                    var prod = repoBase.Find(item.ProductId);
                    prod.ProductName = item.ProductName;
                    prod.Price = item.Price;
                    prod.Stock = item.Stock;
                    prod.Active = item.Active;
                }
                repoBase.UnitOfWork.Commit();
                return RedirectToAction("Index");
            }

            DoSearchIndex(sortBy, keyword, pageNo);
            return View();
        }

        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
       //     Product product = db.Product.Find(id);
            Product product = repoBase.Find(id.Value);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductId,ProductName,Price,Active,Stock")] Product product)
        {
            if (ModelState.IsValid)
            {
                //    db.Product.Add(product);
                //    db.SaveChanges();
                repoBase.Add(product);
                repoBase.UnitOfWork.Commit();
                return RedirectToAction("Index");
            }

            return View(product);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
       //     Product product = db.Product.Find(id);
            Product product = repoBase.Find(id.Value);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        [HandleError(View = "Error_DbEntityValidationException", ExceptionType = typeof(DbEntityValidationException))]
        public ActionResult Edit(int id,FormCollection form)
        {
             var product = repoBase.Find(id);
            if (ModelState.IsValid)
            {
                if (TryUpdateModel(product,new string[] { "ProductName", "Stock" }))
                {
                    //var db = repoBase.UnitOfWork.Context;
                    //db.Entry(product).State = EntityState.Modified;
                    //    db.SaveChanges();
                }
            }
            repoBase.UnitOfWork.Commit();
            return RedirectToAction("Index");
        //    return View(product);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Product product = db.Product.Find(id);
            Product product = repoBase.Find(id.Value);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //Product product = db.Product.Find(id);
            //db.Product.Remove(product);
            //db.SaveChanges();
            Product product = repoBase.Find(id);
            repoBase.Delete(product);
            repoBase.UnitOfWork.Commit();
            return RedirectToAction("Index");
        }
        /*
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        */
    }
}
