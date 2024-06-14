using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DataAccessLayer.Abstract
{
    public interface IDiscountDal:IGenericDal<Discount>
	{
		Task ChangeStatusToTrue(int id);
		Task ChangeStatusToFalse(int id);
		Task<List<Discount>> GetListByStatusTrue();
	}
}
