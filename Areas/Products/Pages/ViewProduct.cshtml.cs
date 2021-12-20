using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using ProductModel;
using Services;

public class ViewProductModel : PageModel
{
    private readonly ILogger<ViewProductModel> _logger;
    public readonly ProductListService _productListService;
    public int ProductId { get; set; }
    public Product Product { get; set; }
    public ViewProductModel(ILogger<ViewProductModel> logger, ProductListService productListService)
    {
        _logger = logger;
        _productListService = productListService;
    }

    public void OnGet(int? id, [Bind("Id", "Name")] Product product)
    {
        // 1. Read data directly by this.Request
        // 1.1 Request.RouteValues["id"]
        // if (Request.RouteValues["id"] != null)
        // {
        //     int id = int.Parse(Request.RouteValues["id"].ToString());
        //     ProductId = id;
        //     ViewData["Title"] = $"Product {id}";
        // }
        // else
        // {
        //     ViewData["Title"] = $"Product List";
        // }

        // 1.2
        // var form = this.Request.Form["id"];
        // var queryId = this.Request.Query["id"];
        // var data = this.Request.RouteValues["id"];
        // var header = this.Request.Headers["user-agent"];
        // if (data != null)
        // {
        //     System.Console.WriteLine(queryId);
        //     System.Console.WriteLine(header);
        //     ProductId = int.Parse(data.ToString());
        //     ViewData["Title"] = $"Product {ProductId}";
        //     Product = _productListService.Find(ProductId);
        // }

        // 2. Model Binding by Attributes:
        // [FromQuery] => OnGet([FromQuery] int? id) => /products/343223?id=4
        //             => OnGet([FromQuery(Name = "productId")] int? id) => /products/343223?productId=4
        // [FromRoute] => OnGet([FromRoute] int? id)
        // [FromForm]
        // [FromHeader]
        // [FromBody]
        // 2.1 Parameter Binding: 
        // 2.1.1 OnGet(int? id)
        if (id != null)
        {
            ProductId = id.Value;
            ViewData["Title"] = $"Product {ProductId}";
            Product = _productListService.Find(ProductId);
        }
        else
        {
            ViewData["Title"] = $"Product List";
        }

        // 2.1.2 OnGet(int? id, Product product)
        // /products/3?Id=2&Name=Iphone&Price=100 => Id = 3, Name = Iphone, Price = 100
        System.Console.WriteLine($"ID: {product.Id}");
        System.Console.WriteLine($"Name: {product.Name}");
        System.Console.WriteLine($"Price: {product.Price}");

        // 2.1.3 OnGet(int? id, [Bind("Id", "Name")] Product product) => Only bind Id, Name
        // /products/3?Id=2&Name=Iphone&Price=100 => Id = 3, Name = Iphone, Price = 0

        // 2.2 Property Binding
        // Code in Privacy.cshtml.cs

    }

    // /products/{item.Id}?handler=delete
    public IActionResult OnPostDelete(int? id)
    {
        if (id != null)
        {
            var product = _productListService.Find(id.Value);
            if (product != null)
            {
                _productListService.AllProducts().Remove(product);
            }
        }

        return RedirectToPage("Index");
    }
}