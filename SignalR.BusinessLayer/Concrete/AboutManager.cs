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
    public class AboutManager : IAboutService
    {

        private readonly IAboutDal _aboutDal;

        public AboutManager(IAboutDal aboutDal)
        {
            _aboutDal = aboutDal;
        }

        public async Task TAdd(About entity)
        {
            await _aboutDal.Add(entity);
        }

        public async Task TDelete(About entity)
        {
            await _aboutDal.Delete(entity);
        }

        public async Task<List<About>> TGetAll()
        {
           return await _aboutDal.GetAll();
        }

        public async Task<About> TGetByID(int id)
        {
           return await _aboutDal.GetByID(id);
        }

        public async Task TUpdate(About entity)
        {
           await _aboutDal.Update(entity);
        }
    }
}
