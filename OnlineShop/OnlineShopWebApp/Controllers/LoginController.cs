using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db.Models;
using OnlineShopWebApp.Areas.Admin.Models;

namespace OnlineShopWebApp.Controllers
{
    public class LoginController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _singInManager;

        public LoginController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _singInManager = signInManager;
        }

        public IActionResult Index(string returnUrl)
        {
            return View(new UserEnter() { ReturnUrl = returnUrl });
        }
        [HttpPost]
        public IActionResult Enter(UserEnter user)
        {
            if (ModelState.IsValid)
            {
                var result = _singInManager.PasswordSignInAsync(user.Login, user.Password, user.RememberMe, false).Result;
                if (result.Succeeded)
                {
                    return Redirect(user.ReturnUrl ??  "/Home/index");
                }
                    ModelState.AddModelError("", "Неправильный пароль");
            }
            return View("Index", user);
        }
        public IActionResult Registration(string returnUrl)
        {
            return View(new UserRegistration() { ReturnUrl = returnUrl });
        }
        [HttpPost]

        public IActionResult AddNewUser(UserRegistration user)
        {
            if (user.Login == user.Password)
            {
                ModelState.AddModelError("", "Логин и пароль не должны совпадать!");
            }
            if (ModelState.IsValid)
            {
                User newUser = new User { Email = user.Login, UserName = user.Login, PhoneNumber = user.Phone };
                var result = _userManager.CreateAsync(newUser, user.Password).Result;
                if (result.Succeeded)
                {
                    _singInManager.SignInAsync(newUser, false).Wait();
                    return Redirect(user.ReturnUrl ?? "/Home");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return View("Registration", user);
        }
        public IActionResult Logout()
        {
            _singInManager.SignOutAsync().Wait();
            return RedirectToAction("Index", "Home");
        }
    }
}
