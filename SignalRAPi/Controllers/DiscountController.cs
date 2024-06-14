using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.DiscountDto;
using SignalR.EntityLayer.Entities;

namespace SignalRAPi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountController : ControllerBase
    {

        private readonly IDiscountService _discountService;
        private readonly IMapper _mapper;
        public DiscountController(IDiscountService discountService, IMapper mapper)
        {
            _discountService = discountService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> DiscountList()
        {
            var value = _mapper.Map<List<ResultDiscountDto>>(await _discountService.TGetAll());
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateDiscount(CreateDiscountDto createDiscountDto)
        {
           await _discountService.TAdd(new Discount()
            {
                 Status=false,
                Amount = createDiscountDto.Amount,
                Description = createDiscountDto.Description,
                ImageUrl = createDiscountDto.ImageUrl,
                Title = createDiscountDto.Title,
                
            });
            return Ok("Discount added Successfully");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDiscount(int id)
        {
            var value =await _discountService.TGetByID(id);
            await _discountService.TDelete(value);
            return Ok("Discount deleted Successfully");
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDiscount(int id)
        {
            var value =await _discountService.TGetByID(id);
            return Ok(value);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateDiscount(UpdateDiscountDto updateDiscountDto)
        {
           await _discountService.TUpdate(new Discount()
            {
                Amount = updateDiscountDto.Amount,
			   Status = false,
			   Description = updateDiscountDto.Description,
                ImageUrl = updateDiscountDto.ImageUrl,
                Title = updateDiscountDto.Title,
                DiscountID = updateDiscountDto.DiscountID,
            });
            return Ok("Discount updated Successfully");
        }

		[HttpGet("ChangeStatusToTrue/{id}")]
		public async Task<IActionResult> ChangeStatusToTrue(int id)
		{
		   await _discountService.TChangeStatusToTrue(id);
			return Ok("Product Discount Activated");
		}

		[HttpGet("ChangeStatusToFalse/{id}")]
		public async Task<IActionResult> ChangeStatusToFalse(int id)
		{
			await _discountService.TChangeStatusToFalse(id);
			return Ok("Product Discount Has Been Disabled");
		}

		[HttpGet("GetListByStatusTrue")]
		public async Task<IActionResult> GetListByStatusTrue()
		{
			return Ok(_mapper.Map<List<ResultDiscountDto>>(await _discountService.TGetListByStatusTrue()));
		}

	}
}
