#pragma checksum "C:\Users\Rzepa\Desktop\PC-Store\PC-Store\Views\Rams\RamDetails.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "512a69e914c45a1b2cceb9567e54c5ec7c9efa46"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Rams_RamDetails), @"mvc.1.0.view", @"/Views/Rams/RamDetails.cshtml")]
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
#line 1 "C:\Users\Rzepa\Desktop\PC-Store\PC-Store\Views\_ViewImports.cshtml"
using PC_Store;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Rzepa\Desktop\PC-Store\PC-Store\Views\_ViewImports.cshtml"
using PC_Store.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Rzepa\Desktop\PC-Store\PC-Store\Views\_ViewImports.cshtml"
using PC_Store.Models.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"512a69e914c45a1b2cceb9567e54c5ec7c9efa46", @"/Views/Rams/RamDetails.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9b0c1d3f87b12c65acf0f22202cba3e956ad6ac5", @"/Views/_ViewImports.cshtml")]
    public class Views_Rams_RamDetails : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<PC_Store.Views.ViewModels.RamProduct>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("img-fluid z-depth-1"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/images/serverimg/brak_zdjecia.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "ShoppingCart", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "AddtoShoppingCart", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Home", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "RamList", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\Rzepa\Desktop\PC-Store\PC-Store\Views\Rams\RamDetails.cshtml"
  
    ViewData["Title"] = "Szczegóły Obudowy";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<center><h1>");
#nullable restore
#line 7 "C:\Users\Rzepa\Desktop\PC-Store\PC-Store\Views\Rams\RamDetails.cshtml"
       Write(Model.ram.Producer);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 7 "C:\Users\Rzepa\Desktop\PC-Store\PC-Store\Views\Rams\RamDetails.cshtml"
                           Write(Model.ram.ProducerCode);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h1></center>

<div>
    <hr />
    <section class=""mb-5"">

        <div class=""row"">
            <div class=""col-md-6 mb-4 mb-md-0"">

                <div id=""mdb-lightbox-ui""></div>

                <div class=""mdb-lightbox"">

                    <div class=""row product-gallery mx-1"">

                        <div class=""col-12 mb-0"">
                            <figure class=""view overlay rounded z-depth-1 main-img"">

");
#nullable restore
#line 25 "C:\Users\Rzepa\Desktop\PC-Store\PC-Store\Views\Rams\RamDetails.cshtml"
                                 if (@Model.Product.Picture != null)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "512a69e914c45a1b2cceb9567e54c5ec7c9efa467142", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 752, "~/images/", 752, 9, true);
#nullable restore
#line 27 "C:\Users\Rzepa\Desktop\PC-Store\PC-Store\Views\Rams\RamDetails.cshtml"
AddHtmlAttributeValue("", 761, Model.Product.Picture, 761, 22, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 28 "C:\Users\Rzepa\Desktop\PC-Store\PC-Store\Views\Rams\RamDetails.cshtml"
                                }
                                else
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "512a69e914c45a1b2cceb9567e54c5ec7c9efa469028", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 32 "C:\Users\Rzepa\Desktop\PC-Store\PC-Store\Views\Rams\RamDetails.cshtml"
                                }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                            </figure>
                        </div>
                    </div>

                </div>

            </div>
            <div class=""col-md-6"">

                <h5>Szczegóły processora</h5>
                <ul class=""rating"">
                    <li>
                        <i>Producent: ");
#nullable restore
#line 45 "C:\Users\Rzepa\Desktop\PC-Store\PC-Store\Views\Rams\RamDetails.cshtml"
                                 Write(Model.ram.Producer);

#line default
#line hidden
#nullable disable
            WriteLiteral("</i>\r\n                    </li>\r\n                    <li>\r\n                        <i>Kod producenta: ");
#nullable restore
#line 48 "C:\Users\Rzepa\Desktop\PC-Store\PC-Store\Views\Rams\RamDetails.cshtml"
                                      Write(Model.ram.ProducerCode);

#line default
#line hidden
#nullable disable
            WriteLiteral("</i>\r\n                    </li>\r\n                    <li>\r\n                        <i>Kolor: ");
#nullable restore
#line 51 "C:\Users\Rzepa\Desktop\PC-Store\PC-Store\Views\Rams\RamDetails.cshtml"
                             Write(Model.ram.Line);

#line default
#line hidden
#nullable disable
            WriteLiteral("</i>\r\n                    </li>\r\n                    <li>\r\n                        <i>Podświetlenie: ");
#nullable restore
#line 54 "C:\Users\Rzepa\Desktop\PC-Store\PC-Store\Views\Rams\RamDetails.cshtml"
                                     Write(Model.ram.ConnectorType);

#line default
#line hidden
#nullable disable
            WriteLiteral("</i>\r\n                    </li>\r\n                    <li>\r\n                        <i>Wysokość [cm]: ");
#nullable restore
#line 57 "C:\Users\Rzepa\Desktop\PC-Store\PC-Store\Views\Rams\RamDetails.cshtml"
                                     Write(Model.ram.MemoryType);

#line default
#line hidden
#nullable disable
            WriteLiteral("</i>\r\n                    </li>\r\n                    <li>\r\n                        <i>Szerokość [cm]: ");
#nullable restore
#line 60 "C:\Users\Rzepa\Desktop\PC-Store\PC-Store\Views\Rams\RamDetails.cshtml"
                                      Write(Model.ram.Cooling);

#line default
#line hidden
#nullable disable
            WriteLiteral("</i>\r\n                    </li>\r\n                    <li>\r\n                        <i>Głębokość [cm]: ");
#nullable restore
#line 63 "C:\Users\Rzepa\Desktop\PC-Store\PC-Store\Views\Rams\RamDetails.cshtml"
                                      Write(Model.ram.LowProfile);

#line default
#line hidden
#nullable disable
            WriteLiteral("</i>\r\n                    </li>\r\n                    <li>\r\n                        <i>Waga [kg]: ");
#nullable restore
#line 66 "C:\Users\Rzepa\Desktop\PC-Store\PC-Store\Views\Rams\RamDetails.cshtml"
                                 Write(Model.ram.TotalCapacity);

#line default
#line hidden
#nullable disable
            WriteLiteral("</i>\r\n                    </li>\r\n                    <li>\r\n                        <i>Typ obudowy: ");
#nullable restore
#line 69 "C:\Users\Rzepa\Desktop\PC-Store\PC-Store\Views\Rams\RamDetails.cshtml"
                                   Write(Model.ram.NumberOfModules);

#line default
#line hidden
#nullable disable
            WriteLiteral("</i>\r\n                    </li>\r\n                    <li>\r\n                        <i>Kompatybilność: ");
#nullable restore
#line 72 "C:\Users\Rzepa\Desktop\PC-Store\PC-Store\Views\Rams\RamDetails.cshtml"
                                      Write(Model.ram.Frequency);

#line default
#line hidden
#nullable disable
            WriteLiteral("</i>\r\n                    </li>\r\n                    <li>\r\n                        <i>Okno: ");
#nullable restore
#line 75 "C:\Users\Rzepa\Desktop\PC-Store\PC-Store\Views\Rams\RamDetails.cshtml"
                            Write(Model.ram.Delay);

#line default
#line hidden
#nullable disable
            WriteLiteral("</i>\r\n                    </li>\r\n                    <li>\r\n                        <i>Wyciszona: ");
#nullable restore
#line 78 "C:\Users\Rzepa\Desktop\PC-Store\PC-Store\Views\Rams\RamDetails.cshtml"
                                 Write(Model.ram.Voltage);

#line default
#line hidden
#nullable disable
            WriteLiteral("</i>\r\n                    </li>\r\n                    <li>\r\n                        <i>USB 2.0: ");
#nullable restore
#line 81 "C:\Users\Rzepa\Desktop\PC-Store\PC-Store\Views\Rams\RamDetails.cshtml"
                               Write(Model.ram.Backlight);

#line default
#line hidden
#nullable disable
            WriteLiteral("</i>\r\n                    </li>\r\n                </ul>\r\n                <h3><span class=\"mr-1\"><strong>Cena: ");
#nullable restore
#line 84 "C:\Users\Rzepa\Desktop\PC-Store\PC-Store\Views\Rams\RamDetails.cshtml"
                                                Write(Model.Product.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral(@" Zł</strong></span></h3>
                <p class=""pt-1"">
                    Lorem ipsum dolor sit amet consectetur adipisicing elit. Numquam, sapiente illo. Sit
                    error voluptas repellat rerum quidem, soluta enim perferendis voluptates laboriosam. Distinctio,
                    officia quis dolore quos sapiente tempore alias.
                </p>
                <hr>
                <h4><strong>Ilość:</strong></h4>
                <div class=""def-number-input number-input safari_only"">
                    <input class=""quantity"" min=""0"" name=""quantity"" value=""1"" type=""number"">
                </div>
                <hr>
                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "512a69e914c45a1b2cceb9567e54c5ec7c9efa4616216", async() => {
                WriteLiteral("\r\n                    <button type=\"button\" class=\"btn btn-primary btn-md mr-1 mb-2\">\r\n                        <i class=\"fas fa-shopping-cart pr-2\"></i>Dodaj do koszyka\r\n                    </button>\r\n                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 96 "C:\Users\Rzepa\Desktop\PC-Store\PC-Store\Views\Rams\RamDetails.cshtml"
                                                                                  WriteLiteral(Model.Product.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n            </div>\r\n        </div>\r\n\r\n    </section>\r\n    <div>\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "512a69e914c45a1b2cceb9567e54c5ec7c9efa4618922", async() => {
                WriteLiteral("\r\n            <div class=\"form-group\">\r\n                <input type=\"submit\" value=\"Wróć\" class=\"btn btn-primary\" />\r\n            </div>\r\n        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n    </div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<PC_Store.Views.ViewModels.RamProduct> Html { get; private set; }
    }
}
#pragma warning restore 1591
