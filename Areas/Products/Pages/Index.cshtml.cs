using System.ComponentModel;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Products
{
    public class IndexModel : PageModel
    {
        [DisplayName("User Name")]
        public string UserName { get; set; } = "Tuong Huynh";
    }
}