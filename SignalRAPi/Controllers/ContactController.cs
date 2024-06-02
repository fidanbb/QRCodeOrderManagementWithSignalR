using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.ContactDto;
using SignalR.EntityLayer.Entities;

namespace SignalRAPi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;
        private readonly IMapper _mapper;

        public ContactController(IContactService contactService, IMapper mapper)
        {
            _contactService = contactService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> ContactList()
        {
            var values = _mapper.Map<List<ResultContactDto>>(await _contactService.TGetAll());

            return Ok(values);
        }

        [HttpPost]

        public async Task<IActionResult> CreateContact(CreateContactDto request)
        {

            await _contactService.TAdd(new Contact()
            {
                FooterDescription = request.FooterDescription,
                Location = request.Location,
                Mail = request.Mail,
                Phone = request.Phone,
              
            });

            return Ok("Contact Added Successfully");
        }

        [HttpDelete]

        public async Task<IActionResult> DeleteContact(int id)
        {
            var value = await _contactService.TGetByID(id);

            await _contactService.TDelete(value);

            return Ok("Contact Deleted Successfully");
        }

        [HttpGet("GetContact")]
        public async Task<IActionResult> GetContact(int id)
        {
            var value = _mapper.Map<ResultContactDto>(await _contactService.TGetByID(id));

            return Ok(value);
        }


        [HttpPut]

        public async Task<IActionResult> UpdateContact(UpdateContactDto request)
        {
            await _contactService.TUpdate(new Contact()
            {
                ContactID=request.ContactID,
                FooterDescription = request.FooterDescription,
                Location = request.Location,
                Mail = request.Mail,
                Phone = request.Phone,

            });

            return Ok("Contact updated Successfully");
        }
    }
}
