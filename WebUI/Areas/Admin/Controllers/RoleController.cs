using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public RoleController(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public IActionResult Index()
        {
            var roles = _roleManager.Roles.ToList();
            return View(roles);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(IdentityRole identityRole)
        {
            if(!ModelState.IsValid)
            {
                return View(identityRole);
            }

            IdentityResult result = await _roleManager.CreateAsync(identityRole);
            if(result.Succeeded)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
