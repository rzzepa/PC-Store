#pragma checksum "C:\Users\Rzepa\Desktop\PC-Store\PC-Store\Views\Home\ProcessorList.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "30471d82260928fd991904cf8225749e66af44ad"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_ProcessorList), @"mvc.1.0.view", @"/Views/Home/ProcessorList.cshtml")]
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
#nullable restore
#line 3 "C:\Users\Rzepa\Desktop\PC-Store\PC-Store\Views\Home\ProcessorList.cshtml"
using X.PagedList.Mvc.Core;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\Rzepa\Desktop\PC-Store\PC-Store\Views\Home\ProcessorList.cshtml"
using X.PagedList;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"30471d82260928fd991904cf8225749e66af44ad", @"/Views/Home/ProcessorList.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9b0c1d3f87b12c65acf0f22202cba3e956ad6ac5", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_ProcessorList : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<PC_Store.Models.Processor>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-success"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "ShoppingCart", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "AddtoShoppingCart", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            WriteLiteral("\r\n");
#nullable restore
#line 6 "C:\Users\Rzepa\Desktop\PC-Store\PC-Store\Views\Home\ProcessorList.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n\r\n");
#nullable restore
#line 12 "C:\Users\Rzepa\Desktop\PC-Store\PC-Store\Views\Home\ProcessorList.cshtml"
 using (Html.BeginForm())
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <p>\r\n        Wpisz czego szukasz: ");
#nullable restore
#line 15 "C:\Users\Rzepa\Desktop\PC-Store\PC-Store\Views\Home\ProcessorList.cshtml"
                        Write(Html.TextBox("SearchString", null, new { @class = "form-control mr-sm-1", @type = "search"}));

#line default
#line hidden
#nullable disable
            WriteLiteral("<br/>\r\n        <input class=\"btn btn-outline-success my-2 my-sm-0\" type=\"submit\" value=\"Szukaj\" />\r\n    </p>\r\n");
#nullable restore
#line 18 "C:\Users\Rzepa\Desktop\PC-Store\PC-Store\Views\Home\ProcessorList.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 20 "C:\Users\Rzepa\Desktop\PC-Store\PC-Store\Views\Home\ProcessorList.cshtml"
Write(Html.PagedListPager((IPagedList)Model, page => Url.Action("ProcessorList", new { page = page, SearchString="", sortOrder = ViewBag.NameSortParam }),
    new X.PagedList.Mvc.Common.PagedListRenderOptions
    {
        DisplayItemSliceAndTotal = true,
        ContainerDivClasses = new[] { "navigation" },
        LiElementClasses = new[] { "page-item" },
        PageClasses = new[] { "page-link" },
    }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n");
#nullable restore
#line 33 "C:\Users\Rzepa\Desktop\PC-Store\PC-Store\Views\Home\ProcessorList.cshtml"
                 if (ViewBag.NameSortParam == "producerASC")
                {
                    

#line default
#line hidden
#nullable disable
#nullable restore
#line 35 "C:\Users\Rzepa\Desktop\PC-Store\PC-Store\Views\Home\ProcessorList.cshtml"
               Write(Html.ActionLink("Producent", "ProcessorList", new { sortOrder = "producerASC" }));

#line default
#line hidden
#nullable disable
#nullable restore
#line 35 "C:\Users\Rzepa\Desktop\PC-Store\PC-Store\Views\Home\ProcessorList.cshtml"
                                                                                                     
                }
                else
                {
                    

#line default
#line hidden
#nullable disable
#nullable restore
#line 39 "C:\Users\Rzepa\Desktop\PC-Store\PC-Store\Views\Home\ProcessorList.cshtml"
               Write(Html.ActionLink("Producent", "ProcessorList", new { sortOrder = "producerDESC" }));

#line default
#line hidden
#nullable disable
#nullable restore
#line 39 "C:\Users\Rzepa\Desktop\PC-Store\PC-Store\Views\Home\ProcessorList.cshtml"
                                                                                                      
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n");
#nullable restore
#line 44 "C:\Users\Rzepa\Desktop\PC-Store\PC-Store\Views\Home\ProcessorList.cshtml"
                 if (ViewBag.NameSortParam == "lineASC")
                {
                    

#line default
#line hidden
#nullable disable
#nullable restore
#line 46 "C:\Users\Rzepa\Desktop\PC-Store\PC-Store\Views\Home\ProcessorList.cshtml"
               Write(Html.ActionLink("Linnia", "ProcessorList", new { sortOrder = "lineASC" }));

#line default
#line hidden
#nullable disable
#nullable restore
#line 46 "C:\Users\Rzepa\Desktop\PC-Store\PC-Store\Views\Home\ProcessorList.cshtml"
                                                                                              
                }
                else
                {
                    

#line default
#line hidden
#nullable disable
#nullable restore
#line 50 "C:\Users\Rzepa\Desktop\PC-Store\PC-Store\Views\Home\ProcessorList.cshtml"
               Write(Html.ActionLink("Linnia", "ProcessorList", new { sortOrder = "lineDESC" }));

#line default
#line hidden
#nullable disable
#nullable restore
#line 50 "C:\Users\Rzepa\Desktop\PC-Store\PC-Store\Views\Home\ProcessorList.cshtml"
                                                                                               
                }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
            </th>
            <th>
                Chłodzenie
            </th>
            <th>
                Socket
            </th>
            <th>
                Ilość rdzeni
            </th>
            <th>
                Ilość wątków
            </th>
            <th>
                Częstotliwość taktowania procesora [GHz]
            </th>
            <th>
                Częstotliwość maksymalna Turbo [GHz]
            </th>
            <th>
                Zintegrowany układ graficzny
            </th>
            <th>
                Odblokowany mnożnik
            </th>
            <th>
                Architektura [bit]
            </th>
            <th>
                Rodzaje obsługiwanej pamięci
            </th>
            <th></th>
        </tr>
    </thead>
    <tbody>
");
#nullable restore
#line 88 "C:\Users\Rzepa\Desktop\PC-Store\PC-Store\Views\Home\ProcessorList.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr> \r\n            <td>\r\n                ");
#nullable restore
#line 92 "C:\Users\Rzepa\Desktop\PC-Store\PC-Store\Views\Home\ProcessorList.cshtml"
           Write(Html.DisplayFor(modelItem => item.Producer));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 95 "C:\Users\Rzepa\Desktop\PC-Store\PC-Store\Views\Home\ProcessorList.cshtml"
           Write(Html.DisplayFor(modelItem => item.Line));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 98 "C:\Users\Rzepa\Desktop\PC-Store\PC-Store\Views\Home\ProcessorList.cshtml"
           Write(Html.DisplayFor(modelItem => item.Cooling));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 101 "C:\Users\Rzepa\Desktop\PC-Store\PC-Store\Views\Home\ProcessorList.cshtml"
           Write(Html.DisplayFor(modelItem => item.SocketType));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 104 "C:\Users\Rzepa\Desktop\PC-Store\PC-Store\Views\Home\ProcessorList.cshtml"
           Write(Html.DisplayFor(modelItem => item.NumberOfCores));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 107 "C:\Users\Rzepa\Desktop\PC-Store\PC-Store\Views\Home\ProcessorList.cshtml"
           Write(Html.DisplayFor(modelItem => item.NumberOfThreads));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 110 "C:\Users\Rzepa\Desktop\PC-Store\PC-Store\Views\Home\ProcessorList.cshtml"
           Write(Html.DisplayFor(modelItem => item.ProcessorClockFrequency));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 113 "C:\Users\Rzepa\Desktop\PC-Store\PC-Store\Views\Home\ProcessorList.cshtml"
           Write(Html.DisplayFor(modelItem => item.TurboMaximumFrequency));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 116 "C:\Users\Rzepa\Desktop\PC-Store\PC-Store\Views\Home\ProcessorList.cshtml"
           Write(Html.DisplayFor(modelItem => item.IntegratedGraphics));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 119 "C:\Users\Rzepa\Desktop\PC-Store\PC-Store\Views\Home\ProcessorList.cshtml"
           Write(Html.DisplayFor(modelItem => item.UnlockedMultiplier));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 122 "C:\Users\Rzepa\Desktop\PC-Store\PC-Store\Views\Home\ProcessorList.cshtml"
           Write(Html.DisplayFor(modelItem => item.Architecture));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 125 "C:\Users\Rzepa\Desktop\PC-Store\PC-Store\Views\Home\ProcessorList.cshtml"
           Write(Html.DisplayFor(modelItem => item.TypesOfSupportedMemory));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "30471d82260928fd991904cf8225749e66af44ad14242", async() => {
                WriteLiteral("Dodaj do koszyka");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 128 "C:\Users\Rzepa\Desktop\PC-Store\PC-Store\Views\Home\ProcessorList.cshtml"
                                                                                                          WriteLiteral(item.ProductId);

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
            WriteLiteral("\r\n            </td>\r\n        </tr>\r\n");
#nullable restore
#line 131 "C:\Users\Rzepa\Desktop\PC-Store\PC-Store\Views\Home\ProcessorList.cshtml"

        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n<br />\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n    <script>\r\n        $(document).ready(function () {\r\n            $(\'ul.pagination > li.disabled > a\').addClass(\'page-link\');\r\n        });\r\n    </script>\r\n");
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<PC_Store.Models.Processor>> Html { get; private set; }
    }
}
#pragma warning restore 1591
