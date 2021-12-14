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

    public void OnGet(int? id)
    {
        // 1. Request.RouteValues["id"]
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

        // 2. OnGet(int? id)
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
    }
}