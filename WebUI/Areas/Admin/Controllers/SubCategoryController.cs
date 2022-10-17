using Buisness.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SubCategoryController : Controller
    {
        private readonly ISubCategoryService _subCategoryService;

        public SubCategoryController(ISubCategoryService subCategoryService)
        {
            _subCategoryService = subCategoryService;
        }
        public IActionResult Index()
        {
            var subCategories = _subCategoryService.GetActiveSubCategories();
            return View(subCategories);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(SubCategory subCategory)
        {
            _subCategoryService.AddSubCategory(subCategory);
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

