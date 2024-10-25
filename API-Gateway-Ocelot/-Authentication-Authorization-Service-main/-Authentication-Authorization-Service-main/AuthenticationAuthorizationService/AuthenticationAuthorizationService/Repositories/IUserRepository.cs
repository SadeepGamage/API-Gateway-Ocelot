using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthenticationAuthorizationService.Models;

namespace AuthenticationAuthorizationService.Repositories
{
    public interface IUserRepository
    {
        Task<UserModel>FindByEmailAsync(string email);
        Task<bool> CheckPasswordAsync(UserModel user , string Password);
    }
}