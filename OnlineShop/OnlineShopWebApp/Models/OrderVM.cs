using OnlineShop.Db.Models;
using System;
using System.Collections.Generic;

namespace OnlineShopWebApp.Models
{
    public class OrderVM
    {
        public Guid Id { get; set; }
        public UserOrderVM UserOrder { get; set; }
        public List<CartItemVM> Items { get; set; }
        public OrderStatus Status { get; set; }
        public DateTime CreateDateTime { get; set; }
        public OrderVM()
        {
            Status = OrderStatus.Created;
            CreateDateTime = DateTime.Now;
        }
    }
}
