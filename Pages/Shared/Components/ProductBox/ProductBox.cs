// 1. Pages/Shared/Components/{Component Name Folder}/{Component File}
// 2. Must have Invoke or InvokeAsync Method
// 3. - Must have [ViewComponent] attribute OR
//    - Naming class ProductBoxViewComponent OR
//    - Extended ViewComponent

using Microsoft.AspNetCore.Mvc;

namespace ProductComponent
{
    // [ViewComponent]
    // public class ProductBoxViewComponent
    public class ProductBox : ViewComponent
    {
        // 1. return string
        // public string Invoke() {
        //     return "Content of ProductBox";
        // }

        // 2. OR return IViewComponentResult
        public IViewComponentResult Invoke()
        {
            // return View(); // By default, read content in Default.cshtml
            return View("Default1");
        }
    }
}