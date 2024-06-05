﻿using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Abstract;
using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.BusinessLayer.Concrete
{
	public class OrderDetailManager : IOrderDetailService
	{
		private readonly IOrderDetailDal _orderDetailDal;

		public OrderDetailManager(IOrderDetailDal orderDetailDal)
		{
			_orderDetailDal = orderDetailDal;
		}

		public Task TAdd(OrderDetail entity)
		{
			throw new NotImplementedException();
		}

		public Task TDelete(OrderDetail entity)
		{
			throw new NotImplementedException();
		}

		public Task<List<OrderDetail>> TGetAll()
		{
			throw new NotImplementedException();
		}

		public Task<OrderDetail> TGetByID(int id)
		{
			throw new NotImplementedException();
		}

		public Task TUpdate(OrderDetail entity)
		{
			throw new NotImplementedException();
		}
	}
}
