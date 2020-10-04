using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductShop2Tutorial.Models {
    public class DataBase {
        public static List<Product> GetProducts() {
            List<Product> products = new List<Product> {
                new Product {
                    ProductID = 1,
                    Name = "Product 1",
                    Price = (decimal) 199.00
                },
                new Product {
                    ProductID = 2,
                    Name = "Product 2",
                    Price = (decimal) 299.00
                },
                new Product {
                    ProductID = 3,
                    Name = "Product Of the Month",
                    Price = (decimal) 399.00
                },
                new Product {
                    ProductID = 4,
                    Name = "Product 4",
                    Price = (decimal) 499.00
                },
                new Product {
                    ProductID = 5,
                    Name = "Product 5",
                    Price = (decimal) 599.00
                }
            };

            return products;
        }

        public static Product GetProduct(string slug) {
            List<Product> products = GetProducts();

            foreach (Product li in products) {
                if (li.Slug == slug) {
                    return li;
                }
            }

            return null;
        }
    }
}
