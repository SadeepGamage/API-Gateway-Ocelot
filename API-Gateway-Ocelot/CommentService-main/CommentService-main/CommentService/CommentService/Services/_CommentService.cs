using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommentService.Models;
using CommentService.Repositories;

namespace CommentService.Services
{
    public class _CommentService:ICommentService
    {
        private readonly ICommentRepository _commentRepository;
        public _CommentService(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public async Task<CommentModel> AddComment(CommentModel comment)
        {
            return await  _commentRepository.AddComment(comment);
        }

        public async Task<bool> DeleteComment(int commentId)
        {
            return await  _commentRepository.DeleteComment(commentId);
        }

        public async Task<CommentModel> GetCommentById(int commentId)
        {
            return await  _commentRepository.GetCommentById(commentId);
        }


        public async Task<CommentModel> GetCommentsPostById(int postId)
        {
            return await  _commentRepository.GetCommentsByPostId(postId);
        }

        public async Task<CommentModel> UpdateComment(CommentModel comment)
        {
            return await  _commentRepository.UpdateComment(comment);
        }
    }
}