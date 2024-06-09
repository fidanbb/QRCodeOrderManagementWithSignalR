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
    public class BasketManager : IBasketService
    {
        private readonly IBasketDal _basketDal;

        public BasketManager(IBasketDal basketDal)
        {
            _basketDal = basketDal;
        }

        public async Task TAdd(Basket entity)
        {
           await _basketDal.Add(entity);
        }

        public async Task TDelete(Basket entity)
        {
           await _basketDal.Delete(entity);
        }

        public async Task<List<Basket>> TGetAll()
        {
            return await _basketDal.GetAll();
        }

        public async Task<List<Basket>> TGetBasketByMenuTableNumberAsync(int id)
        {
            return await _basketDal.GetBasketByMenuTableNumberAsync(id);
        }

        public async Task<Basket> TGetByID(int id)
        {
            return await _basketDal.GetByID(id);
        }

        public async Task TUpdate(Basket entity)
        {
           await _basketDal.Update(entity);
        }
    }
}
