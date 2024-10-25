using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UserService.Data;
using UserService.Models;

namespace UserService.Repositories
{
    public class UserRepository:IUserRepository
    {
        private readonly UserDbContext _context ;

        public UserRepository(UserDbContext context )
        {
            _context= context;
        }

        public async Task AddUserAsync(UserModel user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

        }

        public async Task DeleteUserAsync(int id)
        {
            var user =await _context.Users.FindAsync(id);
            if(user!= null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            } 
        }

        public async Task<IEnumerable<UserModel>> GetAllUserAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<UserModel> GetUserByEmailAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u =>u.Email == email);
        }

        public async Task<UserModel> GetUserByIdAsync(int id)
        {
            return await _context.Users.FirstOrDefaultAsync(u=>u.UserId == id);
        }

        public async Task UpdateUserAsync(UserModel user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }
    }
}