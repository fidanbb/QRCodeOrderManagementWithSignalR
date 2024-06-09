using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.Dtos.ContactDtos;
using SignalRWebUI.Dtos.FooterDtos;
using SignalRWebUI.Dtos.SocialMediaDtos;
using SignalRWebUI.Models.Footer;

namespace SignalRWebUI.ViewComponents.UILayoutComponents
{
    public class _UILayoutFooterComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _UILayoutFooterComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7209/api/Footers");
            var footer =new List<ResultFooterDto>();
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                footer = JsonConvert.DeserializeObject<List<ResultFooterDto>>(jsonData);
            }

            var responseMessage2 = await client.GetAsync("https://localhost:7209/api/Contact");
            var contact = new List<ResultContactDto>();
            if (responseMessage2.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage2.Content.ReadAsStringAsync();
                contact = JsonConvert.DeserializeObject<List<ResultContactDto>>(jsonData);
            }

            var responseMessage3 = await client.GetAsync("https://localhost:7209/api/SocialMedia");
            var socialmedias = new List<ResultSocialMediaDto>();
            if (responseMessage3.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage3.Content.ReadAsStringAsync();
                socialmedias = JsonConvert.DeserializeObject<List<ResultSocialMediaDto>>(jsonData);
            }

            var viewModel = new FooterViewModel
            {
                Footer = footer.FirstOrDefault(),
                Contact = contact.FirstOrDefault(),
                SocialMedias = socialmedias
            };

            return View(viewModel);
        }
    }
}
