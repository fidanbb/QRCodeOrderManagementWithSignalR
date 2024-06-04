using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.BookingDto;
using SignalR.EntityLayer.Entities;

namespace SignalRAPi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;

        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpGet]

        public async Task<IActionResult> BookingList()
        {
            var values = await _bookingService.TGetAll();

            return Ok(values);
        }

        [HttpPost]

        public async Task<IActionResult> CreateBooking(CreateBookingDto request)
        {
            Booking booking = new Booking()
            {
                Mail = request.Mail,
                Date = request.Date,
                Name = request.Name,
                PersonCount = request.PersonCount,
                Phone = request.Phone,
            };

            await _bookingService.TAdd(booking);
            return Ok("Booking Added Succesfully ");
        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> DeleteBooking(int id)
        {
            var value = await _bookingService.TGetByID(id);

            await _bookingService.TDelete(value);

            return Ok("Booking deleted Succesfully");
        }

        [HttpPut]

        public async Task<IActionResult> UpdateBooking(UpdateBookingDto request)
        {
            Booking booking = new Booking()
            {
                BookingID = request.BookingID,
                Mail = request.Mail,
                Date = request.Date,
                Name = request.Name,
                PersonCount = request.PersonCount,
                Phone = request.Phone,
            };

            await _bookingService.TUpdate(booking);

            return Ok("Booking Updated Succesfully ");
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetBooking(int id)
        {
            var value = await _bookingService.TGetByID(id);

            return Ok(value);
        }
    }
}
