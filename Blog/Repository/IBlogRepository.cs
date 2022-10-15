using Blog.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Blog.Repository
{
    public interface IBlogRepository
    {
        List<Post> GetAllPost();
        Post GetPost(int? id);
        Task RemoveAsync(int? id);
        Task UpdatePostAsync(Post postModel);
        Task AddPostAsync(Post postModel);
        List<Post> GetAllPost(string catergory);
    }
}