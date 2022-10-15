#pragma checksum "C:\Users\EliteBook 1040 G2 i2\source\repos\Blog\Blog\Views\Home\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "541486a24e8c715a188f0e1bb2ae2fd757ea8a55"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Details), @"mvc.1.0.view", @"/Views/Home/Details.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\EliteBook 1040 G2 i2\source\repos\Blog\Blog\Views\_ViewImports.cshtml"
using Blog;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\EliteBook 1040 G2 i2\source\repos\Blog\Blog\Views\_ViewImports.cshtml"
using Blog.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\EliteBook 1040 G2 i2\source\repos\Blog\Blog\Views\_ViewImports.cshtml"
using Blog.ViewModel;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"541486a24e8c715a188f0e1bb2ae2fd757ea8a55", @"/Views/Home/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e19f47701ab55c279f19ac5bcebc56192d65c122", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Post>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\EliteBook 1040 G2 i2\source\repos\Blog\Blog\Views\Home\Details.cshtml"
  
    ViewData["Title"] = "Post Detail";

    ViewBag.Title = Model.Title;     //This is for the Search Engines... what will be used by the user
    ViewBag.Description = Model.Description;
    ViewBag.Keywords = $"{Model.Tags?.Replace(","," ")}";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n<h4>Post</h4>\r\n<hr />\r\n<div class=\"container\">\r\n    <h5 class=\"display-4\">Post Detail</h5>\r\n\r\n");
            WriteLiteral("\r\n\r\n\r\n    <div class=\"container\">\r\n        <div class=\"post no-shadow\">\r\n");
#nullable restore
#line 53 "C:\Users\EliteBook 1040 G2 i2\source\repos\Blog\Blog\Views\Home\Details.cshtml"
             if (!String.IsNullOrEmpty(Model.Image))
            {
                var imagePath = $"/Image/{Model.Image}";

#line default
#line hidden
#nullable disable
            WriteLiteral("                <img");
            BeginWriteAttribute("src", " src=\"", 1930, "\"", 1946, 1);
#nullable restore
#line 56 "C:\Users\EliteBook 1040 G2 i2\source\repos\Blog\Blog\Views\Home\Details.cshtml"
WriteAttributeValue("", 1936, imagePath, 1936, 10, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("alt", " alt=\"", 1947, "\"", 1965, 1);
#nullable restore
#line 56 "C:\Users\EliteBook 1040 G2 i2\source\repos\Blog\Blog\Views\Home\Details.cshtml"
WriteAttributeValue("", 1953, Model.Title, 1953, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n                <span class=\"title\">");
#nullable restore
#line 57 "C:\Users\EliteBook 1040 G2 i2\source\repos\Blog\Blog\Views\Home\Details.cshtml"
                               Write(Model.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n");
#nullable restore
#line 58 "C:\Users\EliteBook 1040 G2 i2\source\repos\Blog\Blog\Views\Home\Details.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </div>\r\n        \r\n        <div class=\"post-body\">\r\n            ");
#nullable restore
#line 62 "C:\Users\EliteBook 1040 G2 i2\source\repos\Blog\Blog\Views\Home\Details.cshtml"
       Write(Html.Raw(Model.Body));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Post> Html { get; private set; }
    }
}
#pragma warning restore 1591