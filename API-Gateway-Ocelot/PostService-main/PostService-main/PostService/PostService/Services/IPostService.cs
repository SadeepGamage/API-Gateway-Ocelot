using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PostService.Models;

namespace PostService.Services
{
    public interface IPostService
    {
        Task<IEnumerable<PostModel>> GetAllPostAsync();
        Task<PostModel> GetPostByIdAsync (int postId);
        Task AddPostAsync (PostModel post);
        Task DeletePostAsync (int PostId);
        Task UpdatePostAsync (PostModel post);
    }
}