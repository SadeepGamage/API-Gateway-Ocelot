using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PostService.Models;
using PostService.Repositories;

namespace PostService.Services
{
    public class _PostService:IPostService
    {
        private readonly IPostRepository _postRepository;
        public _PostService(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public async Task AddPostAsync(PostModel post)
        {
            await _postRepository.AddPostAsync(post);
        }

        public async Task DeletePostAsync(int PostId)
        {
            await _postRepository.DeletePostAsync(PostId);
        }

        public async Task<IEnumerable<PostModel>> GetAllPostAsync()
        {
            var posts = await _postRepository.GetAllPostsAsync();
            return posts;
        }

        public async Task<PostModel> GetPostByIdAsync(int postId)
        {
            var post = await _postRepository.GetPostByIdAsync(postId);
            if(post == null) return null;
            return post ;
        }

        public async Task UpdatePostAsync(PostModel post)
        {
            await _postRepository.UpdatePostAsync(post);
        }
    }
}