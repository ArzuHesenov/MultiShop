using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.Abstract
{
    public interface IPictureService
    {
        List<Picture> AddPicture(List<IFormFile> Picture, string webrootpath);
    }
}
