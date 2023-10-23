using LibraryAPI.Application.Repositories.BookRepositories.CategoryRepository;
using LibraryAPI.Application.Services.ReadServices.CategoryReadService;
using LibraryAPI.Application.Services.ReadServices.PublisherReadService;
using LibraryAPI.Application.Services.WriteServices.CategoryWriteServices;
using LibraryAPI.Application.Services.WriteServices.PublisherWriteServices;
using LibraryAPI.Domain.Entities.BookEntites;
using LibraryAPI.Dtos.Resources.CategoryResources;
using LibraryAPI.Dtos.Resources.PublisherResources;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryReadService _categoryReadService;
        private readonly ICategoryWriteService _categoryWriteService;
        public CategoryController(ICategoryWriteService categoryWriteService, ICategoryReadService categoryReadService)
        {

            _categoryWriteService = categoryWriteService;
            _categoryReadService = categoryReadService;
        }

        [HttpPost("addCategory")]
        public async Task<IActionResult> AddCategory(AddCategoryDto addCategoryDto)
        {
            var res = await _categoryWriteService.AddCategory(addCategoryDto);
            return Ok(res);

        }
        [HttpPost("deleteCategory")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var res = await _categoryWriteService.DeleteCategory(id);
            return Ok(res);
        }
        [HttpPost("updateCategory")]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryDto category)
        {
            var res = await _categoryWriteService.UpdateCategory(category);
            return Ok(res);
        }

        [HttpGet("getAllCategory")]
        public async Task<IActionResult> GetAllCategory()
        {
            var res = await _categoryReadService.GetAllCategory();
            return Ok(res);
        }
        [HttpGet("getAllCategoryView")]
        public async Task<IActionResult> GetAllCategoryView()
        {
            var res = await _categoryReadService.GetAllCategoryView();
            return Ok(res);
        }
        [HttpGet("getCategoryById")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            var res = await _categoryReadService.GetCategoryById(id);
            return Ok(res);
        }
        [HttpGet("getCategoryByName")]
        public async Task<IActionResult> GetCategoryByName(string name)
        {
            var res = await _categoryReadService.GetCategoryByName(name);
            return Ok(res);
        }

    }
}
