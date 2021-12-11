using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MessageComponent;
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

        public IActionResult OnPost()
        {
            var userName = this.Request.Form["username"];

            var message = new MessagePage.Message();
            message.Title = "New alert";
            message.HtmlContent = $"<strong>Thanks {userName} for your submit</strong>";
            message.SecondWait = 3;
            message.UrlRedirect = Url.Page("Privacy");
            return ViewComponent("MessagePage", message); // 3.4 use MessagePage Component
        }

        // public IActionResult OnGet()
        // {
        //     // System.Console.WriteLine("On Get Run First");
        //     // this.Abc = "Run On Get";

        //     // Can use Partial or Component direct on PageModel
        //     // PageModel: Partial, ViewComponent
        //     // return Partial("_Message");
        //     return ViewComponent("ProductBox", false);

        //     // Controller: PartialView, ViewComponent => Learn later
        // }
    }
}
