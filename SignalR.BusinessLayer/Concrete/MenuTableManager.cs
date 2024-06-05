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
	public class MenuTableManager : IMenuTableService
	{
		private readonly IMenuTableDal _menuTableDal;

		public MenuTableManager(IMenuTableDal menuTableDal)
		{
			_menuTableDal = menuTableDal;
		}

		public Task TAdd(MenuTable entity)
		{
			throw new NotImplementedException();
		}

		public Task TDelete(MenuTable entity)
		{
			throw new NotImplementedException();
		}

		public Task<List<MenuTable>> TGetAll()
		{
			throw new NotImplementedException();
		}

		public Task<MenuTable> TGetByID(int id)
		{
			throw new NotImplementedException();
		}

		public async Task<int> TMenuTableCountAsync()
		{
		    return await _menuTableDal.MenuTableCountAsync();
		}

		public Task TUpdate(MenuTable entity)
		{
			throw new NotImplementedException();
		}
	}
}
