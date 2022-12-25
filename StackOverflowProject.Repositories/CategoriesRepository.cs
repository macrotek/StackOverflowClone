using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StackOverflowProject.DomainModels;

namespace StackOverflowProject.Repositories
{
    public interface ICategoriesRepository
    {
        void InsertCategory(Category c);
        void UpdateCategory(Category c);
        void DeleteCategory(int cid);
        List<Category> GetCategories();
        List<Category> GetCategoryByCategoryID(int CategoryID);
    }
     public class CategoriesRepository : ICategoriesRepository
    {
        StackOverflowDatabaseDbContext db;

        public CategoriesRepository()
        {
            db = new StackOverflowDatabaseDbContext();
        }
        public void InsertCategory(Category c)
        {
            db.Categories.Add(c);
            db.SaveChanges();
        }
    }
}
