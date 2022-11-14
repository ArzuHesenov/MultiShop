using Core.Models.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebUI.Areas.Admin.ViewModels;

namespace WebUI.Areas.Admin.Controllers
{
    [Area(nameof(Admin))]
    public class UserRoleController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserRoleController(RoleManager<IdentityRole> roleManager, UserManager<User> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var user = _userManager.Users.ToList();
            return View(user);
        }
        public IActionResult Create()
        {
            return View();
        }
        public async Task<IActionResult> AddRole(string id)
        {
            if (id == null)
                return NotFound();
            User user= await _userManager.FindByIdAsync(id);
            if (user == null) return NotFound();
            var userRoles=(await _userManager.GetRolesAsync(user)).ToList();
            var roles = _roleManager.Roles.Select(role => role.Name).ToList();

            AddUserRoleVM addUserRoleVM = new()
            {
                User = user,
                Roles = roles.Except(userRoles)
            };
            return View(addUserRoleVM);
        }
        [HttpPost]
        public async Task<IActionResult> AddRole(string id, string role)
        {
            if (id == null) return NotFound();
            User user=await _userManager.FindByIdAsync(id);
            if (user == null) return NotFound();

            var result=await _userManager.AddToRoleAsync(user, role);

            if(result.Succeeded)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
