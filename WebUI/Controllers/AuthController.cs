using Core.Models.Concrete;
using Entities.DTO;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    public class AuthController : Controller
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;


        public AuthController(SignInManager<User> signInManager, UserManager<User> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginDTO model)
        {
            var user=await _userManager.FindByEmailAsync(model.Email);
            if (user == null) return View();

            var result = await _signInManager.PasswordSignInAsync(user, model.Password, false, false);
            if(result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterDTO model )
        {
         var user = await _userManager.FindByEmailAsync(model.Email);
            if(user != null)
            {
                return View(); 
            }
            User newUser = new()
            {
                UserName = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                PhotoUrl="avatar.jpg"
            };
            IdentityResult result = await _userManager.CreateAsync(newUser, model.Password);
            if(result.Succeeded)
            {
                return RedirectToAction("Login");
            }
            return View();
        }
    }
}
