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
    public class SocialMediaManager : ISocialMediaService
    {
        private readonly ISocialMediaDal _socialMediaDal;

        public SocialMediaManager(ISocialMediaDal socialMediaDal)
        {
            _socialMediaDal = socialMediaDal;
        }

        public async Task TAdd(SocialMedia entity)
        {
            await _socialMediaDal.Add(entity);
        }

        public async Task TDelete(SocialMedia entity)
        {
           await _socialMediaDal.Delete(entity);
        }

        public async Task<List<SocialMedia>> TGetAll()
        {
            return await _socialMediaDal.GetAll();
        }

        public async Task<SocialMedia> TGetByID(int id)
        {
            return await _socialMediaDal.GetByID(id);
        }

        public async Task TUpdate(SocialMedia entity)
        {
            await _socialMediaDal.Update(entity);
        }
    }
}
