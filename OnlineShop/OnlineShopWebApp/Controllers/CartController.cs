using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShop.Db.Repository;
using OnlineShopWebApp.Helpers;
using System;

namespace OnlineShopWebApp.Controllers
{
	[Authorize]
	public class CartController : Controller
	{
		private readonly ICartsRepository cartsRepository;
        private readonly IProductsRepository productsRepository;
        public CartController(ICartsRepository cartsRepository, IProductsRepository productsRepository)
		{
			this.cartsRepository = cartsRepository;
			this.productsRepository = productsRepository;
		}

		public IActionResult Index()
		{
			var cart = cartsRepository.TryGetByUserId(Constans.UserId) ;
			return View(Helper.MappingCart(cart));
		}
		public IActionResult Add(Guid Id)
		{
            var product = productsRepository.GetProduct(Id);
            cartsRepository.Add(product, Constans.UserId);
			return RedirectToAction("Index");
		}
		public IActionResult Delete(Guid Id)
		{
            var product = productsRepository.GetProduct(Id);
            cartsRepository.Delete(product, Constans.UserId);
            return RedirectToAction("Index");
        }
		public IActionResult Clear()
		{
			cartsRepository.Clear(Constans.UserId);
            return RedirectToAction("Index");
        }
    }
}
