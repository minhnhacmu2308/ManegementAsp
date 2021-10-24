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

        public void add(Order order)
        {
            var obj = myDb.orders.FirstOrDefault(x => x.idTransaction == order.idTransaction && x.idProduct == order.idProduct);
            if(obj != null)
            {
                obj.number = obj.number + order.number;
                myDb.SaveChanges();
            }
            else
            {
                myDb.orders.Add(order);
                myDb.SaveChanges();
            }
           
        }

        public List<Order> getListOrder(int idTran)
        {
            return myDb.orders.Where(x => x.idTransaction == idTran).ToList();
        }

    }
}