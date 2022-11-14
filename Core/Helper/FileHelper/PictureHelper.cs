using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Helper.FileHelper
{
    
    public static class PictureHelper
    {
      

        public static string UploadPicture(this IFormFile file, string webrootpath)
        {
            var path ="/uploads/" + Guid.NewGuid().ToString() + file.FileName;
            using(var fileStream =new FileStream(webrootpath + path,FileMode.Create ))
            {
                file.CopyTo(fileStream);
            }
            return path;

        }
    }
}
