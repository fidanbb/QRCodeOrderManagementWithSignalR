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
	public class MoneyCaseManager : IMoneyCaseService
	{
		private readonly IMoneyCaseDal _moneyCaseDal;

		public MoneyCaseManager(IMoneyCaseDal moneyCaseDal)
		{
			_moneyCaseDal = moneyCaseDal;
		}

		public Task TAdd(MoneyCase entity)
		{
			throw new NotImplementedException();
		}

		public Task TDelete(MoneyCase entity)
		{
			throw new NotImplementedException();
		}

		public Task<List<MoneyCase>> TGetAll()
		{
			throw new NotImplementedException();
		}

		public Task<MoneyCase> TGetByID(int id)
		{
			throw new NotImplementedException();
		}

		public async Task<decimal> TTotalMoneyCaseAmounAsync()
		{
			return await _moneyCaseDal.TotalMoneyCaseAmounAsync();
		}

		public Task TUpdate(MoneyCase entity)
		{
			throw new NotImplementedException();
		}
	}
}
