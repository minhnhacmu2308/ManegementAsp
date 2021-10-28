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

        public List<Statis> getStatis()
        {
            string sql = "select idProduct,sum(number) as 'totalNumber' from Orders Group by idProduct Order by sum(number) Desc";
            return myDb.Database.SqlQuery<Statis>(sql).ToList();
        }
        public List<Statis> getStatisMonth(int month)
        {
            string sql = "select a.idProduct,sum(a.number) as 'totalNumber' from Orders as a, Transactions as b Where a.idTransaction = b.idTranSaction and Month(b.createdAt) = '" + month + "' Group by idProduct Order by sum(number) Desc";
            return myDb.Database.SqlQuery<Statis>(sql).ToList();
        }
    }
}