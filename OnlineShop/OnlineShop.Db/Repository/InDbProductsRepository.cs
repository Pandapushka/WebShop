
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Db.Models;
using System;
using System.Collections.Generic;
using System.Linq;


namespace OnlineShop.Db.Repository
{
    public class InDbProductsRepository : IProductsRepository
    {
        private readonly DatabaseContext databaseContext;
        public InDbProductsRepository(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }
        public List<Product> Get()
        {
            return databaseContext.Products.Include(x => x.Images).ToList();
        }

        public Product GetProduct(Guid id)
        {
            return databaseContext.Products.FirstOrDefault(product => product.Id == id);
        }
        public Product TryGetByName(string name)
        {
            return databaseContext.Products.FirstOrDefault(product => product.Name == name);
        }
        public void Delete(Guid id)
        {
            var product = GetProduct(id);
            databaseContext.Products.Remove(product);
            databaseContext.SaveChanges();
        } 
        public void Edit(Product product, IFormFile[] uploadedFiles)
        {
            var currentProduct = GetProduct(product.Id);
            currentProduct.Name = product.Name;
            currentProduct.Cost = product.Cost;
            currentProduct.Description = product.Description;

            if (uploadedFiles != null)
            {
                foreach (var image in currentProduct.Images)
                {
                    databaseContext.Images.Remove(image);
                }

                foreach (var image in product.Images)
                {
                    image.ProductId = product.Id;
                    databaseContext.Images.Add(image);
                }
            }

            databaseContext.SaveChanges();
        }
        public void Add(Product product)
        {
            databaseContext.Products.Add(product);
            databaseContext.SaveChanges();
        }
    }


}
