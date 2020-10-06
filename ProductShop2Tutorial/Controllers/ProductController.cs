using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProductShop2Tutorial.Models;

namespace ProductShop2Tutorial.Controllers {
    public class ProductController : Controller {
        private ShopContext shopContext;

        public ProductController(ShopContext shopContext) {
            this.shopContext = shopContext;
        }

        public IActionResult Index() {
            return RedirectToAction("List", "Product");     //Products is plural because the List action appends an s
        }

        public IActionResult Detail(int id) {
            var categories = shopContext.Categories.OrderBy(c => c.CategoryID).ToList();
            Product product = shopContext.Products.Find(id);
            string imageFileName = product.Code + "-m.jpg";

            //Get product's category
            string categoryName = "";
            foreach (var category in categories) {
                if (category.CategoryID == product.CategoryID) {
                    categoryName = category.Name;
                    break;
                }
            }

            ViewBag.CategoryName = categoryName;
            ViewBag.ImageFileName = imageFileName;

            return View(product);
        }

        [Route("[controller]s/{categoryName?}")]
        public IActionResult List(string categoryName = null) {
            var categories = shopContext.Categories.OrderBy(c => c.CategoryID).ToList();
            List<Product> products;

            if (categoryName == null) {
                products = shopContext.Products.OrderBy(p => p.Name).ToList();
            }
            else {
                products = shopContext.Products.Where(p => p.Name == categoryName).OrderBy(p => p.Name).ToList();
            }

            ViewBag.SelectedCategoryName = categoryName;
            ViewBag.Categories = categories;

            return View(products);
        }
    }
}
