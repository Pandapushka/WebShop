using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShop.Db.Models;
using OnlineShopWebApp.Areas.Admin.Models;
using OnlineShopWebApp.Helpers;
using OnlineShopWebApp.Repository;
using System.Data;
using System.Linq;

namespace OnlineShopWebApp.Areas.Admin.Controllers
{
    [Area(Constans.AdminRoleName)]
    [Authorize(Roles = Constans.AdminRoleName)]
    public class UserController : Controller
    {
        private readonly UserManager<User> userManager;
        public UserController(UserManager<User> usersManager)
        {
            this.userManager = usersManager;
        }
        public IActionResult Users()
        {
            var userAccount = userManager.Users.ToList();
            return View(userAccount.Select(x=>x.ToUserVM()).ToList());
        }
        public IActionResult Details(string name)
        {
            var user = userManager.FindByEmailAsync(name).Result;
            return View(user.ToUserVM());
        }
        public IActionResult ChangePassword(string name)
        {
            var changePassword = new ChangePassword()
            {
                Name = name
            };
            return View(changePassword);
        }
        [HttpPost]
        public IActionResult ChangePassword(ChangePassword changePassword)
        {
            if (changePassword.Name == changePassword.Password)
            {
                ModelState.AddModelError("", "Логин и пароль не должны совпадать!");
            }
            if (ModelState.IsValid)
            {
                var user = userManager.FindByNameAsync(changePassword.Name).Result;
                var newHashPassword = userManager.PasswordHasher.HashPassword(user, changePassword.Password);
                user.PasswordHash = newHashPassword;
                userManager.UpdateAsync(user).Wait();
                return RedirectToAction(nameof(Users));
            }
            return View("ChangePassword", changePassword);

        }
        public IActionResult Delete(string name)
        {
            var user = userManager.FindByNameAsync(name).Result;
            userManager.DeleteAsync(user).Wait();
            return RedirectToAction(nameof(Users));
        }
    }
}
