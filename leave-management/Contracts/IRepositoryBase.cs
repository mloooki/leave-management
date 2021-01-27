using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace leave_management.Contracts
{
   public interface IRepositoryBase<T> where T : class
    {
        ICollection<T> FindAll(); //get all the data
        T FindById(int id); //get by id.
        bool Create(T entity);
        bool Update(T entity);
        bool Delete(T entity);
        bool Save();
    }
}
