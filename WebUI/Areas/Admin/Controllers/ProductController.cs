using Buisness.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly ISubCategoryService _subCategoryService;
        private readonly IProductService _productService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IProductPictureService _productPictureService;
        public ProductController(ISubCategoryService subCategoryService, IProductService productService, IProductPictureService productPictureService, IHttpContextAccessor httpContextAccessor)
        {
            _subCategoryService = subCategoryService;
            _productService = productService;
            _productPictureService = productPictureService;
            _httpContextAccessor = httpContextAccessor;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var subCategories = _subCategoryService.GetAllSubCategories();
            return View(subCategories);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Product product, List<string> pictureIds)
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            product.UserId = userId;
            _productService.AddProduct(product);

            for (int i = 0; i < pictureIds.Count; i++)
            {
                ProductPicture productPicture = new()
                {
                    PictureId = Convert.ToInt32(pictureIds[i]),
                    ProductId = product.Id
                };

                _productPictureService.AddProductPicture(productPicture);
            }
            return RedirectToAction("Index");
        }


    }

}
