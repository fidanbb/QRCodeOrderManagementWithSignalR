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
	public class EfNotificationDal : GenericRepository<Notification>, INotificationDal
	{
		public EfNotificationDal(SignalRContext context) : base(context)
		{
		}

		public async Task<List<Notification>> GetNotificationsByStatusFalseAsync()
		{
			using var context = new SignalRContext();

			return await context.Notifications.Where(x => x.Status == false).ToListAsync();
		}

		public async Task<int> NotificationCountByStatusFalseAsync()
		{
			using var context =new SignalRContext();

			return await context.Notifications.Where(x => x.Status == false).CountAsync();
		}

        public async Task NotificationStatusChangeToFalseAsync(int id)
        {
           using var context=new SignalRContext();

			var value = await context.Notifications.FindAsync(id);

			value.Status= false;

			await context.SaveChangesAsync();
        }

        public async Task NotificationStatusChangeToTrueAsync(int id)
        {
            using var context = new SignalRContext();

            var value = await context.Notifications.FindAsync(id);

            value.Status = true;

            await context.SaveChangesAsync();
        }
    }
}
