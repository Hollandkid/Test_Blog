using Blog.Data;
using Blog.Models;
using Blog.Repository;
using Blog.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Controllers
{

    [Authorize(Roles ="Admin")]
    public class AdminPanelController : Controller
    {
        private readonly IFileManager _fileManager;
        private readonly IBlogRepository _repository;

        public AdminPanelController(IFileManager fileManager, IBlogRepository repository)
        {
            _fileManager = fileManager;
            _repository = repository;
        }


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



        public IActionResult Update(int? id)
        {
            if (id == null)
            {
                //return NotFound();
                return View(new PostViewModel());
            }

            var postInfo = _repository.GetPost(id);

            var postVm = new PostViewModel()
            {
                Id = postInfo.Id,
                Title = postInfo.Title,
                Body = postInfo.Body,
                Description = postInfo.Description,
                Tags = postInfo.Tags,
                Categories = postInfo.Categories,
                CurrentImage = postInfo.Image  //This is to set the Value of the Previous Image b4 any Update...
            };
            return View(postVm);
        }


        [HttpPost]
        public async Task<IActionResult> Update(PostViewModel postVm)
        {
            var postModel = new Post()
            {
                Id = postVm.Id,
                Body = postVm.Body,
                Title = postVm.Title,
                Description = postVm.Description,
                Tags = postVm.Tags,
                Categories = postVm.Categories
                //Image = await _fileManager.SaveImage(postVm.Image)   //Handles the image
            };
            if (postVm.Image == null)
            {
                postModel.Image = postVm.CurrentImage;
            }
            else
            {
                postModel.Image = await _fileManager.SaveImage(postVm.Image);
            }
            if (postModel != null)
            {
                await _repository.UpdatePostAsync(postModel);
            }
            return RedirectToAction("Index");
        }




        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            _repository.RemoveAsync(id);
            return RedirectToAction("Index");
        }

        //[HttpPost]
        //public async Task<IActionResult> Delete(Post postModel)
        //{
        //    if (postModel != null)
        //    {
        //        var result = await _dbContext.Posts.AddAsync(postModel);
        //        await _dbContext.SaveChangesAsync();
        //    }
        //    return RedirectToAction("Index");
        //}

    }
}
