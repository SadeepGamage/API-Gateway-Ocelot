using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CommentService.Models
{
    public class CommentModel
    {
        [Key]
        public int CommentId {get;set; }
        public int PostId { get; set;}
        public int UserId { get;set ;}
        public string Content { get;set; }
        public DateTime CreatedDate  {get;set; }
        
    }
}