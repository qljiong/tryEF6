using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TryEF.DBctrl;
using TryEF.Models;

namespace TryEF.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            using (DBmain db = new DBmain())
            {
                var result = db.Database.SqlQuery<Product>("select * from product where Name=@name",
                     new SqlParameter[] { new SqlParameter("@name", "123") });
                var m = db.Products.ToList();
                return View(m);
            }
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Product pd)
        {
            using (DBmain db = new DBmain())
            {
                db.Products.Add(pd);
                db.SaveChanges();

                var m = db.Products.ToList();
                return View("Index", m);
            }

        }

        public ActionResult Delete(int id)
        {
            using (DBmain db = new DBmain())
            {
                var prd = db.Products.Find(id);
                db.Products.Remove(prd);
                db.SaveChanges();

                var m = db.Products.ToList();
                return View("Index", m);
            }
        }

        public ActionResult Edit(int id)
        {
            using (DBmain db = new DBmain())
            {
                var prd = db.Products.Find(id);
                return View(prd);
            }
        }

        public ActionResult SaveEdit(Product pd)
        {

            using (DBmain db = new DBmain())
            {
                db.Entry(pd).State = EntityState.Modified;
                db.SaveChanges();

                var m = db.Products.ToList();
                return View("Index", m);

            }
        }
    }
}