using Buisness.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SubCategoryController : Controller
    {
        private readonly ISubCategoryService _subCategoryService;
        private readonly ICategoryService _categoryService;

        public SubCategoryController(ISubCategoryService subCategoryService, ICategoryService categoryService)
        {
            _subCategoryService = subCategoryService;
            _categoryService = categoryService;
        }
        public IActionResult Index()
        {
            var subCategories = _subCategoryService.GetActiveSubCategories();
            return View(subCategories);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var categories= _categoryService.GetAllCategories();
            return View(categories);
        }
        [HttpPost]
        public IActionResult Create(SubCategory subCategory, List<int> categoryIds)
        {
            _subCategoryService.AddSubCategory(subCategory,categoryIds);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var subCategory= _subCategoryService.GetSubCategoryById(id);
            return View(subCategory);
        }
        [HttpPost]
        public IActionResult Edit(SubCategory subCategory)
        {
            _subCategoryService.UpdateSubCategory(subCategory);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var subCategory = _subCategoryService.GetSubCategoryById(id);
            return View(subCategory);
        }
        [HttpPost]
        public IActionResult Delete(SubCategory subCategory)
        {
            _subCategoryService.DeleteSubCategory(subCategory);
            return RedirectToAction("Index");
        }
    }

    }

