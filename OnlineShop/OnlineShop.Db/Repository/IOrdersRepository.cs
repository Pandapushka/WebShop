using OnlineShop.Db.Models;
using System;
using System.Collections.Generic;

namespace OnlineShop.Db.Repository
{
    public interface IOrdersRepository
	{
		void Add(Order order);
        List<Order> GetAll();
        Order TryGetById(Guid orderId);
        void UpdateStatus(Guid orderId, OrderStatus orderStatus);
    }
}