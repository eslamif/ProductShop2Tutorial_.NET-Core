using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductShop2Tutorial.Models {
    public class ProductListViewModel {
        public List<Category> Categories { get; set; }
        public List<Product> Products { get; set; }
        public string SelectedCategoryName { get; set; }

        public string CheckActiveCategory(string categoryName) => categoryName == SelectedCategoryName ? "active" : "";
    }
}
