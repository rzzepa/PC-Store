#pragma checksum "C:\Users\Rzepa\Desktop\Projekt\PC-Store\PC-Store\Views\Processors\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2fa0fa29f72cc24d7cde4d1c70f710eba75afb3d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Processors_Index), @"mvc.1.0.view", @"/Views/Processors/Index.cshtml")]
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
#line 1 "C:\Users\Rzepa\Desktop\Projekt\PC-Store\PC-Store\Views\_ViewImports.cshtml"
using PC_Store;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Rzepa\Desktop\Projekt\PC-Store\PC-Store\Views\_ViewImports.cshtml"
using PC_Store.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2fa0fa29f72cc24d7cde4d1c70f710eba75afb3d", @"/Views/Processors/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cf08238f59834d4f0d04305bdd09a1424084fe7d", @"/Views/_ViewImports.cshtml")]
    public class Views_Processors_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<PC_Store.Models.ViewModels.IndexProcessorViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Details", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Delete", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#nullable restore
#line 3 "C:\Users\Rzepa\Desktop\Projekt\PC-Store\PC-Store\Views\Processors\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Index</h1>\r\n\r\n<p>\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2fa0fa29f72cc24d7cde4d1c70f710eba75afb3d4583", async() => {
                WriteLiteral("Create New");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</p>\r\n");
#nullable restore
#line 12 "C:\Users\Rzepa\Desktop\Projekt\PC-Store\PC-Store\Views\Processors\Index.cshtml"
 using (Html.BeginForm())
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <p>\r\n        Find: ");
#nullable restore
#line 15 "C:\Users\Rzepa\Desktop\Projekt\PC-Store\PC-Store\Views\Processors\Index.cshtml"
         Write(Html.TextBox("SearchString"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        <input type=\"submit\" value=\"Search\" />\r\n    </p>\r\n");
#nullable restore
#line 18 "C:\Users\Rzepa\Desktop\Projekt\PC-Store\PC-Store\Views\Processors\Index.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n");
#nullable restore
#line 23 "C:\Users\Rzepa\Desktop\Projekt\PC-Store\PC-Store\Views\Processors\Index.cshtml"
                 if (ViewBag.NameSortParam == "producerASC")
                {
                    

#line default
#line hidden
#nullable disable
#nullable restore
#line 25 "C:\Users\Rzepa\Desktop\Projekt\PC-Store\PC-Store\Views\Processors\Index.cshtml"
               Write(Html.ActionLink("Producent", "Index", new { sortOrder = "producerASC" }));

#line default
#line hidden
#nullable disable
#nullable restore
#line 25 "C:\Users\Rzepa\Desktop\Projekt\PC-Store\PC-Store\Views\Processors\Index.cshtml"
                                                                                             
                }
                else
                {
                    

#line default
#line hidden
#nullable disable
#nullable restore
#line 29 "C:\Users\Rzepa\Desktop\Projekt\PC-Store\PC-Store\Views\Processors\Index.cshtml"
               Write(Html.ActionLink("Producent", "Index", new { sortOrder = "producerDESC" }));

#line default
#line hidden
#nullable disable
#nullable restore
#line 29 "C:\Users\Rzepa\Desktop\Projekt\PC-Store\PC-Store\Views\Processors\Index.cshtml"
                                                                                              
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n");
#nullable restore
#line 34 "C:\Users\Rzepa\Desktop\Projekt\PC-Store\PC-Store\Views\Processors\Index.cshtml"
                 if (ViewBag.NameSortParam == "lineASC")
                {
                    

#line default
#line hidden
#nullable disable
#nullable restore
#line 36 "C:\Users\Rzepa\Desktop\Projekt\PC-Store\PC-Store\Views\Processors\Index.cshtml"
               Write(Html.ActionLink("Linnia", "Index", new { sortOrder = "lineASC" }));

#line default
#line hidden
#nullable disable
#nullable restore
#line 36 "C:\Users\Rzepa\Desktop\Projekt\PC-Store\PC-Store\Views\Processors\Index.cshtml"
                                                                                      
                }
                else
                {
                    

#line default
#line hidden
#nullable disable
#nullable restore
#line 40 "C:\Users\Rzepa\Desktop\Projekt\PC-Store\PC-Store\Views\Processors\Index.cshtml"
               Write(Html.ActionLink("Linnia", "Index", new { sortOrder = "lineDESC" }));

#line default
#line hidden
#nullable disable
#nullable restore
#line 40 "C:\Users\Rzepa\Desktop\Projekt\PC-Store\PC-Store\Views\Processors\Index.cshtml"
                                                                                       
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
#line 78 "C:\Users\Rzepa\Desktop\Projekt\PC-Store\PC-Store\Views\Processors\Index.cshtml"
         foreach (var item in Model.Processors)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td>\r\n                    ");
#nullable restore
#line 82 "C:\Users\Rzepa\Desktop\Projekt\PC-Store\PC-Store\Views\Processors\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.Producer));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 85 "C:\Users\Rzepa\Desktop\Projekt\PC-Store\PC-Store\Views\Processors\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.Line));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 88 "C:\Users\Rzepa\Desktop\Projekt\PC-Store\PC-Store\Views\Processors\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.Cooling));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 91 "C:\Users\Rzepa\Desktop\Projekt\PC-Store\PC-Store\Views\Processors\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.SocketType));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 94 "C:\Users\Rzepa\Desktop\Projekt\PC-Store\PC-Store\Views\Processors\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.NumberOfCores));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 97 "C:\Users\Rzepa\Desktop\Projekt\PC-Store\PC-Store\Views\Processors\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.NumberOfThreads));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 100 "C:\Users\Rzepa\Desktop\Projekt\PC-Store\PC-Store\Views\Processors\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.ProcessorClockFrequency));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 103 "C:\Users\Rzepa\Desktop\Projekt\PC-Store\PC-Store\Views\Processors\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.TurboMaximumFrequency));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 106 "C:\Users\Rzepa\Desktop\Projekt\PC-Store\PC-Store\Views\Processors\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.IntegratedGraphics));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 109 "C:\Users\Rzepa\Desktop\Projekt\PC-Store\PC-Store\Views\Processors\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.UnlockedMultiplier));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 112 "C:\Users\Rzepa\Desktop\Projekt\PC-Store\PC-Store\Views\Processors\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.Architecture));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 115 "C:\Users\Rzepa\Desktop\Projekt\PC-Store\PC-Store\Views\Processors\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.TypesOfSupportedMemory));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2fa0fa29f72cc24d7cde4d1c70f710eba75afb3d14657", async() => {
                WriteLiteral("Edit");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 118 "C:\Users\Rzepa\Desktop\Projekt\PC-Store\PC-Store\Views\Processors\Index.cshtml"
                                           WriteLiteral(item.Id);

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
            WriteLiteral(" |\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2fa0fa29f72cc24d7cde4d1c70f710eba75afb3d16831", async() => {
                WriteLiteral("Details");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 119 "C:\Users\Rzepa\Desktop\Projekt\PC-Store\PC-Store\Views\Processors\Index.cshtml"
                                              WriteLiteral(item.Id);

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
            WriteLiteral(" |\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2fa0fa29f72cc24d7cde4d1c70f710eba75afb3d19011", async() => {
                WriteLiteral("Delete");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 120 "C:\Users\Rzepa\Desktop\Projekt\PC-Store\PC-Store\Views\Processors\Index.cshtml"
                                             WriteLiteral(item.Id);

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
            WriteLiteral("\r\n                </td>\r\n            </tr>\r\n");
#nullable restore
#line 123 "C:\Users\Rzepa\Desktop\Projekt\PC-Store\PC-Store\Views\Processors\Index.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n<br />\r\n\r\n<div");
            BeginWriteAttribute("page-model", " page-model=\"", 3794, "\"", 3824, 1);
#nullable restore
#line 128 "C:\Users\Rzepa\Desktop\Projekt\PC-Store\PC-Store\Views\Processors\Index.cshtml"
WriteAttributeValue("", 3807, Model.PagingInfo, 3807, 17, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" page-action=\"Index\" page- page-classes-enabled=\"true\"\r\n     page-class=\"btn\" page-class-normal=\"btn-secondary\"\r\n     page-class-selected=\"btn-primary\" class=\"btn-group pull-right m-1\">\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<PC_Store.Models.ViewModels.IndexProcessorViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591