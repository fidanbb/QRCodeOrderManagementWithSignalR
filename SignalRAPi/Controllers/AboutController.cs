using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.AboutDto;
using SignalR.EntityLayer.Entities;

namespace SignalRAPi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutController : ControllerBase
    {
        private readonly IAboutService _aboutService;

        public AboutController(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }

        [HttpGet]

        public async Task<IActionResult> AboutList()
        {
            var values = await _aboutService.TGetAll();

            return Ok(values);
        }

        [HttpPost]

        public async Task<IActionResult> CreateAbout(CreateAboutDto request)
        {
            About about = new About()
            {
                Title = request.Title,
                Description = request.Description,
                ImageUrl = request.ImageUrl,
            };

            await _aboutService.TAdd(about);
            return Ok("About Added Succesfully ");
        }

        [HttpDelete]

        public async Task<IActionResult> DeleteAbout(int id)
        {
            var value = await _aboutService.TGetByID(id);

            await _aboutService.TDelete(value);

            return Ok("About deleted Succesfully");
        }

        [HttpPut]

        public async Task<IActionResult> UpdateAbout(UpdateAboutDto request)
        {
            About about = new About()
            {
                AboutId= request.AboutId,
                Title = request.Title,
                Description = request.Description,
                ImageUrl = request.ImageUrl,
            };

            await _aboutService.TUpdate(about);

            return Ok("About Updated Succesfully ");
        }

        [HttpGet("GetAbout")]

        public async Task<IActionResult>GetAbout(int id)
        {
            var value=await _aboutService.TGetByID(id);

            return Ok(value);   
        }
    }
}
