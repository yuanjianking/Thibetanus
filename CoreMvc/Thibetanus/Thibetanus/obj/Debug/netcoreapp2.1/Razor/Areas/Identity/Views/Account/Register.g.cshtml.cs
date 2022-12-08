#pragma checksum "D:\source\CoreMvc\Thibetanus\Thibetanus\Areas\Identity\Views\Account\Register.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "31e7f501f6fc126c85104055d53011e34d3fc2c1"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Identity_Views_Account_Register), @"mvc.1.0.view", @"/Areas/Identity/Views/Account/Register.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/Identity/Views/Account/Register.cshtml", typeof(AspNetCore.Areas_Identity_Views_Account_Register))]
namespace AspNetCore
{
    #line hidden
    using System;
#line 1 "D:\source\CoreMvc\Thibetanus\Thibetanus\Areas\Identity\Views\Account\Register.cshtml"
using System.Collections.Generic;

#line default
#line hidden
#line 2 "D:\source\CoreMvc\Thibetanus\Thibetanus\Areas\Identity\Views\Account\Register.cshtml"
using System.Linq;

#line default
#line hidden
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 3 "D:\source\CoreMvc\Thibetanus\Thibetanus\Areas\Identity\Views\Account\Register.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
#line 4 "D:\source\CoreMvc\Thibetanus\Thibetanus\Areas\Identity\Views\Account\Register.cshtml"
using Microsoft.AspNetCore.Http.Authentication;

#line default
#line hidden
#line 5 "D:\source\CoreMvc\Thibetanus\Thibetanus\Areas\Identity\Views\Account\Register.cshtml"
using Thibetanus.Areas.Identity.Models;

#line default
#line hidden
#line 6 "D:\source\CoreMvc\Thibetanus\Thibetanus\Areas\Identity\Views\Account\Register.cshtml"
using Thibetanus.Areas.Identity;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"31e7f501f6fc126c85104055d53011e34d3fc2c1", @"/Areas/Identity/Views/Account/Register.cshtml")]
    public class Areas_Identity_Views_Account_Register : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<LoginViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(310, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 11 "D:\source\CoreMvc\Thibetanus\Thibetanus\Areas\Identity\Views\Account\Register.cshtml"
  
    ViewData["Title"] = "Login";

#line default
#line hidden
            BeginContext(353, 103, true);
            WriteLiteral("\r\n<h2>Login</h2>\r\n\r\n<div class=\"row\">\r\n    <div class=\"col-md-4\">\r\n        <section>\r\n            <form");
            EndContext();
            BeginWriteAttribute("asp-route-returnurl", " asp-route-returnurl=\"", 456, "\"", 500, 1);
#line 20 "D:\source\CoreMvc\Thibetanus\Thibetanus\Areas\Identity\Views\Account\Register.cshtml"
WriteAttributeValue("", 478, ViewData["ReturnUrl"], 478, 22, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(501, 955, true);
            WriteLiteral(@" method=""post"">
                <h4>Use a local account to log in.</h4>
                <hr />
                <div asp-validation-summary=""All"" class=""text-danger""></div>
                <div class=""form-group"">
                    <label asp-for=""Email""></label>
                    <input asp-for=""Email"" class=""form-control"" />
                    <span asp-validation-for=""Email"" class=""text-danger""></span>

                </div>
                <div class=""form-group"">
                    <label asp-for=""Password""></label>
                    <input asp-for=""Password"" class=""form-control"" />
                    <span asp-validation-for=""Password"" class=""text-danger""></span>

                </div>
                <div class=""form-group"">
                    <div class=""checkbox"">
                        <label asp-for=""RememberMe"">
                            <input asp-for=""RememberMe"" />
                            ");
            EndContext();
            BeginContext(1457, 38, false);
#line 40 "D:\source\CoreMvc\Thibetanus\Thibetanus\Areas\Identity\Views\Account\Register.cshtml"
                       Write(Html.DisplayNameFor(m => m.RememberMe));

#line default
#line hidden
            EndContext();
            BeginContext(1495, 495, true);
            WriteLiteral(@"

                        </label>

                    </div>

                </div>
                <div class=""form-group"">
                    <button type=""submit"" class=""btn btn-default"">Log in</button>

                </div>
                <div class=""form-group"">
                    <p>
                        <a asp-action=""ForgotPassword"">Forgot your password?</a>

                    </p>
                    <p>
                        <a asp-action=""Register""");
            EndContext();
            BeginWriteAttribute("asp-route-returnurl", " asp-route-returnurl=\"", 1990, "\"", 2034, 1);
#line 57 "D:\source\CoreMvc\Thibetanus\Thibetanus\Areas\Identity\Views\Account\Register.cshtml"
WriteAttributeValue("", 2012, ViewData["ReturnUrl"], 2012, 22, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2035, 279, true);
            WriteLiteral(@">Register as a new user?</a>

                    </p>

                </div>

            </form>

        </section>

    </div>
    <div class=""col-md-6 col-md-offset-2"">
        <section>
            <h4>Use another service to log in.</h4>
            <hr />
");
            EndContext();
#line 72 "D:\source\CoreMvc\Thibetanus\Thibetanus\Areas\Identity\Views\Account\Register.cshtml"
              
                var loginProviders = (await SignInManager.GetExternalAuthenticationSchemesAsync()).ToList();
                if (loginProviders.Count == 0)
                {

#line default
#line hidden
            BeginContext(2507, 395, true);
            WriteLiteral(@"                    < div >
                    < p >
                    There are no external authentication services configured.See < a href = ""https://go.microsoft.com/fwlink/?LinkID=532715"" > this article </ a >
                    for details on setting up this ASP.NET application to support logging in via external services.
                    </ p >
                    </ div >
");
            EndContext();
#line 82 "D:\source\CoreMvc\Thibetanus\Thibetanus\Areas\Identity\Views\Account\Register.cshtml"
                }
                else
                {

#line default
#line hidden
            BeginContext(2962, 52, true);
            WriteLiteral("                    <form asp-action=\"ExternalLogin\"");
            EndContext();
            BeginWriteAttribute("asp-route-returnurl", " asp-route-returnurl=\"", 3014, "\"", 3058, 1);
#line 85 "D:\source\CoreMvc\Thibetanus\Thibetanus\Areas\Identity\Views\Account\Register.cshtml"
WriteAttributeValue("", 3036, ViewData["ReturnUrl"], 3036, 22, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(3059, 105, true);
            WriteLiteral(" method=\"post\" class=\"form-horizontal\">\r\n                        <div>\r\n                            <p>\r\n");
            EndContext();
#line 88 "D:\source\CoreMvc\Thibetanus\Thibetanus\Areas\Identity\Views\Account\Register.cshtml"
                                 foreach (var provider in loginProviders)
                                {

#line default
#line hidden
            BeginContext(3274, 97, true);
            WriteLiteral("                                    <button type=\"submit\" class=\"btn btn-default\" name=\"provider\"");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 3371, "\"", 3393, 1);
#line 90 "D:\source\CoreMvc\Thibetanus\Thibetanus\Areas\Identity\Views\Account\Register.cshtml"
WriteAttributeValue("", 3379, provider.Name, 3379, 14, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginWriteAttribute("title", " title=\"", 3394, "\"", 3449, 6);
            WriteAttributeValue("", 3402, "Log", 3402, 3, true);
            WriteAttributeValue(" ", 3405, "in", 3406, 3, true);
            WriteAttributeValue(" ", 3408, "using", 3409, 6, true);
            WriteAttributeValue(" ", 3414, "your", 3415, 5, true);
#line 90 "D:\source\CoreMvc\Thibetanus\Thibetanus\Areas\Identity\Views\Account\Register.cshtml"
WriteAttributeValue(" ", 3419, provider.DisplayName, 3420, 21, false);

#line default
#line hidden
            WriteAttributeValue(" ", 3441, "account", 3442, 8, true);
            EndWriteAttribute();
            BeginContext(3450, 1, true);
            WriteLiteral(">");
            EndContext();
            BeginContext(3452, 13, false);
#line 90 "D:\source\CoreMvc\Thibetanus\Thibetanus\Areas\Identity\Views\Account\Register.cshtml"
                                                                                                                                                                            Write(provider.Name);

#line default
#line hidden
            EndContext();
            BeginContext(3465, 11, true);
            WriteLiteral("</button>\r\n");
            EndContext();
#line 91 "D:\source\CoreMvc\Thibetanus\Thibetanus\Areas\Identity\Views\Account\Register.cshtml"
                                }

#line default
#line hidden
            BeginContext(3511, 95, true);
            WriteLiteral("                            </p>\r\n                        </div>\r\n                    </form>\r\n");
            EndContext();
#line 95 "D:\source\CoreMvc\Thibetanus\Thibetanus\Areas\Identity\Views\Account\Register.cshtml"
                }
            

#line default
#line hidden
            BeginContext(3640, 48, true);
            WriteLiteral("\r\n        </section>\r\n\r\n    </div>\r\n\r\n</div>\r\n\r\n");
            EndContext();
            DefineSection("Scripts", async() => {
                BeginContext(3706, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(3713, 52, false);
#line 105 "D:\source\CoreMvc\Thibetanus\Thibetanus\Areas\Identity\Views\Account\Register.cshtml"
Write(await Html.PartialAsync("_ValidationScriptsPartial"));

#line default
#line hidden
                EndContext();
                BeginContext(3765, 2, true);
                WriteLiteral("\r\n");
                EndContext();
            }
            );
            BeginContext(3770, 2, true);
            WriteLiteral("\r\n");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public MySignInManager SignInManager { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public MyUserManager UserManager { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<LoginViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591