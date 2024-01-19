using OnlineShop.Db;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShopWebApp.Models
{
	public class CartVM
	{
		public Guid Id { get; set; }
		public string UserId { get; set; }
		public List<CartItemVM> Items { get; set; }
		public decimal Cost
		{
			get
			{
				return Items.Sum(x => x.Cost);
			}
		}
        public int Amount
        {
            get
            {
                return Items.Sum(x => x.Amount);
            }
        }
        public CartVM()
		{
			Id = Guid.NewGuid();
			UserId = Constans.UserId;
		}

	}
}
