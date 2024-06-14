using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DataAccessLayer.Repositories;
using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DataAccessLayer.EntityFrameWork
{
    public class EfBookingDal : GenericRepository<Booking>, IBookigDal
    {
        public EfBookingDal(SignalRContext context) : base(context)
        {
        }

		public async Task BookingStatusApproved(int id)
		{
			using var context=new SignalRContext();

			var value = await context.Bookings.FindAsync(id);

			value.Description = "Reservation Approved";

			await context.SaveChangesAsync();

		}

		public async Task BookingStatusCanceled(int id)
		{
			using var context = new SignalRContext();

			var value = await context.Bookings.FindAsync(id);

			value.Description = "Reservation Canceled";

			await context.SaveChangesAsync();
		}
	}
}
