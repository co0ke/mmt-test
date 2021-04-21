namespace MMT.API.Controllers
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using MMT.Src.Extensions;
    using MMT.Src.Services;

    [ApiController]
    [Route("categories")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            var results = await _categoryService.GetCategories();

            if (results.IsNullOrEmpty())
            {
                return new NotFoundResult();
            }

            return Ok(results);
        }
    }
}