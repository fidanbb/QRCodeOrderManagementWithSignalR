using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.CategoryDto;
using SignalR.EntityLayer.Entities;

namespace SignalRAPi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> CategoryList()
        {
            var values =_mapper.Map<List<ResultCategoryDto>>(await _categoryService.TGetAll());

            return Ok(values);
        }

        [HttpPost]

        public async Task<IActionResult> CreateCategory(CreateCategoryDto request)
        {
            await _categoryService.TAdd(new Category()
            {
                CategoryName = request.CategoryName,
                Status = true
            });

            return Ok("Category Added Successfully");
        }

        [HttpDelete]

        public async Task<IActionResult>DeleteCategory(int id)
        {
            var value = await _categoryService.TGetByID(id);

            await _categoryService.TDelete(value);

            return Ok("Category Deleted Successfully");
        }

        [HttpGet("GetCategory")]
        public async Task<IActionResult> GetCategory(int id)
        {
            var value = _mapper.Map<ResultCategoryDto>(await _categoryService.TGetByID(id));

            return Ok(value);
        }


        [HttpPut]

        public async Task<IActionResult> UpdateCategory(UpdateCategoryDto request)
        {
            await _categoryService.TUpdate(new Category()
            {
                CategoryId=request.CategoryId,
                CategoryName = request.CategoryName,
                Status = request.Status
            });

            return Ok("Category updated Successfully");
        }
    }
}
