#pragma checksum "C:\Users\LerkaEklerka\Desktop\ScheduleApp\ScheduleApp\ScheduleApp\Views\Role\Edit.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0e10f1d3a0436a707810d211d10251ec5d89e6ba"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Role_Edit), @"mvc.1.0.view", @"/Views/Role/Edit.cshtml")]
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
#line 1 "C:\Users\LerkaEklerka\Desktop\ScheduleApp\ScheduleApp\ScheduleApp\Views\_ViewImports.cshtml"
using ScheduleApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\LerkaEklerka\Desktop\ScheduleApp\ScheduleApp\ScheduleApp\Views\_ViewImports.cshtml"
using ScheduleApp.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Users\LerkaEklerka\Desktop\ScheduleApp\ScheduleApp\ScheduleApp\Views\Role\Edit.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0e10f1d3a0436a707810d211d10251ec5d89e6ba", @"/Views/Role/Edit.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"24516460a9c1610fab725b22a9f8c913049f924f", @"/Views/_ViewImports.cshtml")]
    public class Views_Role_Edit : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ScheduleApp.ViewModels.ChangeRoleViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "C:\Users\LerkaEklerka\Desktop\ScheduleApp\ScheduleApp\ScheduleApp\Views\Role\Edit.cshtml"
  
    ViewData["Title"] = "Edit";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h2>Зміна ролі для користувача ");
#nullable restore
#line 7 "C:\Users\LerkaEklerka\Desktop\ScheduleApp\ScheduleApp\ScheduleApp\Views\Role\Edit.cshtml"
                          Write(Model.UserEmail);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0e10f1d3a0436a707810d211d10251ec5d89e6ba4581", async() => {
                WriteLiteral("\r\n    <input type=\"hidden\" name=\"userId\"");
                BeginWriteAttribute("value", " value=\"", 265, "\"", 286, 1);
#nullable restore
#line 10 "C:\Users\LerkaEklerka\Desktop\ScheduleApp\ScheduleApp\ScheduleApp\Views\Role\Edit.cshtml"
WriteAttributeValue("", 273, Model.UserId, 273, 13, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\r\n");
#nullable restore
#line 11 "C:\Users\LerkaEklerka\Desktop\ScheduleApp\ScheduleApp\ScheduleApp\Views\Role\Edit.cshtml"
     foreach (IdentityRole role in Model.AllRoles)
    {

#line default
#line hidden
#nullable disable
                WriteLiteral("        <div class=\"form-check\">\r\n            <input class=\"form-check-input\"");
                BeginWriteAttribute("id", "\r\n                   id=\"", 428, "\"", 470, 2);
                WriteAttributeValue("", 453, "roleId", 453, 6, true);
#nullable restore
#line 15 "C:\Users\LerkaEklerka\Desktop\ScheduleApp\ScheduleApp\ScheduleApp\Views\Role\Edit.cshtml"
WriteAttributeValue(" ", 459, role.Name, 460, 10, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral("\r\n                   type=\"checkbox\"\r\n                   name=\"roles\"");
                BeginWriteAttribute("value", "\r\n                   value=\"", 540, "\"", 578, 1);
#nullable restore
#line 18 "C:\Users\LerkaEklerka\Desktop\ScheduleApp\ScheduleApp\ScheduleApp\Views\Role\Edit.cshtml"
WriteAttributeValue("", 568, role.Name, 568, 10, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral("\r\n                   ");
#nullable restore
#line 19 "C:\Users\LerkaEklerka\Desktop\ScheduleApp\ScheduleApp\ScheduleApp\Views\Role\Edit.cshtml"
               Write(Model.UserRoles.Contains(role.Name) ? "checked=\"checked\"" : "");

#line default
#line hidden
#nullable disable
                WriteLiteral(" />\r\n            <label class=\"form-check-label\"");
                BeginWriteAttribute("for", " for=\"", 715, "\"", 738, 2);
                WriteAttributeValue("", 721, "roleId", 721, 6, true);
#nullable restore
#line 20 "C:\Users\LerkaEklerka\Desktop\ScheduleApp\ScheduleApp\ScheduleApp\Views\Role\Edit.cshtml"
WriteAttributeValue(" ", 727, role.Name, 728, 10, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">");
#nullable restore
#line 20 "C:\Users\LerkaEklerka\Desktop\ScheduleApp\ScheduleApp\ScheduleApp\Views\Role\Edit.cshtml"
                                                               Write(role.Name);

#line default
#line hidden
#nullable disable
                WriteLiteral("</label>\r\n        </div>\r\n");
#nullable restore
#line 22 "C:\Users\LerkaEklerka\Desktop\ScheduleApp\ScheduleApp\ScheduleApp\Views\Role\Edit.cshtml"
    }

#line default
#line hidden
#nullable disable
                WriteLiteral("    <button type=\"submit\" class=\"btn btn-primary\">Зберегти</button>\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ScheduleApp.ViewModels.ChangeRoleViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
