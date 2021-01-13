using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Web_Projektas.Models;
using Web_Projektas.ViewModel;

namespace Web_Projektas.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        private readonly projektas_dbContext _context;

        /*public AccountController(UserManager<User> userManager,
            SignInManager<User> signInManager)
            {
            this.userManager = userManager;
            this.signInManager = signInManager;
            }
        */
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel userLog)
        {
            var result = await signInManager.PasswordSignInAsync(userLog.UserName , userLog.Password, false, false);
            if (result.Succeeded)
                return RedirectToAction("Index", "Home");

            ViewBag.Result = result.Succeeded;

            return View();
        }
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel userData)
        {
            if(ModelState.IsValid)
            {
                var user = new User
                {
                    UserName = userData.Username,
                    Email = userData.Email
                };

                var result = await userManager.CreateAsync(user, userData.Password);

                if(result.Succeeded)
                {
                    await signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Home");
                }

                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return View(userData);
            
        }
            public IActionResult UpdatePassword()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdatePassword(UpdatePasswordViewModel passwordData)
        {
            if (passwordData.NewPasswordRepeat != passwordData.NewPassword)
            {
                ViewBag.Error = "Naujo slaptažodžio laukai turi sutapti";
                return View(new UpdatePasswordViewModel());
            }

            var user = await userManager.GetUserAsync(HttpContext.User);
            var result = await userManager.ChangePasswordAsync(user, passwordData.OldPassword, passwordData.NewPassword);
            if (result.Succeeded)
            {
                ViewBag.UpdatePassword = "Slaptažodis atnaujintas sėkmingai.";
                return RedirectToAction("EditProfile");
            }

            ViewBag.Error = "Slaptažodžio atnaujinti nepavyko.";
            return View(new UpdatePasswordViewModel());
        }
    }

}
