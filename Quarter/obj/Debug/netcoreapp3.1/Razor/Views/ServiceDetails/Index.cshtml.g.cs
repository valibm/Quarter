#pragma checksum "C:\Users\Help\Desktop\Code\Quarter\Quarter\Views\ServiceDetails\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1a6ec1aa41f2ab8db9a2a7f9b8649d2687982872"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_ServiceDetails_Index), @"mvc.1.0.view", @"/Views/ServiceDetails/Index.cshtml")]
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
#line 4 "C:\Users\Help\Desktop\Code\Quarter\Quarter\Views\_ViewImports.cshtml"
using Business.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\Help\Desktop\Code\Quarter\Quarter\Views\_ViewImports.cshtml"
using DAL.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\Help\Desktop\Code\Quarter\Quarter\Views\_ViewImports.cshtml"
using System.Globalization;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1a6ec1aa41f2ab8db9a2a7f9b8649d2687982872", @"/Views/ServiceDetails/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b3c87329e30d3d35c91a1473a18914e82b917329", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_ServiceDetails_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ServiceVM>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "home", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("Image"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("image"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "servicedetails", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString("#"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("Banner Image"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"    <!-- BREADCRUMB AREA START -->
    <div class=""ltn__breadcrumb-area text-left bg-overlay-white-30 bg-image ""  data-bs-bg=""./assets/img/bg/14.jpg"">
        <div class=""container"">
            <div class=""row"">
                <div class=""col-lg-12"">
                    <div class=""ltn__breadcrumb-inner"">
                        <h1 class=""page-title"">Service Details</h1>
                        <div class=""ltn__breadcrumb-list"">
                            <ul>
                                <li>");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1a6ec1aa41f2ab8db9a2a7f9b8649d26879828726567", async() => {
                WriteLiteral("<span class=\"ltn__secondary-color\"><i class=\"fas fa-home\"></i></span> Home");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"</li>
                                <li>Property Management</li>
                            </ul>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- BREADCRUMB AREA END -->

    <!-- PAGE DETAILS AREA START (service-details) -->
    <div class=""ltn__page-details-area ltn__service-details-area mb-105"">
        <div class=""container"">
            <div class=""row"">
                <div class=""col-lg-8"">
                    <div class=""ltn__page-details-inner ltn__service-details-inner"">
                        <div class=""ltn__blog-img""> 
");
#nullable restore
#line 29 "C:\Users\Help\Desktop\Code\Quarter\Quarter\Views\ServiceDetails\Index.cshtml"
                             foreach (var serviceImage in Model.Service.ServiceImages)
                           {
                               if (serviceImage.Image.ForHeader == true)
                               {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                   ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "1a6ec1aa41f2ab8db9a2a7f9b8649d26879828729106", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 1572, "~/Assets/Uploads/Images/", 1572, 24, true);
#nullable restore
#line 33 "C:\Users\Help\Desktop\Code\Quarter\Quarter\Views\ServiceDetails\Index.cshtml"
AddHtmlAttributeValue("", 1596, serviceImage.Image.Name, 1596, 24, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 34 "C:\Users\Help\Desktop\Code\Quarter\Quarter\Views\ServiceDetails\Index.cshtml"
                               }
                           }

#line default
#line hidden
#nullable disable
            WriteLiteral("                        </div>\r\n                        <p> <span class=\"ltn__first-letter\">L</span>");
#nullable restore
#line 37 "C:\Users\Help\Desktop\Code\Quarter\Quarter\Views\ServiceDetails\Index.cshtml"
                                                               Write(Model.Service.Content);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                        <div class=\"row\">\r\n");
#nullable restore
#line 39 "C:\Users\Help\Desktop\Code\Quarter\Quarter\Views\ServiceDetails\Index.cshtml"
                             foreach (var serviceImage in Model.Service.ServiceImages)
                           {
                               if (serviceImage.Image.ForGallery == true)
                               {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                   <div class=\"col-lg-6\">\r\n                                       ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "1a6ec1aa41f2ab8db9a2a7f9b8649d268798287211908", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 2206, "~/Assets/Uploads/Images/", 2206, 24, true);
#nullable restore
#line 44 "C:\Users\Help\Desktop\Code\Quarter\Quarter\Views\ServiceDetails\Index.cshtml"
AddHtmlAttributeValue("", 2230, serviceImage.Image.Name, 2230, 24, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                   </div>\r\n");
#nullable restore
#line 46 "C:\Users\Help\Desktop\Code\Quarter\Quarter\Views\ServiceDetails\Index.cshtml"
                               }
                           }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                        </div>
                        <div class=""ltn__service-list-menu text-uppercase mt-50 d-none"">
                            <ul>
                                <li><i class=""fas fa-car""></i> Front Brakes Repair <span class=""service-price"">$225.95 <span>Plus Parts</span></span> </li>
                                <li><i class=""fas fa-life-ring""></i> Rear Brakes Repair <span class=""service-price"">$225.95 <span>Plus Parts</span></span> </li>
                                <li><i class=""fas fa-cog""></i> Axle <span class=""service-price"">$225.95 <span>Plus Parts</span></span> </li>
                                <li><i class=""fas fa-car""></i> Starters / Alternators <span class=""service-price"">$225.95 <span>Plus Parts</span></span> </li>
                            </ul>
                        </div>

                    </div>
                </div>
                <div class=""col-lg-4"">
                    <aside class=""sidebar-area ltn__right-sidebar"">
                 ");
            WriteLiteral("       <!-- Menu Widget -->\r\n                        <div class=\"widget-2 ltn__menu-widget ltn__menu-widget-2 text-uppercase\">\r\n                            <ul>\r\n");
#nullable restore
#line 65 "C:\Users\Help\Desktop\Code\Quarter\Quarter\Views\ServiceDetails\Index.cshtml"
                                 foreach (var service in Model.AllServices)
                               {
                                   if (service.Title == Model.Service.Title)
                                   {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                       <li class=\"active\">");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1a6ec1aa41f2ab8db9a2a7f9b8649d268798287215520", async() => {
#nullable restore
#line 69 "C:\Users\Help\Desktop\Code\Quarter\Quarter\Views\ServiceDetails\Index.cshtml"
                                                                                                                                      Write(service.Title);

#line default
#line hidden
#nullable disable
                WriteLiteral(" <span><i class=\"fas fa-arrow-right\"></i></span>");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 69 "C:\Users\Help\Desktop\Code\Quarter\Quarter\Views\ServiceDetails\Index.cshtml"
                                                                                                                  WriteLiteral(service.Id);

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
            WriteLiteral("</li>\r\n");
#nullable restore
#line 70 "C:\Users\Help\Desktop\Code\Quarter\Quarter\Views\ServiceDetails\Index.cshtml"
                                   }
                                   else
                                   {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                       <li>");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1a6ec1aa41f2ab8db9a2a7f9b8649d268798287218664", async() => {
#nullable restore
#line 73 "C:\Users\Help\Desktop\Code\Quarter\Quarter\Views\ServiceDetails\Index.cshtml"
                                                                                                                       Write(service.Title);

#line default
#line hidden
#nullable disable
                WriteLiteral(" <span><i class=\"fas fa-arrow-right\"></i></span>");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 73 "C:\Users\Help\Desktop\Code\Quarter\Quarter\Views\ServiceDetails\Index.cshtml"
                                                                                                   WriteLiteral(service.Id);

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
            WriteLiteral("</li>\r\n");
#nullable restore
#line 74 "C:\Users\Help\Desktop\Code\Quarter\Quarter\Views\ServiceDetails\Index.cshtml"
                                   }
                               }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                            </ul>
                        </div>
                        <!-- Newsletter Widget -->
                        <div class=""widget ltn__search-widget ltn__newsletter-widget"">                            
                            <h6 class=""ltn__widget-sub-title"">// subscribe</h6>
                            <h4 class=""ltn__widget-title"">Get Newsletter</h4>
                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1a6ec1aa41f2ab8db9a2a7f9b8649d268798287222120", async() => {
                WriteLiteral("\r\n                                <input type=\"text\" name=\"search\" placeholder=\"Search\">\r\n                                <button type=\"submit\"><i class=\"fas fa-search\"></i></button>\r\n                            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                            <div class=""ltn__newsletter-bg-icon"">
                                <i class=""fas fa-envelope-open-text""></i>
                            </div>
                        </div>
                        <!-- Banner Widget -->
                        <div class=""widget ltn__banner-widget"">
");
#nullable restore
#line 92 "C:\Users\Help\Desktop\Code\Quarter\Quarter\Views\ServiceDetails\Index.cshtml"
                             foreach (var serviceImage in Model.Service.ServiceImages)
                           {
                               if (serviceImage.Image.ForBanner == true)
                               {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                   <a href=\"shop.html\">");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "1a6ec1aa41f2ab8db9a2a7f9b8649d268798287224459", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 5663, "~/Assets/Uploads/Images/", 5663, 24, true);
#nullable restore
#line 96 "C:\Users\Help\Desktop\Code\Quarter\Quarter\Views\ServiceDetails\Index.cshtml"
AddHtmlAttributeValue("", 5687, serviceImage.Image.Name, 5687, 24, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</a>\r\n");
#nullable restore
#line 97 "C:\Users\Help\Desktop\Code\Quarter\Quarter\Views\ServiceDetails\Index.cshtml"
                               }
                           }

#line default
#line hidden
#nullable disable
            WriteLiteral("                        </div>\r\n                    </aside>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n    <!-- PAGE DETAILS AREA END -->\r\n");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ServiceVM> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
