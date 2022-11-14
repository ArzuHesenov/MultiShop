using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Picture : IEntity
    {
        public int Id { get; set; }
        public string PhotoUrl { get; set; }
        public List<ProductPicture> ProductPictures { get; set; }
    }
}
