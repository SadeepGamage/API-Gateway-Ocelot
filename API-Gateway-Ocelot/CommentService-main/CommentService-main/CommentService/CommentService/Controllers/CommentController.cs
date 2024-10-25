using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommentService.Models;
using CommentService.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace CommentService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CommentController:ControllerBase
    {
        private readonly ICommentService _commentService;
        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }
        [HttpGet("{postId}")]
        public async Task<IActionResult>GetCommentsByPostId(int postId)
        {
            var comments = await _commentService.GetCommentsPostById(postId);
            return Ok(comments);
        }
        [HttpGet("comment.{commentId}")]
        public async Task<IActionResult> GetCommentById(int commentId)
        {
            var comment = await _commentService.GetCommentById(commentId);
            if(comment == null)return NotFound("There is no Comment");
            return Ok(comment);
        }
        [HttpPost]
        public async Task<IActionResult>AddComment([FromBody] CommentModel comment)
        {
            var createdComment = await _commentService.AddComment(comment);
            return CreatedAtAction(nameof(GetCommentById) , new {  commentId =createdComment.CommentId },createdComment);
        }
        [HttpPut("{commentId}")]
        public async Task<IActionResult>UpdateComment(int commentId , [FromBody] CommentModel comment)
        {
            if(commentId != comment.CommentId)return BadRequest("No Matching Ids ");
            var updated = await _commentService.UpdateComment(comment);
            if(updated == null )return NotFound("There is a ERR");
            return Ok(updated );
        }
        [HttpDelete("{commentId}")]
        public async Task<IActionResult>DeleteComment(int commentId)
        {
            var result = await _commentService.DeleteComment(commentId);
            if(!result)return NotFound("There is No Comment");
            return NoContent();
        }
    }
}