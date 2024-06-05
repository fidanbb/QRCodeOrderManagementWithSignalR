using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DataAccessLayer.Abstract
{
	public interface IOrderDal:IGenericDal<Order>
	{
		Task<int> TotalOrderCountAsync();
		Task<int> ActiveOrderCountAsync();
		Task<decimal> LastOrderPriceAsync();
		
	}
}
