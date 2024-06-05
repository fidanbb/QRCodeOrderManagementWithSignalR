using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;

namespace SignalRAPi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class OrdersController : ControllerBase
	{
		private readonly IOrderService _orderService;

		public OrdersController(IOrderService orderService)
		{
			_orderService = orderService;
		}

		[HttpGet("TotalOrderCount")]

		public async Task<IActionResult> TotalOrderCount()
		{
			return Ok(await _orderService.TTotalOrderCountAsync());
		}


		[HttpGet("ActiveOrderCount")]

		public async Task<IActionResult> ActiveOrderCount()
		{
			return Ok(await _orderService.TActiveOrderCountAsync());
		}

		[HttpGet("LastOrderPrice")]

		public async Task<IActionResult> LastOrderPrice()
		{
			return Ok(await _orderService.TLastOrderPriceAsync());
		}

		[HttpGet("TodayTotalPrice")]

		public async Task<IActionResult> TodayTotalPrice()
		{
			return Ok(await _orderService.TTodayTotalPrice());
		}
	}
}
