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
    public class EfCategoryDal : GenericRepository<Category>, ICategoryDal
    {
        public EfCategoryDal(SignalRContext context) : base(context)
        {
        }

		public async Task<int> ActiveCategoryCountAsync()
		{
			using var context = new SignalRContext();

			return await context.Categories.Where(m=>m.Status==true).CountAsync();
		}

		public async Task<int> CategoryCount()
		{
			using var context = new SignalRContext();

			return await context.Categories.CountAsync();
		}

		public async Task<int> PassiveCategoryCountAsync()
		{
			using var context = new SignalRContext();

			return await context.Categories.Where(m => m.Status == false).CountAsync();
		}
	}
}
