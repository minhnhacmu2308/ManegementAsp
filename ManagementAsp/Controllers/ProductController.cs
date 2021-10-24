using ManagementAsp.Dao;
using ManagementAsp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ManagementAsp.Controllers
{
    public class ProductController : Controller
    {
        ProductDao productDao = new ProductDao();
        CategoryDao categoryDao = new CategoryDao();
        // GET: Product
        public ActionResult Index(string msg)
        {
            var list = productDao.getAll();
            ViewBag.MSG = msg;
            ViewBag.listC = categoryDao.getAll();
            return View(list);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Add(FormCollection form)
        {
            var file = Request.Files["file"];
            //Lấy thông tin từ input type=file có tên Avatar
            string postedFileName = System.IO.Path.GetFileName(file.FileName);
            //Lưu hình đại diện về Server
            string reNameFile = DateTime.Now.Ticks.ToString() + postedFileName;
            var path = Server.MapPath("/Content/images/" + reNameFile);
            file.SaveAs(path);
            Product pro = new Product();
            pro.name = form["nameProduct"];
            pro.number = Int32.Parse(form["number"]);
            pro.cost = Int32.Parse(form["cost"]);
            pro.status = 1;
            pro.idCat = Int32.Parse(form["danhmuc"]);
            pro.description = form["noidung"];
            pro.image = reNameFile;
            var obj = productDao.checkExistName(form["nameProduct"]);
            if (obj == null)
            {
                productDao.add(pro);
                return RedirectToAction("Index", new { msg = "1" });
            }
            else
            {
                return RedirectToAction("Index", new { msg = "2" });
            }         
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Update(FormCollection form)
        {
            Product pro = new Product();
            var file = Request.Files["file"];
            //Lấy thông tin từ input type=file có tên Avatar
            string postedFileName = System.IO.Path.GetFileName(file.FileName);

            if(string.IsNullOrEmpty(file.FileName))
            {
                pro.idProduct = Int32.Parse(form["idProduct"]);
                pro.name = form["nameProduct"];
                pro.number = Int32.Parse(form["number"]);
                pro.cost = Int32.Parse(form["cost"]);
                pro.status = 1;
                pro.idCat = Int32.Parse(form["danhmuc"]);
                pro.description = form["noidung"];
                pro.image = form["nameImage"];
                var obj = productDao.checkExistName(form["nameProduct"]);
                if (obj == null)
                {
                    productDao.update(pro);
                    return RedirectToAction("Index", new { msg = "1" });
                }
                else
                {
                    var check = productDao.getProductById(Int32.Parse(form["idProduct"]));
                    if (check.name.Equals(form["nameProduct"]))
                    {
                        productDao.update(pro);
                        return RedirectToAction("Index", new { msg = "1" });
                    }
                    else
                    {
                        return RedirectToAction("Index", new { msg = "2" });
                    }                  
                }             
            }
            else
            {
                //Lưu hình đại diện về Server
                string reNameFile = DateTime.Now.Ticks.ToString() + postedFileName;
                var path = Server.MapPath("/Content/images/" + reNameFile);
                file.SaveAs(path);
                pro.idProduct = Int32.Parse(form["idProduct"]);
                pro.name = form["nameProduct"];
                pro.number = Int32.Parse(form["number"]);
                pro.cost = Int32.Parse(form["cost"]);
                pro.status = 1;
                pro.idCat = Int32.Parse(form["danhmuc"]);
                pro.description = form["noidung"];
                pro.image = reNameFile;
                var obj = productDao.checkExistName(form["nameProduct"]);
                if (obj == null)
                {
                    productDao.update(pro);
                    return RedirectToAction("Index", new { msg = "1" });
                }
                else
                {
                    var check = productDao.getProductById(Int32.Parse(form["idProduct"]));
                    if (check.name.Equals(form["nameProduct"]))
                    {
                        productDao.update(pro);
                        return RedirectToAction("Index", new { msg = "1" });
                    }
                    else
                    {
                        return RedirectToAction("Index", new { msg = "2" });
                    }
                }
            }        
        }

        [HttpPost]
        public ActionResult Delete(FormCollection form)
        {
            var id = Int32.Parse(form["id"]);
            productDao.delete(id);
            return RedirectToAction("Index", new { msg = "1" });
        }
    }
}