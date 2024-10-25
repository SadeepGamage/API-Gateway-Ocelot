using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthenticationAuthorizationService.Models;
using Microsoft.AspNetCore.Identity;

namespace AuthenticationAuthorizationService.Repositories
{
    public class UserRepository:IUserRepository
    {
        private readonly UserManager<UserModel> _userManager;
        public UserRepository(UserManager<UserModel> userManager)
        {
            _userManager = userManager;
        }

        public async Task<bool> CheckPasswordAsync(UserModel user, string Password)
        {
            return await _userManager.CheckPasswordAsync(user , Password);
        }

        public async Task<UserModel> FindByEmailAsync(string email)
        {
            return await _userManager.FindByEmailAsync(email);
            // throw new NotImplementedException();
        }
    }
}