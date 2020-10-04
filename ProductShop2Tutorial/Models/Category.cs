using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProductShop2Tutorial.Models {
    public class Category {
        public int CategoryID { get; set; }
        
        [Required(ErrorMessage = "Please enter a category name.")]
        public string Name { get; set; }
    }
}
