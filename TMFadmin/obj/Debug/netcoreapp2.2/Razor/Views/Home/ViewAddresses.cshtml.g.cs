#pragma checksum "/media/fuzzbox/lin_storage/localDev/tmf-revenue/Capstone-TMF/TMFadmin/Views/Home/ViewAddresses.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ebb9644557abd7e3fd5129c15bb422b4f8f1aa14"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_ViewAddresses), @"mvc.1.0.view", @"/Views/Home/ViewAddresses.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/ViewAddresses.cshtml", typeof(AspNetCore.Views_Home_ViewAddresses))]
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
#line 1 "/media/fuzzbox/lin_storage/localDev/tmf-revenue/Capstone-TMF/TMFadmin/Views/_ViewImports.cshtml"
using TMFadmin;

#line default
#line hidden
#line 2 "/media/fuzzbox/lin_storage/localDev/tmf-revenue/Capstone-TMF/TMFadmin/Views/_ViewImports.cshtml"
using TMFadmin.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ebb9644557abd7e3fd5129c15bb422b4f8f1aa14", @"/Views/Home/ViewAddresses.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c203a504c99f9fe72cfec22652e8be5d1cddca5e", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_ViewAddresses : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<TMFadmin.Models.RevenueManager>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", new global::Microsoft.AspNetCore.Html.HtmlString("submit"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Home", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "ViewAddress", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", new global::Microsoft.AspNetCore.Html.HtmlString("myAddressId"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "EditAddress", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "DeleteAddress", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormActionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(38, 731, true);
            WriteLiteral(@"<div class=""text-center"" style=""margin-top: 100px;"">
    <h1 class=""display-4"">Addresses</h1>
    <table class=""table table-hover table-striped"" style=""margin-top: 40px;"">
        <thead class=""thead-dark"">
            <tr>
                <th scope=""col"">#</th>
                <th scope=""col"">First Name</th>
                <th scope=""col"">Last Name</th>
                <th scope=""col"">Address Created</th>
                <th scope=""col"">City</th>
                <th scope=""col"">Province</th>
                <th scope=""col"">Postal Code</th>
                <th scope=""col"">Country</th>
                <th scope=""col"">Type</th>
                <th scope=""col"">Options</th>
            </tr>
        </thead>
        <tbody>
");
            EndContext();
#line 20 "/media/fuzzbox/lin_storage/localDev/tmf-revenue/Capstone-TMF/TMFadmin/Views/Home/ViewAddresses.cshtml"
              
                foreach (var item in Model.getAddressesById())
                {

#line default
#line hidden
            BeginContext(865, 53, true);
            WriteLiteral("                    <tr>\n                        <td>");
            EndContext();
            BeginContext(919, 14, false);
#line 24 "/media/fuzzbox/lin_storage/localDev/tmf-revenue/Capstone-TMF/TMFadmin/Views/Home/ViewAddresses.cshtml"
                       Write(item.addressId);

#line default
#line hidden
            EndContext();
            BeginContext(933, 34, true);
            WriteLiteral("</td>\n                        <td>");
            EndContext();
            BeginContext(968, 14, false);
#line 25 "/media/fuzzbox/lin_storage/localDev/tmf-revenue/Capstone-TMF/TMFadmin/Views/Home/ViewAddresses.cshtml"
                       Write(item.firstname);

#line default
#line hidden
            EndContext();
            BeginContext(982, 34, true);
            WriteLiteral("</td>\n                        <td>");
            EndContext();
            BeginContext(1017, 13, false);
#line 26 "/media/fuzzbox/lin_storage/localDev/tmf-revenue/Capstone-TMF/TMFadmin/Views/Home/ViewAddresses.cshtml"
                       Write(item.lastname);

#line default
#line hidden
            EndContext();
            BeginContext(1030, 34, true);
            WriteLiteral("</td>\n                        <td>");
            EndContext();
            BeginContext(1065, 12, false);
#line 27 "/media/fuzzbox/lin_storage/localDev/tmf-revenue/Capstone-TMF/TMFadmin/Views/Home/ViewAddresses.cshtml"
                       Write(item.address);

#line default
#line hidden
            EndContext();
            BeginContext(1077, 34, true);
            WriteLiteral("</td>\n                        <td>");
            EndContext();
            BeginContext(1112, 9, false);
#line 28 "/media/fuzzbox/lin_storage/localDev/tmf-revenue/Capstone-TMF/TMFadmin/Views/Home/ViewAddresses.cshtml"
                       Write(item.city);

#line default
#line hidden
            EndContext();
            BeginContext(1121, 34, true);
            WriteLiteral("</td>\n                        <td>");
            EndContext();
            BeginContext(1156, 13, false);
#line 29 "/media/fuzzbox/lin_storage/localDev/tmf-revenue/Capstone-TMF/TMFadmin/Views/Home/ViewAddresses.cshtml"
                       Write(item.province);

#line default
#line hidden
            EndContext();
            BeginContext(1169, 34, true);
            WriteLiteral("</td>\n                        <td>");
            EndContext();
            BeginContext(1204, 11, false);
#line 30 "/media/fuzzbox/lin_storage/localDev/tmf-revenue/Capstone-TMF/TMFadmin/Views/Home/ViewAddresses.cshtml"
                       Write(item.postal);

#line default
#line hidden
            EndContext();
            BeginContext(1215, 34, true);
            WriteLiteral("</td>\n                        <td>");
            EndContext();
            BeginContext(1250, 12, false);
#line 31 "/media/fuzzbox/lin_storage/localDev/tmf-revenue/Capstone-TMF/TMFadmin/Views/Home/ViewAddresses.cshtml"
                       Write(item.country);

#line default
#line hidden
            EndContext();
            BeginContext(1262, 34, true);
            WriteLiteral("</td>\n                        <td>");
            EndContext();
            BeginContext(1297, 9, false);
#line 32 "/media/fuzzbox/lin_storage/localDev/tmf-revenue/Capstone-TMF/TMFadmin/Views/Home/ViewAddresses.cshtml"
                       Write(item.type);

#line default
#line hidden
            EndContext();
            BeginContext(1306, 63, true);
            WriteLiteral("</td>\n                        <td>\n                            ");
            EndContext();
            BeginContext(1369, 776, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ebb9644557abd7e3fd5129c15bb422b4f8f1aa1410387", async() => {
                BeginContext(1389, 109, true);
                WriteLiteral("\n                                <label class=\"ico-button\"><i class=\"far fa-eye\" style=\"font-size:20px;\"></i>");
                EndContext();
                BeginContext(1498, 118, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "ebb9644557abd7e3fd5129c15bb422b4f8f1aa1410881", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormActionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.Action = (string)__tagHelperAttribute_2.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
                BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "value", 1, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#line 35 "/media/fuzzbox/lin_storage/localDev/tmf-revenue/Capstone-TMF/TMFadmin/Views/Home/ViewAddresses.cshtml"
AddHtmlAttributeValue("", 1573, item.addressId, 1573, 15, false);

#line default
#line hidden
                EndAddHtmlAttributeValues(__tagHelperExecutionContext);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                BeginWriteTagHelperAttribute();
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __tagHelperExecutionContext.AddHtmlAttribute("hidden", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.Minimized);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(1616, 124, true);
                WriteLiteral("</label>\n                                <label class=\"ico-button\"><i class=\"fas fa-pencil-alt\" style=\"font-size:20px;\"></i>");
                EndContext();
                BeginContext(1740, 118, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "ebb9644557abd7e3fd5129c15bb422b4f8f1aa1413493", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormActionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.Action = (string)__tagHelperAttribute_4.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
                BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "value", 1, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#line 36 "/media/fuzzbox/lin_storage/localDev/tmf-revenue/Capstone-TMF/TMFadmin/Views/Home/ViewAddresses.cshtml"
AddHtmlAttributeValue("", 1815, item.addressId, 1815, 15, false);

#line default
#line hidden
                EndAddHtmlAttributeValues(__tagHelperExecutionContext);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                BeginWriteTagHelperAttribute();
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __tagHelperExecutionContext.AddHtmlAttribute("hidden", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.Minimized);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(1858, 123, true);
                WriteLiteral("</label>\n                                <label class=\"ico-button\"><i class=\"fas fa-trash-alt\" style=\"font-size:20px;\"></i>");
                EndContext();
                BeginContext(1981, 120, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "ebb9644557abd7e3fd5129c15bb422b4f8f1aa1416104", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormActionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.Action = (string)__tagHelperAttribute_5.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
                BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "value", 1, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#line 37 "/media/fuzzbox/lin_storage/localDev/tmf-revenue/Capstone-TMF/TMFadmin/Views/Home/ViewAddresses.cshtml"
AddHtmlAttributeValue("", 2058, item.addressId, 2058, 15, false);

#line default
#line hidden
                EndAddHtmlAttributeValues(__tagHelperExecutionContext);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                BeginWriteTagHelperAttribute();
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __tagHelperExecutionContext.AddHtmlAttribute("hidden", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.Minimized);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(2101, 37, true);
                WriteLiteral("</label>\n                            ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_6.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2145, 86, true);
            WriteLiteral("\n                            \n                        </td>\n                    </tr>\n");
            EndContext();
#line 42 "/media/fuzzbox/lin_storage/localDev/tmf-revenue/Capstone-TMF/TMFadmin/Views/Home/ViewAddresses.cshtml"
                }
            

#line default
#line hidden
            BeginContext(2263, 36, true);
            WriteLiteral("        </tbody>\n    </table>\n</div>");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<TMFadmin.Models.RevenueManager> Html { get; private set; }
    }
}
#pragma warning restore 1591