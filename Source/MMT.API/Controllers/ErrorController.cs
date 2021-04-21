using Microsoft.AspNetCore.Mvc;

namespace MMT.API.Controllers
{
    using Microsoft.AspNetCore.Diagnostics;
    using Microsoft.Extensions.Logging;

    [ApiController]
    public class ErrorController : ControllerBase
    {
        private readonly ILogger<CategoryController> _logger;

        public ErrorController(ILogger<CategoryController> logger)
        {
            _logger = logger;
        }

        [Route("/error")]
        public IActionResult Error()
        {
            var context = HttpContext.Features.Get<IExceptionHandlerFeature>();

            _logger.LogError(context.Error, "An exception occurred.");

            return Problem();
        }
    }
}