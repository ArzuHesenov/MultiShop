using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.SqlServer
{
    public class PictureDal : EfRepositoryBase<Picture, AppDbContext>, IPictureDal
    {
        public Picture AddPictures(Picture picture)
        {
            using (var context = new AppDbContext())
            {
                context.Pictures.Add(picture);
                context.SaveChanges();
            }

            return picture;
        }
    }
}
