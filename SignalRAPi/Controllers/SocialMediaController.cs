using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.SocialMediaDto;
using SignalR.DtoLayer.TestimonialDto;
using SignalR.EntityLayer.Entities;

namespace SignalRAPi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialMediaController : ControllerBase
    {
        private readonly ISocialMediaService _socialMediaService;
        private readonly IMapper _mapper;
        public SocialMediaController(ISocialMediaService socialMediaService, IMapper mapper)
        {
            _socialMediaService = socialMediaService;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<IActionResult> SocialMediaList()
        {
            var value = _mapper.Map<List<ResultSocialMediaDto>>(await _socialMediaService.TGetAll());
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSocialMedial(CreateSocialMediaDto createSocialMediaDto)
        {
            await _socialMediaService.TAdd(new SocialMedia()
            {
               Icon= createSocialMediaDto.Icon,
               Title=createSocialMediaDto.Title,
               Url=createSocialMediaDto.Url,

            });
            return Ok("Social Media added Successfully");
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSocialMedia(int id)
        {
            var value = await _socialMediaService.TGetByID(id);
            await _socialMediaService.TDelete(value);
            return Ok("Social Media deleted Successfully");
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetSocialMedia(int id)
        {
            var value = await _socialMediaService.TGetByID(id);
            return Ok(value);
        }


        [HttpPut]
        public async Task<IActionResult> UpdateSocialMedia(UpdateSocialMediaDto updateSocialMediaDto)
        {
            await _socialMediaService.TUpdate(new SocialMedia()
            {
                SocialMediaID= updateSocialMediaDto.SocialMediaID,
                Icon = updateSocialMediaDto.Icon,
                Title = updateSocialMediaDto.Title,
                Url = updateSocialMediaDto.Url,
            });
            return Ok("Social Media updated Successfully");
        }
    }
}
