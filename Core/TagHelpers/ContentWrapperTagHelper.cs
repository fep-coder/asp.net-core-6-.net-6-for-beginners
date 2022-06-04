using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Core.TagHelpers
{
        [HtmlTargetElement("*", Attributes = "[wrap=true]")]
        public class ContentWrapperTagHelper : TagHelper
        {
                public string WrapperString { get; set; }

                public override void Process(TagHelperContext context, TagHelperOutput output)
                {
                        TagBuilder elem = new TagBuilder("div");
                        elem.Attributes["class"] = "bg-primary text-white p-2 m-2";
                        elem.InnerHtml.AppendHtml(WrapperString);

                        output.PreElement.AppendHtml(elem);
                        output.PostElement.AppendHtml(elem);
                }
        }
}
