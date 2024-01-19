using Microsoft.EntityFrameworkCore;
using OnlineShop.Db.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShop.Db.Repository
{
    public class InDbOrderRepository : IOrdersRepository
	{
        private readonly DatabaseContext dbContext;
		public InDbOrderRepository(DatabaseContext dbContext)
		{
			this.dbContext = dbContext;
		}
        public void Add(Order order)
		{
            dbContext.Orders.Add(order);
            dbContext.SaveChanges();
        }

		public List<Order> GetAll()
		{
            return dbContext.Orders.Include(x=>x.UserOrder).Include(x=> x.Items).ToList();
		}
		public Order TryGetById(Guid orderId)
		{
			return dbContext.Orders.Include(x => x.UserOrder).Include(x => x.Items).FirstOrDefault(x => x.Id == orderId);
		}

		public void UpdateStatus(Guid orderId, OrderStatus orderStatus)
		{
			var order = TryGetById(orderId);
			if (dbContext.Orders != null)
			{
                order.Status = orderStatus;
                dbContext.SaveChanges();
            }
		}
	}
}
