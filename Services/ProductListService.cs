using System.Collections.Generic;
using System.Linq;
using ProductModel;

namespace Services
{
    public class ProductListService
    {
        // 2.1 Create ProductListService have products Property
        public List<Product> products { get; set; } = new List<Product>() { };

        public ProductListService()
        {
            LoadProducts();
        }

        public Product Find(int id)
        {
            var qr = from p in products where p.Id == id select p;
            return qr.FirstOrDefault();
        }

        public List<Product> AllProducts() => products;

        public void LoadProducts()
        {
            products.Clear();

            products.Add(new Product() { Id = 1, Name = "Product 1", Description = "Description 1", Price = 1000 });
            products.Add(new Product() { Id = 2, Name = "Product 2", Description = "Description 2", Price = 1200 });
            products.Add(new Product() { Id = 3, Name = "Product 3", Description = "Description 3", Price = 200 });
            products.Add(new Product() { Id = 4, Name = "Product 4", Description = "Description 4", Price = 500 });
        }
    }
}