using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PostService.Models;
using PostService.Services;

namespace PostService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PostController:ControllerBase
    {
        private readonly IPostService _postService;
        public PostController(IPostService postService)
        {
            _postService = postService;
        }

        [HttpGet]
        public async Task<IActionResult>GetAllPost()
        {
            var posts = await _postService.GetAllPostAsync();
            return Ok(posts);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPostById(int postId)
        {
            var post = await _postService.GetPostByIdAsync(postId);
            if(post == null)
            {
                return NotFound("There is no post like that");
            }
            return Ok(post);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult>UpdatePost(int id , PostModel post)
        {
            if(id != post.PostId)
            {
                return BadRequest("Post Id missmatch");
            }
            await _postService.UpdatePostAsync(post);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePost(int id)
        {
            await _postService.DeletePostAsync(id);
            return NoContent();
        }
        [HttpPost]
        public async Task<IActionResult> CreatePost(PostModel post)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest("Bad Post Request Fill the Post ");
            }
            await _postService.AddPostAsync(post);
            return Ok(post);
        }
        
    }
}