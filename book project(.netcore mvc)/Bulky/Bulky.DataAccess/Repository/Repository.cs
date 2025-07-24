using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Bulky_DataAcccess.Data;
using Bulky_DataAccess.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Bulky_DataAccess.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        //The methods like Add(), Update(), Remove() (or Delete()), and SaveChanges() are predefined methods provided by Entity Framework Core (EF Core) through the DbSet<T> and DbContext classes.


        private readonly ApplicationDbContext _db;
        internal DbSet<T> dbSet;
        // DbSet<T> is a collection of entities of type T that can be queried from the database.
        public Repository(ApplicationDbContext db)
        {
            _db = db;
            this.dbSet = _db.Set<T>();
            // _db.Categories == dbset
            // _db.Products == dbset
            // if we want to incclude the category list and show category related to product on index page of product 
            //_db.Products.Include(u => u.Category).Include(u => u.CategoryId);
        }

        public void Add(T entity)
        {
            //db.Categories.Add(obj);
            dbSet.Add(entity);
        }

        public T Get(Expression<Func<T, bool>> filter, string? includeProperty = null)
        {
            // Category? obj3 = _db.Categories.Where(u => u.Id == id).FirstOrDefault();// this is a more complex way to find the category by id
            //Why use Expression<Func<T, bool>>?
            //This allows you to pass in a filter at runtime.
            //It keeps your code flexible and reusable for any condition and any entity.
            IQueryable <T> query = dbSet;
            query = query.Where(filter);
            if (!string.IsNullOrEmpty(includeProperty))
            {
                // if there are more than one property to include properties
                foreach (var includeprop in includeProperty.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeprop);
                }
            }
            return query.FirstOrDefault();
        }

        // category , covertype
        public IEnumerable<T> GetAll(string? includeProperty=null)
        {
            // to get all the records from the category table
            IQueryable<T> query = dbSet;
            if (!string.IsNullOrEmpty(includeProperty))
            {
                // if there are more than one property to include properties
                foreach (var includeprop in includeProperty.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeprop);
                }
            }
            return query.ToList();
        }



        public void Remove(T Entity)
        {
            dbSet.Remove(Entity);
        }

        public void RemoveRange(IEnumerable<T> entity)
        {
            dbSet.RemoveRange(entity);
        }
    }
}
