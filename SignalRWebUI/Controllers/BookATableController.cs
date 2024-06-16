﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.Dtos.BookingDtos;
using System.Text;

namespace SignalRWebUI.Controllers
{
	[AllowAnonymous]
	public class BookATableController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BookATableController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> Index(CreateBookingDto createBookingDto)
        {

            var client = _httpClientFactory.CreateClient();

            var jsonData = JsonConvert.SerializeObject(createBookingDto);

            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");


            var responseMessage = await client.PostAsync("https://localhost:7209/api/Booking", content);

            if ((responseMessage.IsSuccessStatusCode))
            {
                return RedirectToAction("Index","Default");
            }

            return View();
        }
    }
}
