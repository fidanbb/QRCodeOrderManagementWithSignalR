using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.BusinessLayer.Abstract
{
    public interface IGenericService<T>where T : class
    {
        Task TAdd(T entity);
        Task TUpdate(T entity);
        Task TDelete(T entity);

        Task<List<T>> TGetAll();
        Task<T> TGetByID(int id);
    }
}
