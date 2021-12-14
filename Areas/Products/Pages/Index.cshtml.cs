using System.Collections.Generic;
using System.ComponentModel;
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
    }
}