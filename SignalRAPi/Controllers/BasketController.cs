using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.BasketDto;
using SignalR.EntityLayer.Entities;

namespace SignalRAPi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketService _basketService;
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public BasketController(IBasketService basketService,
                                IProductService productService,
                                IMapper mapper)
        {
            _basketService = basketService;
            _productService = productService;
            _mapper = mapper;
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetBasketByMenuTableID(int id)
        {
            return Ok(_mapper.Map<List<ResultBasketWithProductDto>>(await _basketService.TGetBasketByMenuTableNumberAsync(id)));
        }


        [HttpPost]

        public async Task<IActionResult> CreateBasket(CreateBasketDto createBasketDto)
        {
            var basket = await _basketService.TGetBasketByProductID(createBasketDto.ProductID, 4); //get basket by productId and MenuTableId


            if (basket != null)
            {
                var count = basket.Count;
                count++;
                await _basketService.TUpdate(new Basket()
                {
                    BasketID = basket.BasketID,
                    Count = count,
                    MenuTableID = 4,
                    ProductID = createBasketDto.ProductID,
                    Price = await _productService.TGetPriceByProductID(createBasketDto.ProductID),
                    TotalPrice = 0
                });
            }



            else
            {
                await _basketService.TAdd(new Basket()
                {
                    ProductID = createBasketDto.ProductID,
                    Count = 1,
                    MenuTableID = 4,
                    Price = await _productService.TGetPriceByProductID(createBasketDto.ProductID),
                    TotalPrice = 0
                });
            }


            return Ok("Product successfully added to basket");
        }



        [HttpDelete("{id}")]

        public async Task<IActionResult>DeleteBasket(int id)
        {
            var value = await _basketService.TGetByID(id);

            await _basketService.TDelete(value);

            return Ok("Basket successfully deleted");

        }
    }
}
