using Microsoft.EntityFrameworkCore;
using OnlineShop.Db.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShop.Db.Repository
{
    public class InDbCartsRepository : ICartsRepository
    {
        private readonly DatabaseContext dbContext;

        public InDbCartsRepository(DatabaseContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Cart TryGetByUserId(string userId)
        {
            return dbContext.Carts.Include(x=>x.Items).ThenInclude(el => el.Product).FirstOrDefault(cart => cart.UserId == userId);
        }

        public void Add(Product product, string userId)
        {
            var existingCart = TryGetByUserId(userId);
            var newCartItem = new CartItem
            {
                Amount = 1,
                Product = product
            };
            if (existingCart == null)
            {
                var newCart = new Cart()
                {
                    UserId = userId,
                    Items = new List<CartItem>
                    {
                        newCartItem
                    }
                };
                dbContext.Carts.Add(newCart);                
            }
            else
            {
                var existingCartItem = existingCart.Items.FirstOrDefault(cart => cart.Product.Id == product.Id);
                if (existingCartItem != null)
                {
                    existingCartItem.Amount++;
                }
                else
                {
                    existingCart.Items.Add(newCartItem);
                }
            }
            dbContext.SaveChanges();
        }
        public void Delete(Product product, string userId)
        {
            var existingCart = TryGetByUserId(userId);
            var existingCartItem = existingCart.Items.FirstOrDefault(cart => cart.Product.Id == product.Id);
            existingCartItem.Amount--;
            if (existingCartItem.Amount == 0)
            {
                existingCart.Items.Remove(existingCartItem);
            }
            if (existingCart.Items.Count == 0)
            {
                dbContext.Carts.Remove(existingCart);
                dbContext.CartItems.Remove(existingCartItem);
            }  
            dbContext.SaveChanges();
        }
        public void Clear(string userId)
        {
            var сart = TryGetByUserId(userId);
            if (сart != null)
            {
                dbContext.Carts.Remove(сart);
                dbContext.SaveChanges();
            }   
        }
    }
}
