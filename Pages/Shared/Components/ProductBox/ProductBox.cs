// 1. Pages/Shared/Components/{Component Name Folder}/{Component File}
// 2. Must have Invoke or InvokeAsync Method
// 3. - Must have [ViewComponent] attribute OR
//    - Naming class ProductBoxViewComponent OR
//    - Extended ViewComponent

using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ProductModel;
using Services;

namespace ProductComponent
{
    // [ViewComponent]
    // public class ProductBoxViewComponent
    public class ProductBox : ViewComponent
    {
        ProductListService productListService;
        public ProductBox(ProductListService _productListService) // 2.3 Inject ProductListService into ProductBox Component
        {
            productListService = _productListService;
        }

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
            List<Product> _products = null;
            if (isAscending)
            {
                _products = productListService.products.OrderBy(product => product.Price).ToList();
            }
            else
            {
                _products = productListService.products.OrderByDescending(product => product.Price).ToList();
            }

            return View<List<Product>>(_products);
        }
    }
}