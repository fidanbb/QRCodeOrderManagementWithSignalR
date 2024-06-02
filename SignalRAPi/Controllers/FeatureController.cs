using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.DiscountDto;
using SignalR.DtoLayer.FeatureDto;
using SignalR.EntityLayer.Entities;

namespace SignalRAPi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeatureController : ControllerBase
    {
        private readonly IFeatureService _featureService;
        private readonly IMapper _mapper;
        public FeatureController(IFeatureService featureService, IMapper mapper)
        {
            _featureService = featureService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> FeatureList()
        {
            var value = _mapper.Map<List<ResultFeatureDto>>(await _featureService.TGetAll());
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateFeature(CreateFeatureDto createFeatureDto)
        {
            await _featureService.TAdd(new Feature()
            {
               Description1=createFeatureDto.Description1,
               Description2=createFeatureDto.Description2,
               Description3= createFeatureDto.Description3,
               Title1= createFeatureDto.Title1,
               Title2= createFeatureDto.Title2, 
               Title3   =createFeatureDto.Title3,

            });
            return Ok("Feature added Successfully");
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFeature(int id)
        {
            var value = await _featureService.TGetByID(id);
            await _featureService.TDelete(value);
            return Ok("Feature deleted Successfully");
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetFeature(int id)
        {
            var value = await _featureService.TGetByID(id);
            return Ok(value);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateFeature(UpdateFeatureDto updateFeatureDto)
        {
            await _featureService.TUpdate(new Feature()
            {
                FeatureID = updateFeatureDto.FeatureID,
                Description1 = updateFeatureDto.Description1,
                Description2 = updateFeatureDto.Description2,
                Description3 = updateFeatureDto.Description3,
                Title1 = updateFeatureDto.Title1,
                Title2 = updateFeatureDto.Title2,
                Title3 = updateFeatureDto.Title3,
            });
            return Ok("Feature updated Successfully");
        }
    }
}
