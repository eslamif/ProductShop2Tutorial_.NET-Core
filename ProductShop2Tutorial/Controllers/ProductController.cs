using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProductShop2Tutorial.Models;

namespace ProductShop2Tutorial.Controllers {
    public class ProductController : Controller {
        public IActionResult Detail(string slug) {
            return View();
        }

        public IActionResult List() {
            return View();
        }
    }
}
