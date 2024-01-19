using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db.Models;
using OnlineShop.Db.Repository;
using OnlineShopWebApp.Helpers;
using System;
using System.Linq;

namespace OnlineShopWebApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductsRepository productsRepository;
        public ProductController(IProductsRepository productsRepository)
        {
            this.productsRepository = productsRepository;
        }

        public IActionResult Index(Guid id)
        {
            var products = productsRepository.Get();
            Product product = products.FirstOrDefault(x => x.Id == id);
            var productVM = Helper.ToProductViewModel(product);
            return View(productVM);
        }       
    }
}
