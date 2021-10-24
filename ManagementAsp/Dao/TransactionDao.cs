using ManagementAsp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ManagementAsp.Dao
{
    public class TransactionDao
    {
        ManagementDBContext myDb = new ManagementDBContext();

        public List<Transaction> getAll()
        {
            return myDb.transactions.OrderByDescending(x => x.idTranSaction).ToList();
        }

        public void add(Transaction transaction)
        {
            myDb.transactions.Add(transaction);
            myDb.SaveChanges();
        }

        public void updateAmount(int idTran,int amount)
        {
            var obj = myDb.transactions.FirstOrDefault(x => x.idTranSaction == idTran);
            obj.amount = obj.amount + amount;
            myDb.SaveChanges();
        }

        public void delete(int idTran)
        {
            var arrObj = myDb.orders.Where(x => x.idTransaction == idTran).ToList();
            foreach(var item in arrObj)
            {
                myDb.orders.Remove(item);
               
            }
            var obj = myDb.transactions.FirstOrDefault(x => x.idTranSaction == idTran);
            myDb.transactions.Remove(obj);
            myDb.SaveChanges();
        }
    }
}