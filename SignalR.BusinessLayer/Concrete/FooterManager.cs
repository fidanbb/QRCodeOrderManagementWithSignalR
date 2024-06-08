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
    public class FooterManager : IFooterService
    {
        private readonly IFooterDal _footerDal;

        public FooterManager(IFooterDal footerDal)
        {
            _footerDal = footerDal;
        }

        public async Task TAdd(Footer entity)
        {
           await _footerDal.Add(entity);
        }

        public async Task TDelete(Footer entity)
        {
            await _footerDal.Delete(entity);
        }

        public async Task<List<Footer>> TGetAll()
        {
           return await _footerDal.GetAll();
        }

        public async Task<Footer> TGetByID(int id)
        {
            return await _footerDal.GetByID(id);
        }

        public async Task TUpdate(Footer entity)
        {
            await _footerDal.Update(entity);
        }
    }
}
