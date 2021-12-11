// 1. Pages/Shared/Components/{Component Name Folder}/{Component File}
// 2. Must have Invoke or InvokeAsync Method
// 3. - Must have [ViewComponent] attribute OR
//    - Naming class ProductBoxViewComponent OR
//    - Extended ViewComponent

using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ProductModel;

namespace ProductComponent
{
    // [ViewComponent]
    // public class ProductBoxViewComponent
    public class ProductBox : ViewComponent
    {
        // 1. return string
        // public string Invoke() {
        //     return "Content of ProductBox";
        // }

        // 2. OR return IViewComponentResult
        public IViewComponentResult Invoke(bool isAscending = true)
        {
            // return View(); // By default, read content in Default.cshtml
            // return View("Default1");
            // 2.1 return View<string>("Hello world!");

            // 2.2 View<Model>(values)
            var products = new List<Product>() {
                new Product() { Name = "Product 1", Description = "Description 1", Price = 1000 },
                new Product() { Name = "Product 2", Description = "Description 2", Price = 1200 },
                new Product() { Name = "Product 3", Description = "Description 3", Price = 200 },
                new Product() { Name = "Product 4", Description = "Description 4", Price = 500 }
            };

            List<Product> _products = null;
            if (isAscending)
            {
                _products = products.OrderBy(product => product.Price).ToList();
            }
            else
            {
                _products = products.OrderByDescending(product => product.Price).ToList();
            }

            return View<List<Product>>(_products);
        }
    }
}