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
    public class FeatureManager : IFeatureService
    {
        private readonly IFeatureDal _feautreDal;

        public FeatureManager(IFeatureDal feautreDal)
        {
            _feautreDal = feautreDal;
        }

        public async Task TAdd(Feature entity)
        {
            await _feautreDal.Add(entity);
        }

        public async Task TDelete(Feature entity)
        {
            await _feautreDal.Delete(entity);
        }

        public async Task<List<Feature>> TGetAll()
        {
           return await _feautreDal.GetAll();
        }

        public async Task<Feature> TGetByID(int id)
        {
            return await _feautreDal.GetByID(id);
        }

        public async Task TUpdate(Feature entity)
        {
            await _feautreDal.Update(entity);
        }
    }
}
