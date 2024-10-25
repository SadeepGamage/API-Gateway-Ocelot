using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommentService.Models;
using Microsoft.EntityFrameworkCore;

namespace CommentService.Data
{
    public class CommentDbContext:DbContext
    {
        public CommentDbContext(DbContextOptions<CommentDbContext> options):base(options)
        {

        }
        public DbSet<CommentModel>Comments {get;set; }
    }
}