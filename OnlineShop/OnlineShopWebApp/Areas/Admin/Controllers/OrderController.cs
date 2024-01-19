using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShop.Db.Models;
using OnlineShop.Db.Repository;
using OnlineShopWebApp.Helpers;
using OnlineShopWebApp.Models;
using OnlineShopWebApp.Repository;
using System;

namespace OnlineShopWebApp.Areas.Admin.Controllers
{
    [Area(Constans.AdminRoleName)]
    [Authorize(Roles = Constans.AdminRoleName)]
    public class OrderController : Controller
    {
        private readonly IOrdersRepository ordersRepository;

        public OrderController(IOrdersRepository ordersRepository)
        {
            this.ordersRepository = ordersRepository;
        }

        public IActionResult Orders()
        {
            var orders = Helper.ToOrderVMList(ordersRepository.GetAll());
            return View(orders);
        }
        public IActionResult OrderDetails(Guid orderId)
        {
            var order = ordersRepository.TryGetById(orderId);
            var orderVM = Helper.ToOrderVM(order);
            return View(orderVM);
        }
        public IActionResult UpdateOrderStatus(Guid orderId, OrderStatus orderStatus)
        {
            ordersRepository.UpdateStatus(orderId, orderStatus);
            return RedirectToAction("Orders");
        }
    }
}
