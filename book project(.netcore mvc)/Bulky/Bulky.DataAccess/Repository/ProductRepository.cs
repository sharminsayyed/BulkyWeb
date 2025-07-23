using Bulky_DataAcccess.Data;
using Bulky_DataAccess.Repository.IRepository;
using Bulky_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bulky_DataAccess.Repository
{
    public class ProductRepository:Repository<Product> , IProductRepository
    {
        // application db context is passed to the base class
        private ApplicationDbContext _db;
        public ProductRepository(ApplicationDbContext db):base(db)
        {
            _db = db;
        }

        public void Update(Product obj)
        {
            _db.Products.Update(obj);
        }

        // The methods like Add(), Update(), Remove() (or Delete()), and SaveChanges() are predefined methods provided by Entity Framework Core (EF Core) through the DbSet<T> and DbContext classes. that are defined in the Repository class 
    }
}
