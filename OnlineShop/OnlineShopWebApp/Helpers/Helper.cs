using OnlineShop.Db.Models;
using OnlineShopWebApp.Areas.Admin.Models;
using OnlineShopWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShopWebApp.Helpers
{
    public static class Helper
    {
        public static List<OrderVM> ToOrderVMList(List<Order> orders)
        {
            var ordersVMlist = new List<OrderVM>();
            foreach (var order in orders)
            {
                var orderVM = ToOrderVM(order);
                ordersVMlist.Add(orderVM);
            }
            return ordersVMlist;
        }
        public static OrderVM ToOrderVM(Order order)
        {
            return new OrderVM
            {
                Id = order.Id,
                CreateDateTime = order.CreateDateTime,
                Status = order.Status,
                UserOrder = ToUserOrderVM(order.UserOrder),
                Items = ToCartItemViewModel(order.Items)
            };
        }
        public static UserOrderVM ToUserOrderVM(UserOrder userOrder)
        {
            return new UserOrderVM
            {
                Name = userOrder.Name,
                Address = userOrder.Address,
                Phone = userOrder.Phone,
                Email = userOrder.Email
            };
        }
        public static Order FormOrder(UserOrderVM userOrder, Cart cart)
        {
            var order = new Order();
            order.UserOrder = new UserOrder();
            order.UserOrder.Name = userOrder.Name;
            order.UserOrder.Address = userOrder.Address;
            order.UserOrder.Phone = userOrder.Phone;
            order.UserOrder.Email = userOrder.Email;
            order.Items.AddRange(cart.Items);
            return order;
        }

        public static UserAccount FormRegister(UserRegistration user)
        {
            return new UserAccount()
            {
                Login = user.Login,
                Pasword = user.Password,
                Phone = user.Phone
            };
        }

        public static CartVM MappingCart(Cart cart)
        {
            if(cart == null)
                return null;
            var cartVM = new CartVM()
            {
                Id = cart.Id,
                UserId = cart.UserId,
                Items = ToCartItemViewModel(cart.Items)
            };
            return cartVM;
        }
        public static List<CartItemVM> ToCartItemViewModel(List<CartItem> cartDbItems)
        {
            var cartItems = new List<CartItemVM>();
            foreach (var cartDbItem in cartDbItems)
            {
                var cartItem = new CartItemVM()
                {
                    Id = cartDbItem.Id,
                    Amount = cartDbItem.Amount,
                    Product = cartDbItem.Product,
                };
                cartItems.Add(cartItem);
            }
            return cartItems;
        }

        public static Product ProductMapping(ProductEdit newProduct)
        {
            Product product = new Product();
            product.Name = newProduct.Name;
            product.Id = Guid.NewGuid();
            product.Cost = newProduct.Cost;
            product.Description = newProduct.Description;
            //product.Image = "image/prod2.jpg";
            return product;
        }
        public static ProductEdit ProductEditMapping(Product product)
        {
            var productEdit = new ProductEdit();
            productEdit.Id = product.Id;
            productEdit.Name = product.Name;
            productEdit.Cost = product.Cost;
            productEdit.Description = product.Description;
            return productEdit;
        }
        public static UserVM ToUserVM(this User user)
        {
            return new UserVM
            {
                UserName = user.UserName,
                Phone = user.PhoneNumber
            };
        }
        public static Product ToProduct(this AddProductViewModel product, List<string> imagesPaths)
        {
            return new Product
            {
                Name = product.Name,
                Cost = product.Cost,
                Description = product.Description,
                Images = ToImages(imagesPaths)
            };
        }

        public static Product ToProduct(this EditProductViewModel product)
        {
            return new Product
            {
                Id = product.Id,
                Name = product.Name,
                Cost = product.Cost,
                Description = product.Description,
                Images = product.ImagesPaths.ToImages()
            };
        }

        public static EditProductViewModel ToEditProductViewModel(this Product product)
        {
            return new EditProductViewModel
            {
                Id = product.Id,
                Name = product.Name,
                Cost = product.Cost,
                Description = product.Description,
                ImagesPaths = product.Images.ToPaths()
            };
        }

        public static ProductViewModel ToProductViewModel(this Product product)
        {
            return new ProductViewModel
            {
                Id = product.Id,
                Name = product.Name,
                Cost = product.Cost,
                Description = product.Description,
                ImagesPath = product.Images.Select(x => x.Url).ToArray()
            };
        }
        public static List<ProductViewModel> ToProductViewModels(this List<Product> products)
        {
            var productsViewModels = new List<ProductViewModel>();
            foreach (var product in products)
            {
                productsViewModels.Add(ToProductViewModel(product));
            }
            return productsViewModels;
        }

        public static List<Image> ToImages(this List<string> paths)
        {
            return paths.Select(x => new Image { Url = x }).ToList();
        }

        public static List<string> ToPaths(this List<Image> paths)
        {
            return paths.Select(x => x.Url).ToList();
        }
    }
}
