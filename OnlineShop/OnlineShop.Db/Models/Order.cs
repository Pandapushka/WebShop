using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShop.Db.Models
{
    public class Order
    {
        public Guid Id { get; set; }
        public UserOrder UserOrder { get; set; }
        public List<CartItem> Items { get; set; }
        public OrderStatus Status { get; set; }
        public DateTime CreateDateTime { get; set; }
        public Order()
        {
            Items = new List<CartItem>();
            Status = OrderStatus.Created;
            CreateDateTime = DateTime.Now;
        }

    }
}
