using ManagementAsp.Dao;
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
        public ActionResult Index()
        {
            var list = orderDao.getAll();
            return View(list);
        }
    }
}