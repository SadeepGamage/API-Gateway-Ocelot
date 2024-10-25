using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserService.DTOs;
using UserService.Models;

namespace UserService.Services
{
    public interface IUserService
    {
        Task<IEnumerable<UserModel>> GetAllUsersAsync();
        Task<UserModel> GetUserByIdAsync(int id);
        Task<UserModel> GetUserByEmailAsync(string email);
        Task AddUserAsync(UserModel userModel);
        Task UpdateUserAsync(int id, UserModel userModel);
        Task DeleteUserAsync(int id);
    }
}