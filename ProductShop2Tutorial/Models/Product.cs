using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProductShop2Tutorial.Models {
    public class Product {
        public int ProductID { get; set; }

        [Required(ErrorMessage = "Please enter a product name.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter a product price.")]
        [Column(TypeName = "decimal(18, 2)")]   //18 length and 2 precision
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Please select a category.")]
        public int CategoryID { get; set; }
        public Category Category { get; set; }

        public decimal DiscountPercent => 0.20M;
        public decimal DiscountAmount => Price * DiscountPercent;
        public decimal DiscountedPrice => Price - DiscountAmount;

        [Required(ErrorMessage = "Please enter a product code.")]
        public string Code { get; set; }

        public string Slug => Name == null ? "" : Name.Replace(' ', '-');
    }
}
