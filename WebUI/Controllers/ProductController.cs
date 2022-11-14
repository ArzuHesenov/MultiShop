using Buisness.Abstract;
using Microsoft.AspNetCore.Mvc;
using WebUI.ViewModels;

namespace WebUI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Detail(int id)
        {
            var product=_productService.GetProductById(id);
            var likeProducts = _productService.GetProductsBySubCategoryId(product.SubCategoryId, product.Id);
            ProductDetailVM vm = new()
            {
                Product = product,
                LikeProducts = likeProducts
            };
            return View(vm);
        }
    }
}
