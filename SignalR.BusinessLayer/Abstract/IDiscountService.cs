using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.BusinessLayer.Abstract
{
    public interface IDiscountService:IGenericService<Discount>
    {
		Task TChangeStatusToTrue(int id);
		Task TChangeStatusToFalse(int id);
		Task<List<Discount>> TGetListByStatusTrue();
	}
}
