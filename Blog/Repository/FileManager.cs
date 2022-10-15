using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Repository
{
    public class FileManager : IFileManager
    {
        private string imagePath;
        public FileManager(IConfiguration configuration)
        {
        
            imagePath = configuration["Path:Images"];
        }


        public async Task<string> SaveImage(IFormFile file)
        {
            try
            {
                var savePath = Path.Combine(imagePath);

                if (!Directory.Exists(savePath))
                {
                    Directory.CreateDirectory(savePath);
                }
                //Get the Mail File name
                var mainFile = file.FileName.Substring(file.FileName.LastIndexOf("."));
                //Give the File a Special name
                var fileName = $"img_{DateTime.Now.ToString("dd-MMyyyy-HH-mm-ss")}{mainFile}";

                using (var fileStream = new FileStream(Path.Combine(savePath, fileName), FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);

                }

                return fileName;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return "Error"+ex.Message;
            }
        }


        public FileStream ImageStream(string image)
        {
            return new FileStream(Path.Combine(imagePath,image),FileMode.Open,FileAccess.Read);
        }
    }
}
