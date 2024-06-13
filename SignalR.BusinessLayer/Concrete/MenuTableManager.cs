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

		public async Task TAdd(MenuTable entity)
		{
			await _menuTableDal.Add(entity);
		}

		public async Task TDelete(MenuTable entity)
		{
			await _menuTableDal.Delete(entity);
		}

		public async Task<List<MenuTable>> TGetAll()
		{
			return await _menuTableDal.GetAll();
		}

		public async Task<MenuTable> TGetByID(int id)
		{
			return await _menuTableDal.GetByID(id);
		}

		public async Task<int> TMenuTableCountAsync()
		{
		    return await _menuTableDal.MenuTableCountAsync();
		}

		public async Task TUpdate(MenuTable entity)
		{
			await _menuTableDal.Update(entity);
		}
	}
}
