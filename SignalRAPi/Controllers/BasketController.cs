using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.BasketDto;

namespace SignalRAPi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketService _basketService;
        private readonly IMapper _mapper;

        public BasketController(IBasketService basketService,
                                IMapper mapper)
        {
            _basketService = basketService;
            _mapper = mapper;
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetBasketByMenuTableID(int id)
        {
            return Ok(_mapper.Map<List<ResultBasketWithProductDto>>(await _basketService.TGetBasketByMenuTableNumberAsync(id)));
        }
    }
}
