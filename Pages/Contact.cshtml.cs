using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPage2.Pages
{
    public class ContactModel : PageModel
    {
        [BindProperty]
        public CustomerInfo CustomerInfo { get; set; }
        public void OnGet()
        {
        }
    }
}
