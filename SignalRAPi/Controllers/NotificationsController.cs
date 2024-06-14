using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.NotificationDto;
using SignalR.EntityLayer.Entities;

namespace SignalRAPi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class NotificationsController : ControllerBase
	{
		private readonly INotificationService _notificationService;
		private readonly IMapper _mapper;

		public NotificationsController(INotificationService notificationService, IMapper mapper)
		{
			_notificationService = notificationService;
			_mapper = mapper;
		}
		[HttpGet]
		public async Task<IActionResult> NotificationList()
		{
			var values = _mapper.Map<List<ResultNotificationDto>>(await _notificationService.TGetAll());

			return Ok(values);
		}

		[HttpGet("NotificationCountByStatudFalse")]
		public async Task<IActionResult> NotificationCountByStatudFalse()
		{
			var values = await _notificationService.TNotificationCountByStatusFalseAsync();

			return Ok(values);
		}

		[HttpGet("GetNotificationsByStatudFalse")]
		public async Task<IActionResult> GetNotificationsByStatudFalse()
		{
			var values = _mapper.Map<List<ResultNotificationDto>>(await _notificationService.TGetNotificationsByStatusFalseAsync());

			return Ok(values);
		}

		[HttpPost]
		public async Task<IActionResult> CreateNotification(CreateNotificationDto createNotificationDto)
		{
			Notification notification = new Notification()
			{
				Description = createNotificationDto.Description,
				Icon = createNotificationDto.Icon,
				Status = false,
				Type = createNotificationDto.Type,
				Date = createNotificationDto.Date
			};
			await _notificationService.TAdd(notification);
			return Ok("Notification addeed successfully");
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteNotification(int id)
		{
			var value = await _notificationService.TGetByID(id);
			await _notificationService.TDelete(value);
			return Ok("Notification deleted successfully");
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetNotification(int id)
		{
			var value = await _notificationService.TGetByID(id);
			return Ok(value);
		}

		[HttpPut]
		public async Task<IActionResult> UpdateNotification(UpdateNotificationDto updateNotificationDto)
		{
			Notification notification = new Notification()
			{
				NotificationID = updateNotificationDto.NotificationID,
				Description = updateNotificationDto.Description,
				Icon = updateNotificationDto.Icon,
				Status = updateNotificationDto.Status,
				Type = updateNotificationDto.Type,
				Date = updateNotificationDto.Date
			};
			await _notificationService.TUpdate(notification);
			return Ok("Notification updated successfully");
		}

        [HttpGet("NotificationStatusChangeToTrue/{id}")]

        public async Task<IActionResult> NotificationStatusChangeToTrue(int id)
		{
			await _notificationService.TNotificationStatusChangeToTrueAsync(id);

			return Ok("Notification Status changed to true");
		}

		[HttpGet("NotificationStatusChangeToFalse/{id}")]

        public async Task<IActionResult> NotificationStatusChangeToFalse(int id)
        {
            await _notificationService.TNotificationStatusChangeToFalseAsync(id);

            return Ok("Notification Status changed to false");

        }


    }
}
