using System.Collections.Generic;
using ProductModel;

namespace Services
{
    public class ProductListService
    {
        // 2.1 Create ProductListService have products Property
        public List<Product> products { get; set; } = new List<Product>() {
            new Product() { Name = "Product 1", Description = "Description 1", Price = 1000 },
            new Product() { Name = "Product 2", Description = "Description 2", Price = 1200 },
            new Product() { Name = "Product 3", Description = "Description 3", Price = 200 },
            new Product() { Name = "Product 4", Description = "Description 4", Price = 500 }
        };
    }
}