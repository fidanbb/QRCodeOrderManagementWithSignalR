using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.Dtos.BasketDtos;

namespace SignalRWebUI.Controllers
{
    public class BasketController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BasketController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IActionResult> Index()
        {
            var client =_httpClientFactory.CreateClient();

            var responseMessage = await client.GetAsync("https://localhost:7209/api/Basket/3");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData=await responseMessage.Content.ReadAsStringAsync();

                var values= JsonConvert.DeserializeObject<List<ResultBasketWithProductDto>>(jsonData);

                return View(values);
            }
            return View();
        }
    }
}
