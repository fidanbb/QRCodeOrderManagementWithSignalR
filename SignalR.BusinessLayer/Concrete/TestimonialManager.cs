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
    public class TestimonialManager : ITestimonialService
    {
        private readonly ITestimonialDal _testimonialDal;

        public TestimonialManager(ITestimonialDal testimonialDal)
        {
            _testimonialDal = testimonialDal;
        }

        public async Task TAdd(Testimonial entity)
        {
           await _testimonialDal.Add(entity);
        }

        public async Task TDelete(Testimonial entity)
        {
          await _testimonialDal.Delete(entity);
        }

        public async Task<List<Testimonial>> TGetAll()
        {
            return await _testimonialDal.GetAll();
        }

        public async Task<Testimonial> TGetByID(int id)
        {
          return  await _testimonialDal.GetByID(id);
        }

        public async Task TUpdate(Testimonial entity)
        {
           await _testimonialDal.Update(entity);
        }
    }
}
