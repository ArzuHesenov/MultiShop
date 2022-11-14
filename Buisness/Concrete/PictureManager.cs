using Buisness.Abstract;
using Core.Helper.FileHelper;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.Concrete
{
    public class PictureManager : IPictureService
    {
        private readonly IPictureDal _pictureDal;

        public PictureManager(IPictureDal pictureDal)
        {
            _pictureDal = pictureDal;
        }

        public List<Picture> AddPicture(List<IFormFile> Picture, string webrootpath)
        {
            List<Picture> pics = new();
            for (int i = 0; i < Picture.Count; i++)
            {
                var res = Picture[i].UploadPicture(webrootpath);
                Picture image = new()
                {
                    PhotoUrl = res
                };
                var result = _pictureDal.AddPictures(image);

                pics.Add(result);
            }
            return pics;
        }
    }
}
