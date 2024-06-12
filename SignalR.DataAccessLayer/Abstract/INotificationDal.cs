using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DataAccessLayer.Abstract
{
	public interface INotificationDal:IGenericDal<Notification>
	{
		Task<int> NotificationCountByStatusFalseAsync();
		Task<List<Notification>> GetNotificationsByStatusFalseAsync();

		Task NotificationStatusChangeToTrueAsync(int id);
		Task NotificationStatusChangeToFalseAsync(int id);
	}
}
