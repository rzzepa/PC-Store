#pragma checksum "C:\Users\Rzepa\Desktop\PC-Store\PC-Store\Views\PCCreator\MotherboardCreatorDetails.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3388dd76569dfbd458559570a5eb49e419ffd74f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_PCCreator_MotherboardCreatorDetails), @"mvc.1.0.view", @"/Views/PCCreator/MotherboardCreatorDetails.cshtml")]
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
using PC_Store.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3388dd76569dfbd458559570a5eb49e419ffd74f", @"/Views/PCCreator/MotherboardCreatorDetails.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bf057bf8b02e50a4609bf185cd2dff6feb7ed83c", @"/Views/_ViewImports.cshtml")]
    public class Views_PCCreator_MotherboardCreatorDetails : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<PC_Store.ViewModels.MotherboardCreatorViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("img-fluid z-depth-1"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/images/serverimg/brak_zdjecia.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "PcCreator", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "AddToCreator", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "MotherboardListCreator", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\Rzepa\Desktop\PC-Store\PC-Store\Views\PCCreator\MotherboardCreatorDetails.cshtml"
  
    ViewData["Title"] = "Details";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<center><h1>");
#nullable restore
#line 7 "C:\Users\Rzepa\Desktop\PC-Store\PC-Store\Views\PCCreator\MotherboardCreatorDetails.cshtml"
       Write(Model.Producer);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 7 "C:\Users\Rzepa\Desktop\PC-Store\PC-Store\Views\PCCreator\MotherboardCreatorDetails.cshtml"
                       Write(Model.ProducerCode);

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
#line 25 "C:\Users\Rzepa\Desktop\PC-Store\PC-Store\Views\PCCreator\MotherboardCreatorDetails.cshtml"
                                 if (@Model.Picture != null)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "3388dd76569dfbd458559570a5eb49e419ffd74f6718", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 737, "~/images/", 737, 9, true);
#nullable restore
#line 27 "C:\Users\Rzepa\Desktop\PC-Store\PC-Store\Views\PCCreator\MotherboardCreatorDetails.cshtml"
AddHtmlAttributeValue("", 746, Model.Picture, 746, 14, false);

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
#line 28 "C:\Users\Rzepa\Desktop\PC-Store\PC-Store\Views\PCCreator\MotherboardCreatorDetails.cshtml"
                                }
                                else
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "3388dd76569dfbd458559570a5eb49e419ffd74f8636", async() => {
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
#line 32 "C:\Users\Rzepa\Desktop\PC-Store\PC-Store\Views\PCCreator\MotherboardCreatorDetails.cshtml"
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

                <h5>Szczegóły Płyty głównej</h5>
                <ul class=""rating"">
                    <li>
                        <i>Producent: ");
#nullable restore
#line 45 "C:\Users\Rzepa\Desktop\PC-Store\PC-Store\Views\PCCreator\MotherboardCreatorDetails.cshtml"
                                 Write(Model.Producer);

#line default
#line hidden
#nullable disable
            WriteLiteral("</i>\r\n                    </li>\r\n                    <li>\r\n                        <i>Kod producenta: ");
#nullable restore
#line 48 "C:\Users\Rzepa\Desktop\PC-Store\PC-Store\Views\PCCreator\MotherboardCreatorDetails.cshtml"
                                      Write(Model.ProducerCode);

#line default
#line hidden
#nullable disable
            WriteLiteral("</i>\r\n                    </li>\r\n                    <li>\r\n                        <i>Standard: ");
#nullable restore
#line 51 "C:\Users\Rzepa\Desktop\PC-Store\PC-Store\Views\PCCreator\MotherboardCreatorDetails.cshtml"
                                Write(Model.Standard);

#line default
#line hidden
#nullable disable
            WriteLiteral("</i>\r\n                    </li>\r\n                    <li>\r\n                        <i>Chipset: ");
#nullable restore
#line 54 "C:\Users\Rzepa\Desktop\PC-Store\PC-Store\Views\PCCreator\MotherboardCreatorDetails.cshtml"
                               Write(Model.Chipset);

#line default
#line hidden
#nullable disable
            WriteLiteral("</i>\r\n                    </li>\r\n                    <li>\r\n                        <i>Typ gniazda procesora: ");
#nullable restore
#line 57 "C:\Users\Rzepa\Desktop\PC-Store\PC-Store\Views\PCCreator\MotherboardCreatorDetails.cshtml"
                                             Write(Model.SocketType);

#line default
#line hidden
#nullable disable
            WriteLiteral("</i>\r\n                    </li>\r\n                    <li>\r\n                        <i>Technologie: ");
#nullable restore
#line 60 "C:\Users\Rzepa\Desktop\PC-Store\PC-Store\Views\PCCreator\MotherboardCreatorDetails.cshtml"
                                   Write(Model.Technologies);

#line default
#line hidden
#nullable disable
            WriteLiteral("</i>\r\n                    </li>\r\n                    <li>\r\n                        <i>Standard pamięci: ");
#nullable restore
#line 63 "C:\Users\Rzepa\Desktop\PC-Store\PC-Store\Views\PCCreator\MotherboardCreatorDetails.cshtml"
                                        Write(Model.StandardMemory);

#line default
#line hidden
#nullable disable
            WriteLiteral("</i>\r\n                    </li>\r\n                    <li>\r\n                        <i>Rodzaj złącza: ");
#nullable restore
#line 66 "C:\Users\Rzepa\Desktop\PC-Store\PC-Store\Views\PCCreator\MotherboardCreatorDetails.cshtml"
                                     Write(Model.ConnectorType);

#line default
#line hidden
#nullable disable
            WriteLiteral("</i>\r\n                    </li>\r\n                    <li>\r\n                        <i>Ilość slotów pamięci: ");
#nullable restore
#line 69 "C:\Users\Rzepa\Desktop\PC-Store\PC-Store\Views\PCCreator\MotherboardCreatorDetails.cshtml"
                                            Write(Model.NumberOfMemorySlots);

#line default
#line hidden
#nullable disable
            WriteLiteral("</i>\r\n                    </li>\r\n                    <li>\r\n                        <i>Maksymalna ilość pamięci [GB]: ");
#nullable restore
#line 72 "C:\Users\Rzepa\Desktop\PC-Store\PC-Store\Views\PCCreator\MotherboardCreatorDetails.cshtml"
                                                     Write(Model.NumberOfMemorySlots);

#line default
#line hidden
#nullable disable
            WriteLiteral("</i>\r\n                    </li>\r\n                    <li>\r\n                        <i>Architektura wielokanałowa: ");
#nullable restore
#line 75 "C:\Users\Rzepa\Desktop\PC-Store\PC-Store\Views\PCCreator\MotherboardCreatorDetails.cshtml"
                                                  Write(Model.MultiChannelArchitecture);

#line default
#line hidden
#nullable disable
            WriteLiteral("</i>\r\n                    </li>\r\n                    <li>\r\n                        <i>Obsługa zintegrowanych kart graficznych: ");
#nullable restore
#line 78 "C:\Users\Rzepa\Desktop\PC-Store\PC-Store\Views\PCCreator\MotherboardCreatorDetails.cshtml"
                                                               Write(Model.IntegratedGraphicsCardSupport);

#line default
#line hidden
#nullable disable
            WriteLiteral("</i>\r\n                    </li>\r\n                    <li>\r\n                        <i>Chipset graficzny: ");
#nullable restore
#line 81 "C:\Users\Rzepa\Desktop\PC-Store\PC-Store\Views\PCCreator\MotherboardCreatorDetails.cshtml"
                                         Write(Model.GraphicsChipset);

#line default
#line hidden
#nullable disable
            WriteLiteral("</i>\r\n                    </li>\r\n                    <li>\r\n                        <i>Łączenie kart: ");
#nullable restore
#line 84 "C:\Users\Rzepa\Desktop\PC-Store\PC-Store\Views\PCCreator\MotherboardCreatorDetails.cshtml"
                                     Write(Model.CombiningCards);

#line default
#line hidden
#nullable disable
            WriteLiteral("</i>\r\n                    </li>\r\n                    <li>\r\n                        <i>Chipset dźwiękowy: ");
#nullable restore
#line 87 "C:\Users\Rzepa\Desktop\PC-Store\PC-Store\Views\PCCreator\MotherboardCreatorDetails.cshtml"
                                         Write(Model.SoundChipset);

#line default
#line hidden
#nullable disable
            WriteLiteral("</i>\r\n                    </li>\r\n                    <li>\r\n                        <i>Kanały audio: ");
#nullable restore
#line 90 "C:\Users\Rzepa\Desktop\PC-Store\PC-Store\Views\PCCreator\MotherboardCreatorDetails.cshtml"
                                    Write(Model.AudioChannels);

#line default
#line hidden
#nullable disable
            WriteLiteral("</i>\r\n                    </li>\r\n                    <li>\r\n                        <i>Zintegrowana karta sieciowa: ");
#nullable restore
#line 93 "C:\Users\Rzepa\Desktop\PC-Store\PC-Store\Views\PCCreator\MotherboardCreatorDetails.cshtml"
                                                   Write(Model.IntegratedNetworkCard);

#line default
#line hidden
#nullable disable
            WriteLiteral("</i>\r\n                    </li>\r\n                    <li>\r\n                        <i>Chipset karty sieciowej: ");
#nullable restore
#line 96 "C:\Users\Rzepa\Desktop\PC-Store\PC-Store\Views\PCCreator\MotherboardCreatorDetails.cshtml"
                                               Write(Model.NetworkCardChipset);

#line default
#line hidden
#nullable disable
            WriteLiteral("</i>\r\n                    </li>\r\n                    <li>\r\n                        <i>PCI Express x1: ");
#nullable restore
#line 99 "C:\Users\Rzepa\Desktop\PC-Store\PC-Store\Views\PCCreator\MotherboardCreatorDetails.cshtml"
                                      Write(Model.PCIExpressx1);

#line default
#line hidden
#nullable disable
            WriteLiteral("</i>\r\n                    </li>\r\n                    <li>\r\n                        <i>PCI Express x4: ");
#nullable restore
#line 102 "C:\Users\Rzepa\Desktop\PC-Store\PC-Store\Views\PCCreator\MotherboardCreatorDetails.cshtml"
                                      Write(Model.PCIExpressx4);

#line default
#line hidden
#nullable disable
            WriteLiteral("</i>\r\n                    </li>\r\n                    <li>\r\n                        <i>PCI Express x16: ");
#nullable restore
#line 105 "C:\Users\Rzepa\Desktop\PC-Store\PC-Store\Views\PCCreator\MotherboardCreatorDetails.cshtml"
                                       Write(Model.PCIExpressx16);

#line default
#line hidden
#nullable disable
            WriteLiteral("</i>\r\n                    </li>\r\n                </ul>\r\n                <h3><span class=\"mr-1\"><strong>Cena: ");
#nullable restore
#line 108 "C:\Users\Rzepa\Desktop\PC-Store\PC-Store\Views\PCCreator\MotherboardCreatorDetails.cshtml"
                                                Write(Model.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral(" Zł</strong></span></h3>\r\n                <hr>\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3388dd76569dfbd458559570a5eb49e419ffd74f18775", async() => {
                WriteLiteral("\r\n                    <button type=\"button\" class=\"btn btn-primary btn-md mr-1 mb-2\">\r\n                        Dodaj do konfiguracji\r\n                    </button>\r\n                ");
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
#line 110 "C:\Users\Rzepa\Desktop\PC-Store\PC-Store\Views\PCCreator\MotherboardCreatorDetails.cshtml"
                                                                         WriteLiteral(Model.Id);

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
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3388dd76569dfbd458559570a5eb49e419ffd74f21447", async() => {
                WriteLiteral("\r\n            <button type=\"button\" class=\"btn btn-light btn-md mr-1 mb-2\">\r\n                Wróć\r\n            </button>\r\n        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<PC_Store.ViewModels.MotherboardCreatorViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
