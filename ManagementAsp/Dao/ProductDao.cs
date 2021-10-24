using ManagementAsp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ManagementAsp.Dao
{
    public class ProductDao
    {
        ManagementDBContext myDb = new ManagementDBContext();

        public List<Product> getAll()
        {
            return myDb.products.OrderByDescending(x => x.idProduct).ToList();
        }

        public void add(Product product)
        {
            myDb.products.Add(product);
            myDb.SaveChanges();
        }

        public void delete(int id)
        {
            var product = myDb.products.FirstOrDefault(x => x.idProduct == id);
            myDb.products.Remove(product);
            myDb.SaveChanges();
        }

        public void update(Product product)
        {
            var obj = myDb.products.FirstOrDefault(x => x.idProduct == product.idProduct);
            obj.name = product.name;
            obj.idCat = product.idCat;
            obj.number = product.number;
            obj.cost = product.cost;
            obj.image = product.image;
            obj.description = product.description;
            obj.status = product.status;
            myDb.SaveChanges();
        }

        public Product checkExistName(string name)
        {
            return myDb.products.Where(x => x.name.Contains(name)).FirstOrDefault();
        }

        public Product getProductById(int id)
        {
            return myDb.products.Where(x => x.idProduct == id).FirstOrDefault();
        }
    }
}