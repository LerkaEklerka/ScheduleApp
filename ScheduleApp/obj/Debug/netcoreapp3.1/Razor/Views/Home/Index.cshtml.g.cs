#pragma checksum "C:\Users\Valentin\source\repos\ScheduleApp\ScheduleApp\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "09f1102e96e3e848296939848233337564b349cf"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
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
#line 1 "C:\Users\Valentin\source\repos\ScheduleApp\ScheduleApp\Views\_ViewImports.cshtml"
using ScheduleApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Valentin\source\repos\ScheduleApp\ScheduleApp\Views\_ViewImports.cshtml"
using ScheduleApp.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"09f1102e96e3e848296939848233337564b349cf", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"24516460a9c1610fab725b22a9f8c913049f924f", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\Valentin\source\repos\ScheduleApp\ScheduleApp\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Home Page";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""text-center"">
    <h1 class=""display-4"">Весь розклад</h1>
    <table class=""table table-hover"">
        <thead class=""thead-light"">
            <tr>
                <th scope=""col"">Предмет</th>
                <th scope=""col"">Кабінет</th>
                <th scope=""col"">Викладач</th>
                <th scope=""col"">Група</th>
            </tr>
        </thead>
        <tbody>
");
#nullable restore
#line 17 "C:\Users\Valentin\source\repos\ScheduleApp\ScheduleApp\Views\Home\Index.cshtml"
             foreach (var lesson in ViewBag.Lessons)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <th scope=\"row\"></th>\r\n                    <td></td>\r\n                    <td>r</td>\r\n                    <td></td>\r\n                </tr>\r\n");
#nullable restore
#line 25 "C:\Users\Valentin\source\repos\ScheduleApp\ScheduleApp\Views\Home\Index.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </tbody>\r\n    </table>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
