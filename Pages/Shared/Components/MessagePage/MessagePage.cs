// 3.1 Create MessagePage Component

using Microsoft.AspNetCore.Mvc;

namespace MessageComponent
{
    public class MessagePage : ViewComponent
    {
        public class Message // 3.2 Create Message Model
        {
            public string Title { get; set; } = "Message";
            public string HtmlContent { get; set; } = "";
            public string UrlRedirect { get; set; } = "/";
            public int SecondWait { get; set; } = 3;
        }

        public MessagePage() { }

        public IViewComponentResult Invoke(Message message)
        {
            this.HttpContext.Response.Headers.Add("REFRESH", $"{message.SecondWait};URL={message.UrlRedirect}");
            return View(message); // Transfer message Model to View Default.cshtml
        }
    }
}