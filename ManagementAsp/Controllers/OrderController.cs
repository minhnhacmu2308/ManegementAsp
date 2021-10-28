using ManagementAsp.Dao;
using ManagementAsp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ManagementAsp.Controllers
{
    public class OrderController : Controller
    {
        // GET: Order
        OrderDao orderDao = new OrderDao();
        ProductDao productDao = new ProductDao();
        TransactionDao transactionDao = new TransactionDao();
        public ActionResult Index(string msg)
        {
            var list = orderDao.getAll();
            ViewBag.listPro = productDao.getAll();
            ViewBag.MSG = msg;
            ViewBag.listTransaction = transactionDao.getAll();
            return View(list);
        }

        [HttpGet]
        public ActionResult Add()
        {
            Transaction tran = new Transaction();
            tran.amount = 0;
            tran.createdAt = DateTime.Now;
            transactionDao.add(tran);
            return RedirectToAction("Index", new { msg = "1" });
        }

        [HttpPost]
        public ActionResult AddDetail(FormCollection form)
        {
            Order order = new Order();
            Product pro = new Product();
            var idTran = Int32.Parse(form["idTran"]);          
            var number = Int32.Parse(form["number"]);
            var idProduct = Int32.Parse(form["product"]);
            var obj = productDao.getProductById(idProduct);
            transactionDao.updateAmount(idTran, obj.cost * number);
            order.idProduct = idProduct;
            order.number = number;
            order.idTransaction = idTran;
            order.status = 1;
            orderDao.add(order);
            var product = productDao.getProductById(idProduct);
            pro.idProduct = idProduct;
            pro.number = (product.number - number);
            productDao.updateNumber(pro);
            return RedirectToAction("Index", new { msg = "1" });
        }

        [HttpPost]
        public ActionResult Delete(FormCollection form)
        {
            var idTran = Int32.Parse(form["idTran"]);
            transactionDao.delete(idTran);
            return RedirectToAction("Index", new { msg = "1" });
        }

        [HttpGet]
        public ActionResult DetailOrder(int id)
        {
            ViewBag.MaHd = transactionDao.getTransaction(id);
            ViewBag.listOrder = orderDao.getListOrder(id);
            return View();
        }
    }
}