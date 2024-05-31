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
    public class BookingManager : IBookingService
    {

        private readonly IBookigDal _bookingDal;

        public BookingManager(IBookigDal bookingDal)
        {
            _bookingDal = bookingDal;
        }

        public async Task TAdd(Booking entity)
        {
            await _bookingDal.Add(entity);
        }

        public async Task TDelete(Booking entity)
        {
            await _bookingDal.Delete(entity);
        }

        public Task<List<Booking>> TGetAll()
        {
            return _bookingDal.GetAll();
        }

        public async Task<Booking> TGetByID(int id)
        {
            return await _bookingDal.GetByID(id);
        }

        public async Task TUpdate(Booking entity)
        {
           await _bookingDal.Update(entity);
        }
    }
}
