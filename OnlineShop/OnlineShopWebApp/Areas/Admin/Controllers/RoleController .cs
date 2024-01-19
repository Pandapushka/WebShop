using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShopWebApp.Areas.Admin.Models;
using OnlineShopWebApp.Repository;
using System.Data;

namespace OnlineShopWebApp.Areas.Admin.Controllers
{
    [Area(Constans.AdminRoleName)]
    [Authorize(Roles = Constans.AdminRoleName)]
    public class RoleController : Controller
    {
        private readonly IRolesRepository rolesRepository;

        public RoleController(IRolesRepository rolesRepository)
        {
            this.rolesRepository = rolesRepository;
        }

        public IActionResult Roles()
        {
            var roles = rolesRepository.GetAll();
            return View(roles);
        }
        public IActionResult Remove(int roleId)
        {
            rolesRepository.Remove(roleId);
            return RedirectToAction("Roles");
        }
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Role role)
        {
            if (rolesRepository.TryGetByName(role.Name) != null)
            {
                ModelState.AddModelError("", "Такая роль уже существует!");
            }
            if (ModelState.IsValid)
            {
                rolesRepository.Add(role);
                return RedirectToAction("Roles");
            }
            return View(role);
        }
    }
}
