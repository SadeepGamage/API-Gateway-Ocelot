using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommentService.Models;

namespace CommentService.Services
{
    public interface ICommentService
    {
        Task<CommentModel>GetCommentsPostById(int postId);
        Task<CommentModel>GetCommentById (int commentId);
        Task<CommentModel> AddComment (CommentModel comment);
        Task<CommentModel>UpdateComment(CommentModel comment);
        Task<bool>DeleteComment(int commentId);
    }
}