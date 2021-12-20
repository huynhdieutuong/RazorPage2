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
        public string Message { get; set; }
        public void OnGet()
        {
        }

        public void OnPost()
        {
            if (ModelState.IsValid)
            {
                Message = "Data is valid";
            }
            else
            {
                Message = "Data is invalid";
            }
        }
    }
}
