using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthenticationAuthorizationService.Models;
using Microsoft.EntityFrameworkCore;

namespace AuthenticationAuthorizationService.Data
{
    public class AuthDbContext:DbContext
    {
        public AuthDbContext(DbContextOptions<AuthDbContext> options):base(options)
        {

        }
        public DbSet<UserModel>Users { get;set; }
        public DbSet<LoginModel> Logins { get;set; }
        public DbSet<RegisterModel>Registers { get;set ;}
    }
}