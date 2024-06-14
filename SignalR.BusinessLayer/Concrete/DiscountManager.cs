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
    public class DiscountManager : IDiscountService
    {

        private readonly IDiscountDal _discountDal;

        public DiscountManager(IDiscountDal discountDal)
        {
            _discountDal = discountDal;
        }

        public async Task TAdd(Discount entity)
        {
           await _discountDal.Add(entity);
        }

		public async Task TChangeStatusToFalse(int id)
		{
            await _discountDal.ChangeStatusToFalse(id);
		}

		public async Task TChangeStatusToTrue(int id)
		{
            await _discountDal.ChangeStatusToTrue(id);
		}

		public async Task TDelete(Discount entity)
        {
           await _discountDal.Delete(entity);
        }

        public async Task<List<Discount>> TGetAll()
        {
            return await _discountDal.GetAll();
        }

        public async Task<Discount> TGetByID(int id)
        {
           return await _discountDal.GetByID(id);
        }

		public async Task<List<Discount>> TGetListByStatusTrue()
		{
			return await _discountDal.GetListByStatusTrue();
		}

		public async Task TUpdate(Discount entity)
        {
            await _discountDal.Update(entity);
        }
    }
}
