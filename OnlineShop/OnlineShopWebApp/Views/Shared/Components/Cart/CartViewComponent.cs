using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShop.Db.Repository;
using OnlineShopWebApp.Helpers;

namespace OnlineShopWebApp.Views.Shared.Components.Cart
{
    public class CartViewComponent : ViewComponent
    {
        ICartsRepository cartsRepository;

        public CartViewComponent(ICartsRepository cartsRepository)
        {
            this.cartsRepository = cartsRepository;
        }

        public IViewComponentResult Invoke()
        {
            var cartDb = cartsRepository.TryGetByUserId(Constans.UserId);
            var cart = Helper.MappingCart(cartDb);
            var productCounts = cart?.Amount;
            return View("Cart" , productCounts);
        }
    }
}
