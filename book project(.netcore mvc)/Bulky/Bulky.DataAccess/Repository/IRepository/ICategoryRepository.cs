using Bulky_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bulky_DataAccess.Repository.IRepository
{
    public interface ICategoryRepository:IRepository<Category>
    {
        // these consist of methods 
        void Update(Category obj); // edit the record
        //void Save(); // db_savechanges(); added int UnitOfWork class
    }
}
