using Entities.Concrete;

namespace WebUI.ViewModels
{
    public class DetailVM
    {
        public Category Category { get; set; }
        public List<Category> Categories { get; set; }
        public Product Product { get; set; }
        public List<Product> Products  { get; set; }
    }
}
