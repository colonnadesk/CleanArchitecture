using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public abstract class ApiControllerBase : ControllerBase
    {
        private ISender mediator = null!;

        protected ISender Mediator => this.mediator ??= this.HttpContext.RequestServices.GetRequiredService<ISender>();
    }
}
