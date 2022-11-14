using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class ProductPicture : IEntity
    {
        public int Id { get; set; }
        public int PictureId { get; set; }
        public Picture Picture { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }

    }
}
