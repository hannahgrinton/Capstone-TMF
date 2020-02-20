#pragma checksum "/media/fuzzbox/lin_storage/localDev/tmf-revenue/Capstone-TMF/TMFadmin/Views/Home/AddSponsor.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1d7cd749b215688fcee14cdc84ffe925c859a72d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_AddSponsor), @"mvc.1.0.view", @"/Views/Home/AddSponsor.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/AddSponsor.cshtml", typeof(AspNetCore.Views_Home_AddSponsor))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1d7cd749b215688fcee14cdc84ffe925c859a72d", @"/Views/Home/AddSponsor.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c203a504c99f9fe72cfec22652e8be5d1cddca5e", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_AddSponsor : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<TMFadmin.Models.RevenueManager>
    {
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(38, 134, true);
            WriteLiteral("<div class=\"text-center\" style=\"margin-top: 100px;\">\n    <h1 class=\"display-4\">Add Customer</h1>\n    <div class=\"container\">\n\n        ");
            EndContext();
            BeginContext(172, 4499, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1d7cd749b215688fcee14cdc84ffe925c859a72d3509", async() => {
                BeginContext(178, 4486, true);
                WriteLiteral(@"
        <div role=""tablist"" id=""accordion-1"">
            <div class=""card"">
                <div class=""card-header accHead"" role=""tab"">
                    <h5 class=""mb-0""><a style=""color:white"" data-toggle=""collapse"" aria-expanded=""true"" aria-controls=""accordion-1 .item-1"" href=""#accordion-1 .item-1"">Contact</a></h5>
                </div>
                <div class=""collapse show item-1"" role=""tabpanel"" data-parent=""#accordion-1"">
                    <div class=""card-body"">
                        <div class=""form-group""><label id=""lblFirstName"" for=""txtFirstName"">First Name</label><input class=""form-control"" type=""text"" id=""txtFirstName"" name=""firstName"" maxlength=""50""></div>
                        <div class=""form-group""><label id=""lblLastName"" for=""txtLastName"">Last Name</label><input class=""form-control"" type=""text"" id=""txtLastName"" name=""lastName"" maxlength=""50""></div>
                        <div class=""form-group""><label id=""lblCompany"" for=""txtCompany"">Company</label><input class=""form-control""");
                WriteLiteral(@" type=""text"" id=""txtCompany"" maxlength=""50"" name=""company""></div>
                        <div class=""form-group""><label id=""lblPhone"" for=""txtPhone"">Phone</label><input class=""form-control"" type=""tel"" id=""txtPhone"" name=""phone""></div>
                        <div class=""form-group""><label id=""lblFax"" for=""txtFax"">Fax</label><input class=""form-control"" type=""tel"" id=""txtFax"" name=""fax""></div>
                        <div class=""form-group""><label id=""lblEmail"" for=""txtEmail"">Email</label><input class=""form-control"" type=""email"" id=""txtEmail"" maxlength=""50""></div>
                    </div>
                </div>
            </div>
            <div class=""card"">
                <div class=""card-header accHead"" role=""tab"">
                    <h5 class=""mb-0""><a style=""color:white"" data-toggle=""collapse"" aria-expanded=""false"" aria-controls=""accordion-1 .item-2"" href=""#accordion-1 .item-2"">Address</a></h5>
                </div>
                <div class=""collapse item-2"" role=""tabpanel"" data-parent=""#accordion");
                WriteLiteral(@"-1"">
                    <div class=""card-body"">
                        <div class=""form-group""><label for=""txtAddress"">Street Address</label><input class=""form-control"" type=""text"" id=""txtAddress"" name=""address"" maxlength=""50""></div>
                        <div class=""form-group""><label id=""lblCity"" for=""txtCity"">City</label><input class=""form-control"" type=""text"" id=""txtCity"" name=""city"" maxlength=""30""></div>
                        <div class=""form-group""><label id=""lblProvince"" for=""txtProvince"">Province</label><input class=""form-control"" type=""text"" id=""txtProvince"" name=""province"" maxlength=""30""></div>
                        <div class=""form-group""></div><label id=""lblPostal"" for=""txtPostal"" name=""postal"">Postal Code</label><input class=""form-control"" type=""text"" id=""txtPostal"" name=""postal"">
                        <div class=""form-group""><label id=""lblCountry"" for=""txtCountry"">Country</label><input class=""form-control"" type=""text"" id=""txtCountry"" name=""country"" maxlength=""30""></div>
               ");
                WriteLiteral(@"         <div class=""form-group""><label>Address Type</label>
                            <div class=""form-check""><input class=""form-check-input"" type=""radio"" id=""chkRes"" name=""residential""><label class=""form-check-label"" for=""formCheck-1"">Residential</label></div>
                            <div class=""form-check""><input class=""form-check-input"" type=""radio"" id=""chkBusi"" name=""business""><label class=""form-check-label"" for=""formCheck-2"">Business</label></div>
                        </div>
                    </div>
                </div>
            </div>
            <div class=""card"">
                <div class=""card-header accHead"" role=""tab"">
                    <h5 class=""mb-0""><a style=""color:white"" data-toggle=""collapse"" aria-expanded=""false"" aria-controls=""accordion-1 .item-3"" href=""#accordion-1 .item-3"">Additional</a></h5>
                </div>
                <div class=""collapse item-3"" role=""tabpanel"" data-parent=""#accordion-1"">
                    <div class=""card-body"">
                       ");
                WriteLiteral(@" <div class=""form-group""><label id=""lblNotes"" for=""txtNotes"">Notes</label><textarea class=""form-control"" id=""txtNotes"" name=""notes"" maxlength=""255""></textarea></div>
                    </div>
                </div>
            </div>
        </div>
        <div class=""form-group""><button style=""margin:15px"" class=""btn btn-primary btn-submit"" type=""button"">Add Contact</button></div>
    ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(4671, 18, true);
            WriteLiteral("\n    </div>\n</div>");
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
