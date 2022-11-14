using Microsoft.AspNetCore.Mvc;
using WebUI.Areas.Admin.ViewModels;
using Core.Helper.FileHelper;
using Buisness.Abstract;

namespace WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PictureController : Controller
    {
        private readonly IWebHostEnvironment _webHost;
        private readonly IPictureService _pictureService;

        public PictureController(IWebHostEnvironment webHost, IPictureService pictureService)
        {
            _webHost = webHost;
            _pictureService = pictureService;
        }

        [HttpPost]
        public JsonResult Upload(List<IFormFile> Picture)
        {
            var pictureResult = _pictureService.AddPicture(Picture, _webHost.WebRootPath);
            return Json(pictureResult);
        }
    }
}
