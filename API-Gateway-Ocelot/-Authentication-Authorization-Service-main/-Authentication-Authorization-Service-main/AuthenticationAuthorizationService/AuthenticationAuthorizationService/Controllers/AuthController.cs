using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthenticationAuthorizationService.DTOs;
using AuthenticationAuthorizationService.Models;
using AuthenticationAuthorizationService.Services;
using Microsoft.AspNetCore.Mvc;

namespace AuthenticationAuthorizationService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController:ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService =authService;
        }
        [HttpPost("register")]
        public async Task<IActionResult>Register([FromBody] RegisterModel registerModel)
        {
            var result = await _authService.Register(registerModel);
            if(!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }
            return Ok("User Registered Succcessfully");
        } 
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel loginModel)
        {
            var token = await _authService.Login(loginModel);
            if(token == null)
            {
                return Unauthorized("Invalid Creadentials");

            }
            return Ok(new { Token=token});
        }
    }
}