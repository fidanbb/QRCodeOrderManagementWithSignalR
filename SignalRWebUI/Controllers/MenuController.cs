using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.Dtos.CategoryDtos;
using SignalRWebUI.Dtos.ProductDtos;
using SignalRWebUI.Models.Product;

namespace SignalRWebUI.Controllers
{
    public class MenuController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public MenuController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage1 = await client.GetAsync("https://localhost:7209/api/Product/ProductListWithCategory");
            var productsWithCategory = new List<ResultProductWithCategory>();
            if (responseMessage1.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage1.Content.ReadAsStringAsync();
                productsWithCategory = JsonConvert.DeserializeObject<List<ResultProductWithCategory>>(jsonData);
            }



            var responseMessage2 = await client.GetAsync("https://localhost:7209/api/Category");
            var categoryDtos = new List<ResultCategoryDto>();
            if (responseMessage2.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage2.Content.ReadAsStringAsync();
                categoryDtos = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);
            }


            var viewModel = new ProductandCategoryViewModel
            {
                ProductsWithCategory = productsWithCategory,
                Categories = categoryDtos
            };

            return View(viewModel);
        }
    }
}
