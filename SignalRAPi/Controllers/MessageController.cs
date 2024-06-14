using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.MessageDto;
using SignalR.EntityLayer.Entities;

namespace SignalRAPi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class MessageController : ControllerBase
	{
		private readonly IMessageService _messageService;
		private readonly IMapper _mapper;
		public MessageController(IMessageService messageService,
			                     IMapper mapper)
		{
			_messageService = messageService;
			_mapper = mapper;
		}

		[HttpGet]
		public async Task<IActionResult> MessageList()
		{
			var values = _mapper.Map<List<ResultMessageDto>>(await _messageService.TGetAll());
			return Ok(values);
		}

		[HttpPost]
		public async Task<IActionResult> CreateMessage(CreateMessageDto createMessageDto)
		{
			Message message = new Message()
			{
				Mail = createMessageDto.Mail,
				MessageContent = createMessageDto.MessageContent,
				MessageSendDate = DateTime.Now,
				NameSurname = createMessageDto.NameSurname,
				Phone = createMessageDto.Phone,
				Status = false,
				Subject = createMessageDto.Subject
			};

			await _messageService.TAdd(message);
			return Ok("Message added successfully");
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteMessage(int id)
		{
			var value =await _messageService.TGetByID(id);
			await _messageService.TDelete(value);
			return Ok("Message deleted successfully");
		}

		[HttpPut]
		public async Task<IActionResult> UpdateMessage(UpdateMessageDto updateMessageDto)
		{
			Message message = new Message()
			{
				Mail = updateMessageDto.Mail,
				MessageContent = updateMessageDto.MessageContent,
				MessageSendDate = updateMessageDto.MessageSendDate,
				NameSurname = updateMessageDto.NameSurname,
				Phone = updateMessageDto.Phone,
				Status = false,
				Subject = updateMessageDto.Subject,
				MessageID = updateMessageDto.MessageID
			};
			await _messageService.TUpdate(message);
			return Ok("Message updated successfully");
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetMessage(int id)
		{
			var value = _mapper.Map<ResultMessageDto>(await _messageService.TGetByID(id));
			return Ok(value);
		}
	}
}
