using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUI.Controllers
{
    public class FooterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
