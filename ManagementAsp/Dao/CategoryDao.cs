using ManagementAsp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ManagementAsp.Dao
{
    public class CategoryDao
    {
        ManagementDBContext myDb = new ManagementDBContext();
        public List<Category> getAll()
        {
            return myDb.categories.OrderByDescending(x => x.idCat).ToList();
        }

        public void add(Category category)
        {
            myDb.categories.Add(category);
            myDb.SaveChanges();
        }

        public Category checkName(string name)
        {
            return myDb.categories.Where(x => x.name.Contains(name)).FirstOrDefault();
        }

        public void delete(int id)
        {
            var category = myDb.categories.FirstOrDefault(x => x.idCat == id);
            myDb.categories.Remove(category);
            myDb.SaveChanges();
        }

        public void update(Category category)
        {
            var obj = myDb.categories.FirstOrDefault(x => x.idCat == category.idCat);
            obj.name = category.name;
            myDb.SaveChanges();
        }

        public Category getCategoryById(int id)
        {
            return myDb.categories.Where(x => x.idCat == id).FirstOrDefault();
        }
    }
}