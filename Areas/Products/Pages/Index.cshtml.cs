using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProductModel;
using Services;

namespace Products
{
    public class IndexModel : PageModel
    {
        [DisplayName("User Name")]
        public string UserName { get; set; } = "Tuong Huynh";
        public ProductListService _productListService { get; set; }
        public List<Product> Products { get; set; }
        public IndexModel(ProductListService productListService)
        {
            _productListService = productListService;
        }
        public void OnGet()
        {
            Products = _productListService.AllProducts();
        }

        // /products?handler=lastproduct
        public IActionResult OnGetLastProduct()
        {
            var product = _productListService.AllProducts().LastOrDefault();

            if (product == null) return this.Content("Product Not Found");

            return RedirectToPage("ViewProduct", new { id = product.Id });
        }

        // /products?handler=load
        public IActionResult OnGetLoad()
        {
            _productListService.LoadProducts();
            return RedirectToPage("Index");
        }

        // /products?handler=removeall
        public IActionResult OnGetRemoveAll()
        {
            _productListService.AllProducts().Clear();
            return RedirectToPage("Index");
        }
    }
}