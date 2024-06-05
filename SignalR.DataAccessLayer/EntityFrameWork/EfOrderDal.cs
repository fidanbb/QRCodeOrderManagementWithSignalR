using Microsoft.EntityFrameworkCore;
using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DataAccessLayer.Repositories;
using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DataAccessLayer.EntityFrameWork
{
	public class EfOrderDal : GenericRepository<Order>, IOrderDal
	{
		public EfOrderDal(SignalRContext context) : base(context)
		{
		}

		public async Task<int> ActiveOrderCountAsync()
		{
			using var context = new SignalRContext();

			return await context.Orders.Where(x => x.Status == true).CountAsync();
		}

		public async Task<decimal> LastOrderPriceAsync()
		{
			using var context = new SignalRContext();

			return await context.Orders.OrderByDescending(x => x.OrderDate)
				                       .Take(1)
									   .Select(y => y.TotalPrice)
									   .FirstOrDefaultAsync();
		}

		public async Task<int> TotalOrderCountAsync()
		{
			using var context = new SignalRContext();

			return await context.Orders.CountAsync();
		}
	}
}
