using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.FooterDto;
using SignalR.EntityLayer.Entities;

namespace SignalRAPi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FootersController : ControllerBase
    {
        private readonly IFooterService _footerService;

        public FootersController(IFooterService footerService)
        {
            _footerService = footerService;
        }

        [HttpGet]

        public async Task<IActionResult> FooterList()
        {
            var values = await _footerService.TGetAll();

            return Ok(values);
        }

        [HttpPost]

        public async Task<IActionResult> CreateFooter(CreateFooterDto request)
        {
            Footer Footer = new Footer()
            {
                Title = request.Title,
                Description = request.Description,
                OpeningDays = request.OpeningDays,
                OpeningTimes = request.OpeningTimes,
            };

            await _footerService.TAdd(Footer);
            return Ok("Footer Added Succesfully ");
        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> DeleteFooter(int id)
        {
            var value = await _footerService.TGetByID(id);

            await _footerService.TDelete(value);

            return Ok("Footer deleted Succesfully");
        }

        [HttpPut]

        public async Task<IActionResult> UpdateFooter(UpdateFooterDto request)
        {
            Footer Footer = new Footer()
            {
                FooterID=request.FooterID,
                Title = request.Title,
                Description = request.Description,
                OpeningDays = request.OpeningDays,
                OpeningTimes = request.OpeningTimes,
            };

            await _footerService.TUpdate(Footer);

            return Ok("Footer Updated Succesfully ");
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetFooter(int id)
        {
            var value = await _footerService.TGetByID(id);

            return Ok(value);
        }
    }
}
