using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Migrations;
using SignalR.DtoLayer.SliderDto;
using SignalR.EntityLayer.Entities;

namespace SignalRAPi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SlidersController : ControllerBase
    {
        private readonly ISliderService _sliderService;
        private readonly IMapper _mapper;

        public SlidersController(ISliderService sliderService,
                                 IMapper mapper)
        {
            _sliderService = sliderService;
            _mapper=mapper;
        }

        [HttpGet]
        public async Task<IActionResult> SliderList()
        {
            var values = _mapper.Map<List<ResultSliderDto>>(await _sliderService.TGetAll());

            return Ok(values);
        }

        [HttpPost]

        public async Task<IActionResult> CreateSlider(CreateSliderDto request)
        {
            await _sliderService.TAdd(new Slider()
            {
               Title = request.Title,
               Description=request.Description,
               Status = true
            });

            return Ok("Slider Added Successfully");
        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> DeleteSlider(int id)
        {
            var value = await _sliderService.TGetByID(id);

            await _sliderService.TDelete(value);

            return Ok("Slider Deleted Successfully");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSlider(int id)
        {
            var value = _mapper.Map<GetSliderDto>(await _sliderService.TGetByID(id));

            return Ok(value);
        }


        [HttpPut]

        public async Task<IActionResult> UpdateSlider(UpdateSliderDto request)
        {
            await _sliderService.TUpdate(new Slider()
            {
                SliderID = request.SliderID,
                Title = request.Title,
                Status = request.Status
            });

            return Ok("Slider updated Successfully");
        }
    }
}
