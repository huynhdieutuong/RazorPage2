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
        [BindProperty]
        public UserContact UserContact { get; set; }
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
            System.Console.WriteLine(UserContact.UserId);
            System.Console.WriteLine(UserContact.Email);
            System.Console.WriteLine(UserContact.UserName);
        }
    }
}
