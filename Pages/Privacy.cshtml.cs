using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace RazorPage2.Pages
{
    public class PrivacyModel : PageModel
    {
        // [BindProperty] - Default binding in POST
        // [BindProperty(SupportsGet = true)] - Support binding in GET
        // /privacy.html?UserId=abc&Email=tuong@gmail.com&UserName=Tuong
        [BindProperty]
        [DisplayName("Your Id")]
        public string UserId { get; set; }
        [BindProperty]
        public string Email { get; set; }
        [BindProperty]
        public string UserName { get; set; }
        private readonly ILogger<PrivacyModel> _logger;

        public PrivacyModel(ILogger<PrivacyModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
        public void OnPost()
        {
            System.Console.WriteLine(UserId);
            System.Console.WriteLine(Email);
            System.Console.WriteLine(UserName);
        }
    }
}
