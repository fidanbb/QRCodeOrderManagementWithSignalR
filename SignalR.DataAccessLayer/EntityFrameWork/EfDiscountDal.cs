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
    public class EfDiscountDal : GenericRepository<Discount>, IDiscountDal
    {
        public EfDiscountDal(SignalRContext context) : base(context)
        {
        }

		public async Task ChangeStatusToFalse(int id)
		{
			using var context = new SignalRContext();
			var value =await context.Discounts.FindAsync(id);
			value.Status = false;
		  await	context.SaveChangesAsync();
		}

		public async Task ChangeStatusToTrue(int id)
		{
			using var context = new SignalRContext();
			var value = await context.Discounts.FindAsync(id);
			value.Status = true;
			await context.SaveChangesAsync();
		}

		public async Task<List<Discount>> GetListByStatusTrue()
		{
			using var context = new SignalRContext();
			var value =await context.Discounts.Where(x => x.Status == true).ToListAsync();
			return value;
		}
	}
}
