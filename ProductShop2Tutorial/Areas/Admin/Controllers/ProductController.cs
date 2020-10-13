using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using ProductShop2Tutorial.Models;

namespace ProductShop2Tutorial.Areas.Admin.Controllers {

    [Area("Admin")]
    public class ProductController : Controller {
        private ShopContext shopContext;
        private List<Category> categories;

        public ProductController(ShopContext shopContext) {
            this.shopContext = shopContext;
            categories = shopContext.Categories.OrderBy(c => c.Name).ToList();
        }

        public IActionResult Index() {
            return RedirectToAction("List", "Product");
        }

        [Route("[area]/[controller]s/{id?}")]
        public IActionResult List(string id = "All") {
            List<Product> products;
            if (id == "All") {
                products = shopContext.Products.OrderBy(p => p.Name).ToList();
            }
            else {
                products = shopContext.Products.Where(p => p.Category.Name == id).OrderBy(p => p.Name).ToList();
            }

            var model = new ProductListViewModel {
                Categories = categories,
                Products = products,
                SelectedCategoryName = id
            };

            return View(model);
        }

        [HttpGet]
        public IActionResult Add() {
            Product product = new Product();
            product.Category = shopContext.Categories.First();  //must set default category for FK contraint
            
            ViewBag.Action = "Add";
            ViewBag.Categories = categories;

            return View("AddUpdate", product);
        }

        [HttpGet]
        public IActionResult Update(int id) {
            Product product = shopContext.Products.Include(p => p.Category).FirstOrDefault(p => p.ProductID == id);

            ViewBag.Action = "Update";
            ViewBag.Categories = categories;

            return View("AddUpdate", product);
        }

        [HttpPost]
        public IActionResult Update(Product product) {
            if (ModelState.IsValid) {
                string userMessage = "";

                if (product.ProductID == 0) {
                    shopContext.Products.Add(product);
                    userMessage = "You just added a new product: " + product.Name;
                }
                else {
                    shopContext.Products.Update(product);
                    userMessage = "You just updated a product: " + product.Name;
                }

                shopContext.SaveChanges();
                TempData["UserMessage"] = userMessage;
                return RedirectToAction("List", "Product");
            }
            else {
                ViewBag.Action = "Save";
                ViewBag.Categories = categories;
                return View("AddUpdate", product);
            }
        }

        [HttpGet]
        public IActionResult Delete(int id) {
            Product product = shopContext.Products.FirstOrDefault(p => p.ProductID == id);  //same as Find(id)
            return View(product);
        }

        [HttpPost]
        public IActionResult Delete(Product product) {
            shopContext.Products.Remove(product);
            shopContext.SaveChanges();

            return RedirectToAction("List", "Product");
        }
    }
}
