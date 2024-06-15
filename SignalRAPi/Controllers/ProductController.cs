using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.FeatureDto;
using SignalR.DtoLayer.ProductDto;
using SignalR.EntityLayer.Entities;

namespace SignalRAPi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> ProductList()
        {
            var value = _mapper.Map<List<ResultProductDto>>(await _productService.TGetAll());
            return Ok(value);
        }



        [HttpGet("ProductListWithCategory")]
        public async Task<IActionResult> ProductListWithCategory()
        {
            var value = _mapper.Map<List<ResultProductWithCategory>>(await _productService.TGetProductsWithCategoriesAsync());
            return Ok(value);
        }


        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductDto createProductDto)
        {
            await _productService.TAdd(new Product()
            {
                ProductName= createProductDto.ProductName,
                Price= createProductDto.Price,
                ProductStatus= createProductDto.ProductStatus,
                Description= createProductDto.Description,
                ImageUrl= createProductDto.ImageUrl,
                CategoryId=createProductDto.CategoryID

            });
            return Ok("Product added Successfully");
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var value = await _productService.TGetByID(id);
            await _productService.TDelete(value);
            return Ok("Product deleted Successfully");
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var value = await _productService.TGetByID(id);
            return Ok(value);
        }


        [HttpPut]
        public async Task<IActionResult> UpdateProduct(UpdatepPoductDto updatepPoductDto)
        {
            await _productService.TUpdate(new Product()
            {
                ProductId= updatepPoductDto.ProductId,
                ProductName = updatepPoductDto.ProductName,
                Price = updatepPoductDto.Price,
                ProductStatus = updatepPoductDto.ProductStatus,
                Description = updatepPoductDto.Description,
                ImageUrl = updatepPoductDto.ImageUrl,
                CategoryId=updatepPoductDto.CategoryID
            });
            return Ok("Product updated Successfully");
        }

        [HttpGet("ProductCount")]

        public async Task<IActionResult> ProductCount()
        {
            return Ok(await _productService.TProductCountAsync());
        }


		[HttpGet("ProductCountByHamburger")]

		public async Task<IActionResult> ProductCountByHamburger()
		{
			return Ok(await _productService.TProductCountByCategoryNameHamburgerAsync());
		}


		[HttpGet("ProductCountByDrink")]

		public async Task<IActionResult> ProductCountByDrink()
		{
			return Ok(await _productService.TProductCountByCategoryNameDrinkAsync());
		}

		[HttpGet("AverageProductPrice")]

		public async Task<IActionResult> AverageProductPrice()
		{
			return Ok(await _productService.TAverageProductPriceAsync());
		}


		[HttpGet("ProductNameByHighestPrice")]

		public async Task<IActionResult> ProductNameByHighestPrice()
		{
			return Ok(await _productService.TProductNameWithHighestPriceAsync());
		}


		[HttpGet("ProductNameByLowestPrice")]

		public async Task<IActionResult> ProductNameByLowestPrice()
		{
			return Ok(await _productService.TProductNameWithLowestPriceAsync());
		}


		[HttpGet("AverageProductPriceByHamburger")]

		public async Task<IActionResult> AverageProductPriceByHamburger()
		{
			return Ok(await _productService.TAverageProductPriceByHamburgerAsync());
		}

		[HttpGet("ProductPriceBySteakBurger")]
		public async Task<IActionResult> ProductPriceBySteakBurger()
		{
			return Ok(await _productService.TProductPriceBySteakBurger());
		}

		[HttpGet("TotalPriceByDrinkCategory")]
		public async Task<IActionResult> TotalPriceByDrinkCategory()
		{
			return Ok(await _productService.TTotalPriceByDrinkCategory());
		}

		[HttpGet("TotalPriceBySaladCategory")]
		public async Task<IActionResult> TotalPriceBySaladCategory()
		{
			return Ok(await _productService.TTotalPriceBySaladCategory());
		}

		[HttpGet("TotalProductPrice")]
		public async Task<IActionResult> TotalProductPrice()
		{
			return Ok(await _productService.TTotalProductPriceAsync());
		}

	}
}
