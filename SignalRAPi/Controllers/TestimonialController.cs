using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.ProductDto;
using SignalR.DtoLayer.TestimonialDto;
using SignalR.EntityLayer.Entities;

namespace SignalRAPi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialController : ControllerBase
    {
        private readonly ITestimonialService _testimonialService;
        private readonly IMapper _mapper;
        public TestimonialController(ITestimonialService testimonialService, IMapper mapper)
        {
            _testimonialService = testimonialService;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<IActionResult> TetsimonialList()
        {
            var value = _mapper.Map<List<ResultTestimonialDto>>(await _testimonialService.TGetAll());
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTestimonial(CreateTestimonialDto createTestimonialDto)
        {
            await _testimonialService.TAdd(new Testimonial()
            {
              Comment= createTestimonialDto.Comment,
              Name= createTestimonialDto.Name,
              ImageUrl= createTestimonialDto.ImageUrl,
              Status = createTestimonialDto.Status,
              Title = createTestimonialDto.Title,

            });
            return Ok("Testimonial added Successfully");
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTestimonial(int id)
        {
            var value = await _testimonialService.TGetByID(id);
            await _testimonialService.TDelete(value);
            return Ok("Testimonial deleted Successfully");
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetTestimonial(int id)
        {
            var value = await _testimonialService.TGetByID(id);
            return Ok(value);
        }


        [HttpPut]
        public async Task<IActionResult> UpdateTestimonial(UpdateTestimonialDto updateTestimonialDto)
        {
            await _testimonialService.TUpdate(new Testimonial()
            {
                TestimonialID= updateTestimonialDto.TestimonialID,
                Comment = updateTestimonialDto.Comment,
                Name = updateTestimonialDto.Name,
                ImageUrl = updateTestimonialDto.ImageUrl,
                Status = updateTestimonialDto.Status,
                Title = updateTestimonialDto.Title,
            });
            return Ok("Testimonial updated Successfully");
        }

    }
}
