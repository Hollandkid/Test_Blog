using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Models
{
    public class Post
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; } = "";

        [Required]
        public string Body { get; set; } = "";
        public string Description { get; set; } = "";
        public string Tags { get; set; } = "";
        public string Categories { get; set; } = "";

        public string Image { get; set; } = "";

        [Required]
        public DateTime Created { get; set; } = DateTime.Now;
    }
}
