using Blog.Data;
using Blog.Models;
using Blog.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IFileManager _fileManager;
        private readonly IBlogRepository _repository;

        public HomeController(ILogger<HomeController> logger, IFileManager fileManager, IBlogRepository repository)
        {
            _logger = logger;
            _fileManager = fileManager;
            _repository = repository;
        }


        //Get all the post without Filters...
        public IActionResult Index()
        {
            var result = _repository.GetAllPost();
            return View(result);
        }




        public IActionResult AddPost()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddPost(Post postModel)
        {
            if (postModel == null)
            {
                return NotFound();
            }
            _repository.AddPostAsync(postModel);
            return RedirectToAction("Index");
        }



        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var postInfo = _repository.GetPost(id);
            return View(postInfo);
        }



        [HttpGet("/Image/{image}")]
        public IActionResult Image(string image)
        {
            var mainFile = image.Substring(image.LastIndexOf(".") + 1);
            return new FileStreamResult(_fileManager.ImageStream(image), $"image/{mainFile}");

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
