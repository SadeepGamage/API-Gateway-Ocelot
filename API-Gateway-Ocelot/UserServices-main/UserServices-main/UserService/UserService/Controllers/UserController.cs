using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
// using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using UserService.Models;
using UserService.Services;

namespace UserService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController:ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet]
        public async Task<IActionResult>GetAllUsers()
        {
            var users = await _userService.GetAllUsersAsync();
            return Ok(users);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            if(user == null)return NotFound("There Is No User Called Input");
            return Ok(user);

        }
        [HttpGet("email/{email}")]
        public async Task<IActionResult> GetUserByEmail(string email)
        {
            var user = await _userService.GetUserByEmailAsync(email);
            if(user == null)return NotFound("There is No user by That User");
            return Ok(user);
        }
        [HttpPost]
        public async Task<IActionResult>Create(UserModel user)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest("Check Your Form");
            }
            await _userService.AddUserAsync(user);
            return Ok(user);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult>UpdateUser(int id , UserModel userModel)
        {
            if(id != userModel.UserId )
            {
                return NotFound("InValid User");
            }
            await _userService.UpdateUserAsync(id , userModel);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult>DeleteUser(int id)
        {
            await _userService.DeleteUserAsync(id);
            return NoContent();
        }
    }
}