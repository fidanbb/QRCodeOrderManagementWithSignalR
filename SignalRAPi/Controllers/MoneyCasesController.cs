using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;

namespace SignalRAPi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class MoneyCasesController : ControllerBase
	{
		private readonly IMoneyCaseService _moneyCaseService;

		public MoneyCasesController(IMoneyCaseService moneyCaseService)
		{
			_moneyCaseService = moneyCaseService;
		}

		[HttpGet("TotalMoneyCaseAmount")]

		public async Task<IActionResult> TotalMoneyCaseAmount()
		{
			return Ok(await _moneyCaseService.TTotalMoneyCaseAmounAsync());
		}
	}
}
