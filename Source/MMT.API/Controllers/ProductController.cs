namespace MMT.API.Controllers
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using MMT.Src.Extensions;
    using MMT.Src.Services;

    [ApiController]
    [Route("products")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService shopService)
        {
            _productService = shopService;
        }

        [HttpGet]
        [Route("featured")]
        public async Task<IActionResult> GetFeaturedProducts()
        {
            var results = await _productService.GetFeaturedProducts();

            if (results.IsNullOrEmpty())
            {
                return new NotFoundResult();
            }

            return Ok(results);
        }

        [HttpGet]
        [Route("category/{categoryId}")]
        public async Task<IActionResult> GetProductsByCategory(int categoryId)
        {
            if (categoryId == 0)
            {
                return new UnprocessableEntityResult();
            }

            var results = await _productService.GetProductsByCategory(categoryId);

            if (results.IsNullOrEmpty())
            {
                return new NotFoundResult();
            }

            return Ok(results);
        }
    }
}
