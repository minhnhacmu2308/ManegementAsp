using ManagementAsp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ManagementAsp.Dao
{
    public class OrderDao
    {
        ManagementDBContext myDb = new ManagementDBContext();

        public List<Order> getAll()
        {
            return myDb.orders.OrderByDescending(x => x.idOrder).ToList();
        }
    }
}