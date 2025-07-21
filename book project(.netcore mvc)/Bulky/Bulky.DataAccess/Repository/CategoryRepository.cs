using Bulky_DataAcccess.Data;
using Bulky_DataAccess.Repository.IRepository;
using Bulky_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Bulky_DataAccess.Repository
{
    public class CategoryRepository : Repository<Category>,ICategoryRepository
    {
        // here this class extends the repository class and implements the ICategoryRepository interface
        //repository class extends IRepository interface where all the methods are defined alreay only the remaining methods are implemented here

        //The methods like Add(), Update(), Remove() (or Delete()), and SaveChanges() are predefined methods provided by Entity Framework Core (EF Core) through the DbSet<T> and DbContext classes.


        private ApplicationDbContext _db;
        public CategoryRepository(ApplicationDbContext db) :base(db)
        {
            _db = db;
        }

        // and this class instance is made in UnitOfWork class
        // this was added in unitofwork class
        //public void Save()
        //{
        //    _db.SaveChanges();
        //}

        public void Update(Category obj)
        {
            _db.Categories.Update(obj);
        }
    }
}
