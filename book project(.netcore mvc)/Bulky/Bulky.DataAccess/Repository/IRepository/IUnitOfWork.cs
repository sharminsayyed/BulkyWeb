using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bulky_DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        // The Unit of Work (UoW) pattern is used to manage transactions and ensure that a group of operations are treated as a single unit — meaning either all succeed or none do
        //Unit of Work = One transaction for multiple changes to ensure data consistency.

        ICategoryRepository Category { get; }

        void Save();
    }
}
