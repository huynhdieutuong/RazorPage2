using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace RazorPage2.Pages
{
    public class IndexModel : PageModel
    {
        public string Abc { get; set; }
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public IActionResult OnGet()
        {
            // System.Console.WriteLine("On Get Run First");
            // this.Abc = "Run On Get";

            // Can use Partial or Component direct on PageModel
            // PageModel: Partial, ViewComponent
            // return Partial("_Message");
            return ViewComponent("ProductBox", false);

            // Controller: PartialView, ViewComponent => Learn later
        }
    }
}
