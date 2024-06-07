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
    public class SliderManager : ISliderService
    {
        private readonly ISliderDal _sliderDal;

        public SliderManager(ISliderDal sliderDal)
        {
            _sliderDal = sliderDal;
        }

        public async Task TAdd(Slider entity)
        {
           await _sliderDal.Add(entity);
        }

        public async Task TDelete(Slider entity)
        {
           await _sliderDal.Delete(entity);
        }

        public async Task<List<Slider>> TGetAll()
        {
           return await _sliderDal.GetAll();
        }

        public async Task<Slider> TGetByID(int id)
        {
            return await _sliderDal.GetByID(id);
        }

        public async Task TUpdate(Slider entity)
        {
            await _sliderDal.Update(entity);
        }
    }
}
