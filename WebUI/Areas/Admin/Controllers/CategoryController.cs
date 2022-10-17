using Buisness.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {
            var categories= _categoryService.GetActiveCategories();
            return View(categories);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category category)
        {
            _categoryService.AddCategory(category);
            return RedirectToAction (nameof(Index));
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var category= _categoryService.GetCategoryById(id);
            return View(category);
        }
        [HttpPost]
        public IActionResult Edit(Category category)
        {
            _categoryService.UpdateCategory(category);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var category=_categoryService.GetCategoryById(id);
            return View(category);
        }
        [HttpPost]
        public IActionResult Delete(Category category)
        {
            _categoryService.DeleteCategory(category);
            return RedirectToAction(nameof(Index));
        }
    }
}
