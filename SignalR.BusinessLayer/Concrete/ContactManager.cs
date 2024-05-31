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
    public class ContactManager : IContactService
    {
        private readonly IContactDal _contactDal;

        public ContactManager(IContactDal contactDal)
        {
            _contactDal = contactDal;
        }

        public async Task TAdd(Contact entity)
        {
            await _contactDal.Add(entity);
        }

        public async Task TDelete(Contact entity)
        {
            await _contactDal.Delete(entity);
        }

        public async Task<List<Contact>> TGetAll()
        {
            return await _contactDal.GetAll();
        }

        public async Task<Contact> TGetByID(int id)
        {
           return await _contactDal.GetByID(id);    
        }

        public async Task TUpdate(Contact entity)
        {
            await _contactDal.Update(entity);
        }
    }
}
