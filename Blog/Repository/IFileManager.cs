using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading.Tasks;

namespace Blog.Repository
{
    public interface IFileManager
    {
        Task<string> SaveImage(IFormFile file);
        FileStream ImageStream(string image);
    }
}