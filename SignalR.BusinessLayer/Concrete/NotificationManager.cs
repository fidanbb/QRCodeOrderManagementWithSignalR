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
	public class NotificationManager : INotificationService
	{
		private readonly INotificationDal _notificationDal;

		public NotificationManager(INotificationDal notificationDal)
		{
			_notificationDal = notificationDal;
		}

		public async Task<int> TNotificationCountByStatusFalseAsync()
		{
		  return await _notificationDal.NotificationCountByStatusFalseAsync();
		}

		public async Task TAdd(Notification entity)
		{
		   await	_notificationDal.Add(entity);
		}

		public async Task TDelete(Notification entity)
		{
			await _notificationDal.Delete(entity);
		}

		public async Task<List<Notification>> TGetAll()
		{
		return	await _notificationDal.GetAll();
		}

		public async Task<Notification> TGetByID(int id)
		{
			return await _notificationDal.GetByID(id);
		}

		public async Task TUpdate(Notification entity)
		{
			await _notificationDal.Update(entity);
		}

		public async Task<List<Notification>> TGetNotificationsByStatusFalseAsync()
		{
			return await _notificationDal.GetNotificationsByStatusFalseAsync();
		}

        public async Task TNotificationStatusChangeToTrueAsync(int id)
        {
			await _notificationDal.NotificationStatusChangeToTrueAsync(id);
        }

        public async Task TNotificationStatusChangeToFalseAsync(int id)
        {
            await _notificationDal.NotificationStatusChangeToFalseAsync(id);
        }
    }
}
