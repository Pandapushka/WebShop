using Microsoft.AspNetCore.Http;
using OnlineShop.Db.Models;
using System;
using System.Collections.Generic;

namespace OnlineShop.Db.Repository
{
    public interface IProductsRepository
    {
        List<Product> Get();
        Product GetProduct(Guid id);
        void Delete(Guid id);
        public void Edit(Product product, IFormFile[] uploadedFiles);
        public void Add(Product product);
        public Product TryGetByName(string name);
    }
}
