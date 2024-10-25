using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserService.Models;

namespace UserService.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<UserModel>> GetAllUserAsync();
        Task<UserModel>GetUserByIdAsync (int id);
        Task<UserModel> GetUserByEmailAsync(string email);
        Task AddUserAsync (UserModel user);
        Task UpdateUserAsync (UserModel user);
        Task DeleteUserAsync (int id);
    }
}