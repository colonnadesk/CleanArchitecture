using Application.Services.Authentication;
using Contracts.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Controllers
{
    [ApiController]
    [Route("auth")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            this.authenticationService = authenticationService;
        }

        [HttpPost("register")]
        public async Task<ActionResult<AuthenticationResponse>> Register([FromBody] RegisterRequest request)
        {
            await Task.CompletedTask;
            var authResult = authenticationService.Register(request.Email, request.Password, request.FirstName, request.LastName);

            var response = new AuthenticationResponse(authResult.User.Id, authResult.User.Email, authResult.User.FirstName, authResult.User.LastName, authResult.Token);

            return Ok(response);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            await Task.CompletedTask;
            var authResult = authenticationService.Login(request.Email, request.Password);

            var response = new AuthenticationResponse(authResult.User.Id, authResult.User.Email, authResult.User.FirstName, authResult.User.LastName, authResult.Token);

            return Ok(response);
        }
    }
}
