using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProductShop2Tutorial.Models;

namespace ProductShop2Tutorial.Areas.Admin.Controllers {
    [Area("Admin")]
    public class CategoryController : Controller {
        private ShopContext shopContext;

        public CategoryController(ShopContext shopContext) {
            this.shopContext = shopContext;
        }

        public IActionResult Index() {
            return RedirectToAction("List", "Category");
        }

        [Route("[area]/Categories/{id?}")]
        public IActionResult List() {
            List<Category> categories = shopContext.Categories.OrderBy(c => c.Name).ToList();
            return View(categories);
        }

        [HttpGet]
        public IActionResult Add() {
            ViewBag.Action = "Add";
            return View("AddUpdate", new Category());
        }

        [HttpGet]
        public IActionResult Update(int id) {
            ViewBag.Action = "Update";
            Category category = shopContext.Categories.Find(id);
            return View("AddUpdate", category);
        }

        [HttpPost]
        public IActionResult Update(Category category) {
            if (ModelState.IsValid) {
                if (category.CategoryID == 0) {
                    shopContext.Categories.Add(category);
                }
                else {
                    shopContext.Categories.Update(category);
                }

                shopContext.SaveChanges();
                return RedirectToAction("List", "Category");
            }
            else {
                ViewBag.Action = "Save";
                return View("AddUpdate");
            }
        }

        [HttpGet]
        public IActionResult Delete(int id) {
            Category category = shopContext.Categories.Find(id);
            return View(category);
        }

        [HttpPost]
        public IActionResult Delete(Category category) {
            shopContext.Remove(category);
            shopContext.SaveChanges();
            return RedirectToAction("List", "Category");
        }
    }
}
