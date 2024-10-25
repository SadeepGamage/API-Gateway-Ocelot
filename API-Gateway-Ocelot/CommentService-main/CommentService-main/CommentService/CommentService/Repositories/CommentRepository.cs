using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommentService.Data;
using CommentService.Models;
using Microsoft.EntityFrameworkCore;

namespace CommentService.Repositories
{
    public class CommentRepository:ICommentRepository
    {
        private readonly CommentDbContext _context ;

        public async Task<CommentModel> AddComment(CommentModel comment)
        {
            _context.Comments.Add(comment);
            await _context.SaveChangesAsync();
            return comment;
        }

        public async Task<bool> DeleteComment(int commentId)
        {
            var comment = await _context.Comments.FindAsync(commentId);
            if(comment == null)return false;
            _context.Comments.Remove(comment);
            await _context.SaveChangesAsync();
            return true; 
        }

        public async Task<CommentModel> GetCommentById(int commentId)
        {
            return await _context.Comments.FindAsync(commentId);
            
        }

        public async Task<CommentModel> GetCommentsByPostId(int postId)
        {
            var comment = await _context.Comments.FirstOrDefaultAsync(c=>c.PostId == postId);
            return comment;
        }

        public async Task<CommentModel> UpdateComment(CommentModel comment)
        {
            _context.Comments.Update(comment);
            await _context.SaveChangesAsync();
            return comment;
        }
    }
}