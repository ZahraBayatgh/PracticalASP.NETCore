using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Microdev.ASPNETCore.TagHelpers
{
    [HtmlTargetElement("button", Attributes = "microdev-custom-button")]
    public class CustomBottonTagHelper : TagHelper
    {

        [HtmlAttributeName("microdev-custom-button")]
        public string BottonName { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {

            output.Attributes.SetAttribute("type", "submit");
            output.Attributes.SetAttribute("value", $"Microdev{BottonName}");
            output.Attributes.SetAttribute("name", $"Microdev{BottonName}");
        }

    }
}
