using ManagementAsp.Dao;
using ManagementAsp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ManagementAsp.Controllers
{
    public class CategoryController : Controller
    {
        CategoryDao categoryDao = new CategoryDao();
        // GET: Category
        public ActionResult Index(string msg)
        {
            ViewBag.MSG = msg;
            var list = categoryDao.getAll();
            return View(list);
        }

        [HttpPost]
        public ActionResult Add(FormCollection form)
        {
            Category category = new Category();
            category.name = form["name"];
            category.status = 1;
            var obj = categoryDao.checkName(form["name"]);
            if(obj == null)
            {
                categoryDao.add(category);
                return RedirectToAction("Index", new { msg = "1" });
            }
            else
            {       
                return RedirectToAction("Index", new { msg = "2" });
            }
           
        }

        [HttpPost]
        public ActionResult Delete(FormCollection form)
        {
            var id = form["id"];
            categoryDao.delete(Int32.Parse(id));
            return RedirectToAction("Index", new { msg = "1" });
        }

        [HttpPost]
        public ActionResult Update(FormCollection form)
        {
            Category category = new Category();
            category.name = form["name"];
            category.idCat = Int32.Parse(form["id"]);
            category.status = 1;
            var obj = categoryDao.checkName(form["name"]);
            if (obj == null)
            {
                categoryDao.update(category);
                return RedirectToAction("Index", new { msg = "1" });
            }
            else
            {
                var objC = categoryDao.getCategoryById(Int32.Parse(form["id"]));
                if (objC.name.Equals(form["name"]))
                {
                    categoryDao.update(category);
                    return RedirectToAction("Index", new { msg = "1" });
                }
                else
                {
                    return RedirectToAction("Index", new { msg = "2" });
                }
               
            }
        }
    }
}