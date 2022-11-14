using Core.Models;
using Core.Models.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Product : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public string FromAuthor { get; set; }
        public decimal Quantity { get; set; }
        public string Description { get; set; }
        public string AdditionalInformation { get; set; }
        public bool IsConfirmed { get; set; }
        public int SubCategoryId { get; set; }
        public SubCategory SubCategory { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public int Hit { get; set; }
        public List<ProductPicture> ProductPictures { get; set; }


    }
}
