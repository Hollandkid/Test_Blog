using Blog.Data;
using Blog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Repository
{
    public class BlogRepository : IBlogRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public BlogRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        //Get all the post Without no Filter
        public List<Post> GetAllPost()
        {
            var result = _dbContext.Posts.ToList();
            return result;
        }



        //Get all the post related to a Filter
        public List<Post> GetAllPost(string catergory)
        {
            var result = _dbContext.Posts.Where(c => c.Categories.ToLower() ==catergory.ToLower()).ToList();
            return result;
        }

        public Post GetPost(int? id)
        {
           
            var result = _dbContext.Posts.FirstOrDefault(c => c.Id == id);
            return result;
        }


        public async Task AddPostAsync(Post postModel)
        {
            var result = await _dbContext.Posts.AddAsync(postModel);
            await _dbContext.SaveChangesAsync();
        }
        
        
        
        public async Task UpdatePostAsync(Post postModel)
        {
            var result = _dbContext.Posts.Update(postModel);
            await _dbContext.SaveChangesAsync();
        }


        public async Task RemoveAsync(int? id)
        {
            var post = GetPost(id);
             _dbContext.Posts.Remove(post);
            await _dbContext.SaveChangesAsync();
        }
    }
}
