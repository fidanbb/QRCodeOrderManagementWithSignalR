using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.MenuTableDto;
using SignalR.EntityLayer.Entities;

namespace SignalRAPi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class MenuTablesController : ControllerBase
	{
		private readonly IMenuTableService _menuTableService;
		private readonly IMapper _mapper;

		public MenuTablesController(IMenuTableService menuTableService,
			                        IMapper mapper)
		{
			_menuTableService = menuTableService;
			_mapper = mapper;
		}

		[HttpGet("MenuTableCount")]

		public async Task<IActionResult> MenuTableCount()
		{
			return Ok(await _menuTableService.TMenuTableCountAsync());
		}


        [HttpGet]
        public async Task<IActionResult> MenuTableList()
        {
            var values = _mapper.Map<List<ResultMenuTableDto>>(await _menuTableService.TGetAll());

            return Ok(values);
        }

        [HttpPost]

        public async Task<IActionResult> CreateMenuTable(CreateMenuTableDto request)
        {
            var value = _mapper.Map<MenuTable>(request);
            value.Status = false;
            await _menuTableService.TAdd(value);

            return Ok("MenuTable Added Successfully");
        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> DeleteMenuTable(int id)
        {
            var value = await _menuTableService.TGetByID(id);

            await _menuTableService.TDelete(value);

            return Ok("MenuTable Deleted Successfully");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMenuTable(int id)
        {
            var value = _mapper.Map<GetMenuTableDto>(await _menuTableService.TGetByID(id));

            return Ok(value);
        }


        [HttpPut]

        public async Task<IActionResult> UpdateMenuTable(UpdateMenuTableDto request)
        {
            var value = _mapper.Map<MenuTable>(request);
            value.Status = false;
            await _menuTableService.TUpdate(value);

            return Ok("MenuTable updated Successfully");
        }
    }
}
