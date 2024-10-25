using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PostService.Models;

namespace PostService.Repositories
{
    public interface IPostRepository
    {
        Task<IEnumerable<PostModel>> GetAllPostsAsync();
        Task<PostModel>GetPostByIdAsync (int PostId);
        Task AddPostAsync(PostModel post);
        Task UpdatePostAsync (PostModel post);
        Task DeletePostAsync (int postId);
    }
}