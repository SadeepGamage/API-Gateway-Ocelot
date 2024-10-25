using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PostService.Models
{
    public class PostModel
    {
        [Key]
        public int PostId { get;set; }
        public int UserId { get;set; }
        public string Title { get;set; }
        public string Content { get;set; }
        public string? ImageUrl { get;set; }
        public DateTime CreatedDate { get;set; }
    }
}