using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShop.Db.Models;
using OnlineShop.Db.Repository;
using OnlineShopWebApp.Areas.Admin.Models;
using OnlineShopWebApp.Helpers;
using System;

namespace OnlineShopWebApp.Areas.Admin.Controllers
{
    [Area(Constans.AdminRoleName)]
    [Authorize(Roles = Constans.AdminRoleName)]
    public class ProductController : Controller
    {
        private readonly IProductsRepository productsRepository;
        private readonly ImagesProvider imagesProvider;

        public ProductController(IProductsRepository productsRepository, ImagesProvider imagesProvider)
        {
            this.productsRepository = productsRepository;
            this.imagesProvider = imagesProvider;
        }

        public IActionResult Products()
        {
            var products = productsRepository.Get();
            return View(products);
        }
        public IActionResult Delete(Guid id)
        {
            productsRepository.Delete(id);
            return RedirectToAction("Products");
        }

        public IActionResult Edit(Guid id)
        {
            var product = productsRepository.GetProduct(id);
            var productEdit = Helper.ProductEditMapping(product);
            return View(productEdit);
        }

        [HttpPost]
        public IActionResult Edit(EditProductViewModel product)
        {
            if (product.UploadedFiles != null && !ModelState.IsValid)
            {
                return View(product);
            }
            if (product.UploadedFiles != null)
            {
                var addedImagesPaths = imagesProvider.SafeFiles(product.UploadedFiles, ImageFolders.Products);
                product.ImagesPaths = addedImagesPaths;
            }
            productsRepository.Edit(product.ToProduct(), product.UploadedFiles);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(AddProductViewModel product)
        {
            if (productsRepository.TryGetByName(product.Name) != null)
            {
                ModelState.AddModelError("", "Продукт с таким именем уже сущствует");
            }
            if (!ModelState.IsValid)
            {
                return View(product);
            }

            var imagesPaths = imagesProvider.SafeFiles(product.UploadedFiles, ImageFolders.Products);
            productsRepository.Add(product.ToProduct(imagesPaths));
            return RedirectToAction("Products");
        }
    }
}
