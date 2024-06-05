using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Abstract;
using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.BusinessLayer.Concrete
{
	public class OrderManager : IOrderService
	{
		private readonly IOrderDal _orderDal;

		public OrderManager(IOrderDal orderDal)
		{
			_orderDal = orderDal;
		}

		public async Task<int> TActiveOrderCountAsync()
		{
			return await _orderDal.ActiveOrderCountAsync();
		}

		public Task TAdd(Order entity)
		{
			throw new NotImplementedException();
		}

		public Task TDelete(Order entity)
		{
			throw new NotImplementedException();
		}

		public Task<List<Order>> TGetAll()
		{
			throw new NotImplementedException();
		}

		public Task<Order> TGetByID(int id)
		{
			throw new NotImplementedException();
		}

		public async Task<decimal> TLastOrderPriceAsync()
		{
			return await _orderDal.LastOrderPriceAsync();
		}

		public async Task<int> TTotalOrderCountAsync()
		{
			return await _orderDal.TotalOrderCountAsync();
		}

		public Task TUpdate(Order entity)
		{
			throw new NotImplementedException();
		}
	}
}
