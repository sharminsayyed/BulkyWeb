using Bulky_DataAcccess.Data;
using Bulky_DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bulky_DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        // The Unit of Work (UoW) pattern is used to manage transactions and ensure that a group of operations are treated as a single unit — meaning either all succeed or none do
        //Unit of Work = One transaction for multiple changes to ensure data consistency.

        // UnitOfWork class contains ICategoryRepository property, which is an instance of CategoryRepository.
        // so instead of creating a new instance of CategoryRepository in every controller, we can use the UnitOfWork class to manage the repository instance.
        //in CategoryController we can inject IUnitOfWork instead of ICategoryRepository, and then use the Category property to access the methods of CategoryRepository.
        //You use UnitOfWork for multiple repositories (category , product,user)
        private ApplicationDbContext _db;

        public ICategoryRepository Category { get; private set; }
        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Category = new CategoryRepository(_db);
        }
        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
