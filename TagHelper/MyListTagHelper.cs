using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace CustomTagHelper
{
    [HtmlTargetElement("mylist")] // 4.1 Naming mylist
    public class MyListTagHelper : TagHelper
    {
        // 4.2 Create property for list-title, list-items
        public string ListTitle { get; set; }
        public List<string> ListItems { get; set; }

        // 4.3 Override Process
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "ul";
            output.TagMode = TagMode.StartTagAndEndTag;

            output.Attributes.SetAttribute("class", "list-group");
            output.PreElement.AppendHtml($"<h2>{ListTitle}</h2>");

            StringBuilder content = new StringBuilder();
            foreach (var item in ListItems)
            {
                content.Append($@"<li class=""list-group-item"">{item}</li>");
            }
            output.Content.SetHtmlContent(content.ToString());
        }
    }
}