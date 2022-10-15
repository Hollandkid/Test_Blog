using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.ViewModel
{
    public class PostViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; } = "";

        [Required]
        public string Body { get; set; } = "";

         public string Description { get; set; } = "";
        public string Tags { get; set; } = "";
        public string Categories { get; set; } = "";

        public string CurrentImage { get; set; } = "";

        [Required]
        public IFormFile Image { get; set; } = null;
    }
}
