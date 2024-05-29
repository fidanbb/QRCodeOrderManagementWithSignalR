using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DataAccessLayer.Abstract
{
    public interface IGenericDal<T>where T : class
    {
        Task Add (T entity);
        Task Update (T entity);
        Task Delete (T entity);

        Task<List<T>> GetAll ();
        Task<T> GetByID (int id);
    }
}
