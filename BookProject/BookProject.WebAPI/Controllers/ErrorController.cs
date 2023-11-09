using Autofac;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace BookProject.WebAPI.Controllers
{
    public class ErrorController : ControllerBase
    {
        private readonly ILogger<ErrorController> _logger;

        private IHttpContextAccessor _httpContextAccessor;

        public ErrorController(IComponentContext componentContext, ILogger<ErrorController> logger)
        {
            _logger = logger;
            _httpContextAccessor = componentContext.Resolve<IHttpContextAccessor>();
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [Route("/error"), AllowAnonymous]
        public IActionResult Error()
        {
            Exception? exception = _httpContextAccessor.HttpContext?.Features.Get<IExceptionHandlerFeature>()?.Error;            
			_logger.LogError(exception?.Message);
            return Problem(title: exception?.Message, statusCode: 400);
        }
    }
}
