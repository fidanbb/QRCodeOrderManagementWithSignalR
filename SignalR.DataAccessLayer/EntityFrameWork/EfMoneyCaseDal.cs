﻿using Microsoft.EntityFrameworkCore;
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
	public class EfMoneyCaseDal:GenericRepository<MoneyCase>,IMoneyCaseDal
	{
        public EfMoneyCaseDal(SignalRContext context):base(context)
        {
            
        }

		public async Task<decimal> TotalMoneyCaseAmounAsync()
		{
			using var context = new SignalRContext();

			return await context.MoneyCases.Select(x=>x.TotalAmount).FirstOrDefaultAsync();
		}
	}
}
