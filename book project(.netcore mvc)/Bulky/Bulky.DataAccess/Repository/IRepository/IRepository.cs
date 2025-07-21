using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Bulky_DataAccess.Repository.IRepository
{
    public interface IRepository<T> where T:class
    {
        // right now we have category class on which we want implement repository
        //T - Category
        // here we write all methods 
        IEnumerable<T> GetAll();
        T Get(Expression<Func<T, bool>> filter);

        void Add(T entity);
        //void Update(T entity); // why are we not keeping this because updating becomes too complex where we have to update only specific feilds 
        void Remove(T Entity);

        void RemoveRange(IEnumerable<T> entity );

    }
}
