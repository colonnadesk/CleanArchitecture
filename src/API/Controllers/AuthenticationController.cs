﻿using Application.Services.Authentication;
using Contracts.Authentication;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            var authResult = authenticationService.Register(request.Email, request.Password, request.FirstName, request.LastName);

            var response = new AuthenticationResponse(authResult.User.Id, authResult.User.Email, authResult.User.FirstName, authResult.User.LastName, authResult.Token);

            return Ok(response);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var authResult = authenticationService.Login(request.Email, request.Password);

            var response = new AuthenticationResponse(authResult.User.Id, authResult.User.Email, authResult.User.FirstName, authResult.User.LastName, authResult.Token);

            return Ok(response);
        }
    }
}