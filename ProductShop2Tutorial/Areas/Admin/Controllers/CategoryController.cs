using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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
    }
}
