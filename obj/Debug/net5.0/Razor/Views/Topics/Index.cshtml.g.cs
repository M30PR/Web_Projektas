#pragma checksum "C:\Users\laury\Desktop\Web_Projektas\Web_Projektas\Views\Topics\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9816459d0fa4bc7b926e1f66e55729c142c4ea84"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Topics_Index), @"mvc.1.0.view", @"/Views/Topics/Index.cshtml")]
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
#line 1 "C:\Users\laury\Desktop\Web_Projektas\Web_Projektas\Views\_ViewImports.cshtml"
using Web_Projektas;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\laury\Desktop\Web_Projektas\Web_Projektas\Views\_ViewImports.cshtml"
using Web_Projektas.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9816459d0fa4bc7b926e1f66e55729c142c4ea84", @"/Views/Topics/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cbdecb8ca089899377ca77ff30e9524d7ec1fffa", @"/Views/_ViewImports.cshtml")]
    public class Views_Topics_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Web_Projektas.Models.Topic>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\laury\Desktop\Web_Projektas\Web_Projektas\Views\Topics\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<style>
    il {
        width: 600px;
        height: 400px;
        background-color: #ccc;
    }
    h1 {
        text-align: center;
        background-color: black;
    }
    ul {
        font-family:Arial;
        font-size: 18px;
        columns: 3;
        -webkit-columns: 3;
        -moz-columns: 3;
    }
</style>

<h1>Topics List</h1>
<il> 
<ul>
");
#nullable restore
#line 28 "C:\Users\laury\Desktop\Web_Projektas\Web_Projektas\Views\Topics\Index.cshtml"
     foreach (Topic Topics in Model)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <li>\r\n            ");
#nullable restore
#line 31 "C:\Users\laury\Desktop\Web_Projektas\Web_Projektas\Views\Topics\Index.cshtml"
       Write(Html.ActionLink(Topics.Name, "Details", new { id = Topics.TopicId }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </li>\r\n");
#nullable restore
#line 33 "C:\Users\laury\Desktop\Web_Projektas\Web_Projektas\Views\Topics\Index.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</ul>\r\n</il>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Web_Projektas.Models.Topic>> Html { get; private set; }
    }
}
#pragma warning restore 1591
