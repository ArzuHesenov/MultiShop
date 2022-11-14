using Entities.Concrete;

namespace WebUI.ViewModels
{
    public class ProductDetailVM
    {
        public Product Product { get; set; }
        public List<Product> LikeProducts { get; set; }
    }
}
