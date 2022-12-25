using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.API.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ErrorsController : ControllerBase
    {
        [Route("/error")]
        public IActionResult Error()
        {
            var exception = this.HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;
            if (exception != null)
            {
                return this.Problem(title: exception.Message);
            }

            return this.Problem();
        }
    }
}