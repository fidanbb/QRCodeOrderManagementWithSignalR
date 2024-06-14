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
	public class MessageManager : IMessageService
	{
		private readonly IMessageDal _messageDal;

		public MessageManager(IMessageDal messageDal)
		{
			_messageDal = messageDal;
		}

		public async Task TAdd(Message entity)
		{
			await _messageDal.Add(entity);
		}

		public async Task TDelete(Message entity)
		{
			await _messageDal.Delete(entity);
		}

		public async Task<List<Message>> TGetAll()
		{
			return await _messageDal.GetAll();
		}

		public async Task<Message> TGetByID(int id)
		{
			return await (_messageDal.GetByID(id));
		}

		public async Task TUpdate(Message entity)
		{
			await _messageDal.Update(entity);
		}
	}
}
