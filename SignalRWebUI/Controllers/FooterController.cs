using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.Dtos.FooterDtos;
using System.Text;

namespace SignalRWebUI.Controllers
{
    public class FooterController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public FooterController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.GetAsync("https://localhost:7209/api/Footers");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultFooterDto>>(jsonData);

                return View(values);
            }
            return View();
        }

        [HttpGet]
        public IActionResult CreateFooter()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> CreateFooter(CreateFooterDto createFooterDto)
        {
            var client = _httpClientFactory.CreateClient();

            var jsonData = JsonConvert.SerializeObject(createFooterDto);

            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");


            var responseMessage = await client.PostAsync("https://localhost:7209/api/Footers", content);

            if ((responseMessage.IsSuccessStatusCode))
            {
                return RedirectToAction("Index");
            }

            return View();
        }



        public async Task<IActionResult> DeleteFooter(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7209/api/Footers/{id}");

            if ((responseMessage.IsSuccessStatusCode))
            {
                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpGet]

        public async Task<IActionResult> UpdateFooter(int id)
        {
            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.GetAsync($"https://localhost:7209/api/Footers/{id}");

            if ((responseMessage.IsSuccessStatusCode))
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();

                var values = JsonConvert.DeserializeObject<UpdateFooterDto>(jsonData);

                return View(values);
            }

            return View();
        }

        [HttpPost]

        public async Task<IActionResult> UpdateFooter(UpdateFooterDto updateFooterDto)
        {
            var client = _httpClientFactory.CreateClient();

            var jsonData = JsonConvert.SerializeObject(updateFooterDto);

            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");


            var responseMessage = await client.PutAsync("https://localhost:7209/api/Footers", content);

            if ((responseMessage.IsSuccessStatusCode))
            {
                return RedirectToAction("Index");
            }

            return View();
        }
    }
}
