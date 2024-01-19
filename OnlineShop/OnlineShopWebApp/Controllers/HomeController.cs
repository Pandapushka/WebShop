using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db.Repository;
using OnlineShopWebApp.Helpers;

namespace OnlineShopWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductsRepository productsRepository;
        public HomeController(IProductsRepository productsRepository)
        {
            this.productsRepository = productsRepository;
        }

        public IActionResult Index()
        {
            var products = productsRepository.Get();
            var productsVM = Helper.ToProductViewModels(products);
            return View(productsVM);
        }

        public IActionResult Privacy()
        {
            return View();
        }

    }
}
