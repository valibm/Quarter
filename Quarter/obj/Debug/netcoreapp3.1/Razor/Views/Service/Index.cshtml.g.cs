#pragma checksum "C:\Users\Help\Desktop\Code\Quarter\Quarter\Views\Service\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a8ce9c59a1ae72386ae5ef5eeabb464c67c1ceb4"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Service_Index), @"mvc.1.0.view", @"/Views/Service/Index.cshtml")]
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
#nullable restore
#line 7 "C:\Users\Help\Desktop\Code\Quarter\Quarter\Views\_ViewImports.cshtml"
using DAL.Identity;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a8ce9c59a1ae72386ae5ef5eeabb464c67c1ceb4", @"/Views/Service/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"29e0c556fe33c3aa0dbe057a7a111cd32abe66a7", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Service_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Service>>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "home", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/assets/img/service/11.jpg"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("Image"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("Service Image"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "servicedetails", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/assets/img/blog/1.jpg"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("#"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/assets/img/blog/2.jpg"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_9 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/assets/img/blog/3.jpg"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_10 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/assets/img/blog/4.jpg"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_11 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/assets/img/blog/5.jpg"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"
<!-- BREADCRUMB AREA START -->
    <div class=""ltn__breadcrumb-area text-left bg-overlay-white-30 bg-image ""  data-bs-bg=""./assets/img/bg/14.jpg"">
        <div class=""container"">
            <div class=""row"">
                <div class=""col-lg-12"">
                    <div class=""ltn__breadcrumb-inner"">
                        <h1 class=""page-title"">What We Do</h1>
                        <div class=""ltn__breadcrumb-list"">
                            <ul>
                                <li>");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a8ce9c59a1ae72386ae5ef5eeabb464c67c1ceb48244", async() => {
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
                                <li>Service</li>
                            </ul>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- BREADCRUMB AREA END -->

    <!-- ABOUT US AREA START -->
    <div class=""ltn__about-us-area pb-115"">
        <div class=""container"">
            <div class=""row"">
                <div class=""col-lg-5 align-self-center"">
                    <div class=""about-us-img-wrap ltn__img-shape-left  about-img-left"">
                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "a8ce9c59a1ae72386ae5ef5eeabb464c67c1ceb410258", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                    </div>
                </div>
                <div class=""col-lg-7 align-self-center"">
                    <div class=""about-us-info-wrap"">
                        <div class=""section-title-area ltn__section-title-2--- mb-20"">
                            <h6 class=""section-subtitle section-subtitle-2 ltn__secondary-color"">About Us</h6>
                            <h1 class=""section-title"">The Leading Real Estate
                                Rental Marketplace<span>.</span></h1>
                            <p>Over 39,000 people work for us in more than 70 countries all over the
                                This breadth of global coverage, combined with specialist services</p>
                        </div>
                        <div class=""about-us-info-wrap-inner about-us-info-devide---"">
                            <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, qu");
            WriteLiteral(@"is nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur.</p>
                        </div>
                        <div class=""btn-wrapper animated"">
                            <a href=""about.html"" class=""theme-btn-1 btn btn-effect-1 text-uppercase"">About Us</a>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- ABOUT US AREA END -->

    <!-- SERVICE AREA START (Service 1) -->
    <div class=""ltn__service-area section-bg-1 pt-115 pb-70"">
        <div class=""container"">
            <div class=""row"">
                <div class=""col-lg-12"">
                    <div class=""section-title-area ltn__section-title-2--- text-center"">
                        <h6 class=""section-subtitle section-subtitle-2 ltn__secondary-color"">Our Services</h6>
                        <h1 class=""section-titl");
            WriteLiteral("e\">Our Core Services</h1>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n");
#nullable restore
#line 65 "C:\Users\Help\Desktop\Code\Quarter\Quarter\Views\Service\Index.cshtml"
             foreach (var service in Model)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                <div class=""row  justify-content-center"">
                <div class=""col-lg-4 col-sm-6 col-12"">
                    <div class=""ltn__feature-item ltn__feature-item-6 text-center bg-white  box-shadow-1"">
                        <div class=""ltn__feature-icon"">
");
#nullable restore
#line 71 "C:\Users\Help\Desktop\Code\Quarter\Quarter\Views\Service\Index.cshtml"
                             foreach (var serviceImage in service.ServiceImages)
                           {
                               if (serviceImage.Image.ForCard == true)
                               {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                   ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "a8ce9c59a1ae72386ae5ef5eeabb464c67c1ceb414586", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 4026, "~/Assets/Uploads/Images/", 4026, 24, true);
#nullable restore
#line 75 "C:\Users\Help\Desktop\Code\Quarter\Quarter\Views\Service\Index.cshtml"
AddHtmlAttributeValue("", 4050, serviceImage.Image.Name, 4050, 24, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 76 "C:\Users\Help\Desktop\Code\Quarter\Quarter\Views\Service\Index.cshtml"
                               }
                           }

#line default
#line hidden
#nullable disable
            WriteLiteral("                        </div>\r\n                        <div class=\"ltn__feature-info\">\r\n                            <h3>");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a8ce9c59a1ae72386ae5ef5eeabb464c67c1ceb416542", async() => {
#nullable restore
#line 80 "C:\Users\Help\Desktop\Code\Quarter\Quarter\Views\Service\Index.cshtml"
                                                                                                            Write(service.Title);

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 80 "C:\Users\Help\Desktop\Code\Quarter\Quarter\Views\Service\Index.cshtml"
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
            WriteLiteral("</h3>\r\n                            <p>");
#nullable restore
#line 81 "C:\Users\Help\Desktop\Code\Quarter\Quarter\Views\Service\Index.cshtml"
                          Write(service.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</p>
                            <!-- <a class=""ltn__service-btn"" href=""service-details.html"">Find A Home <i class=""flaticon-right-arrow""></i></a> -->
                        </div>
                    </div>
                </div>
            </div>
");
#nullable restore
#line 87 "C:\Users\Help\Desktop\Code\Quarter\Quarter\Views\Service\Index.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"        </div>
    </div>
    <!-- SERVICE AREA END -->

    <!-- BLOG AREA START (blog-3) -->
    <div class=""ltn__blog-area pt-120 pb-70"">
        <div class=""container"">
            <div class=""row"">
                <div class=""col-lg-12"">
                    <div class=""section-title-area ltn__section-title-2--- text-center"">
                        <h6 class=""section-subtitle section-subtitle-2 ltn__secondary-color"">News & Blogs</h6>
                        <h1 class=""section-title"">Leatest News Feeds</h1>
                    </div>
                </div>
            </div>
            <div class=""row  ltn__blog-slider-one-active slick-arrow-1 ltn__blog-item-3-normal"">
                <!-- Blog Item -->
                <div class=""col-lg-12"">
                    <div class=""ltn__blog-item ltn__blog-item-3"">
                        <div class=""ltn__blog-img"">
                            <a href=""blog-details.html"">");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "a8ce9c59a1ae72386ae5ef5eeabb464c67c1ceb420892", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"</a>
                        </div>
                        <div class=""ltn__blog-brief"">
                            <div class=""ltn__blog-meta"">
                                <ul>
                                    <li class=""ltn__blog-author"">
                                        <a href=""#""><i class=""far fa-user""></i>by: Admin</a>
                                    </li>
                                    <li class=""ltn__blog-tags"">
                                        <a href=""#""><i class=""fas fa-tags""></i>Decorate</a>
                                    </li>
                                </ul>
                            </div>
                            <h3 class=""ltn__blog-title""><a href=""blog-details.html"">10 Brilliant Ways To Decorate Your Home</a></h3>
                            <div class=""ltn__blog-meta-btn"">
                                <div class=""ltn__blog-meta"">
                                    <ul>
                                        <li class=""ltn_");
            WriteLiteral(@"_blog-date""><i class=""far fa-calendar-alt""></i>June 24, 2021</li>
                                    </ul>
                                </div>
                                <div class=""ltn__blog-btn"">
                                    <a href=""blog-details.html"">Read more</a>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <!-- Blog Item -->
                <div class=""col-lg-12"">
                    <div class=""ltn__blog-item ltn__blog-item-3"">
                        <div class=""ltn__blog-img"">
                            <a href=""blog-details.html"">");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "a8ce9c59a1ae72386ae5ef5eeabb464c67c1ceb423803", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_8);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"</a>
                        </div>
                        <div class=""ltn__blog-brief"">
                            <div class=""ltn__blog-meta"">
                                <ul>
                                    <li class=""ltn__blog-author"">
                                        <a href=""#""><i class=""far fa-user""></i>by: Admin</a>
                                    </li>
                                    <li class=""ltn__blog-tags"">
                                        <a href=""#""><i class=""fas fa-tags""></i>Interior</a>
                                    </li>
                                </ul>
                            </div>
                            <h3 class=""ltn__blog-title""><a href=""blog-details.html"">The Most Inspiring Interior Design Of 2021</a></h3>
                            <div class=""ltn__blog-meta-btn"">
                                <div class=""ltn__blog-meta"">
                                    <ul>
                                        <li class=""l");
            WriteLiteral(@"tn__blog-date""><i class=""far fa-calendar-alt""></i>July 23, 2021</li>
                                    </ul>
                                </div>
                                <div class=""ltn__blog-btn"">
                                    <a href=""blog-details.html"">Read more</a>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <!-- Blog Item -->
                <div class=""col-lg-12"">
                    <div class=""ltn__blog-item ltn__blog-item-3"">
                        <div class=""ltn__blog-img"">
                            <a href=""blog-details.html"">");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "a8ce9c59a1ae72386ae5ef5eeabb464c67c1ceb426717", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_9);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"</a>
                        </div>
                        <div class=""ltn__blog-brief"">
                            <div class=""ltn__blog-meta"">
                                <ul>
                                    <li class=""ltn__blog-author"">
                                        <a href=""#""><i class=""far fa-user""></i>by: Admin</a>
                                    </li>
                                    <li class=""ltn__blog-tags"">
                                        <a href=""#""><i class=""fas fa-tags""></i>Estate</a>
                                    </li>
                                </ul>
                            </div>
                            <h3 class=""ltn__blog-title""><a href=""blog-details.html"">Recent Commercial Real Estate Transactions</a></h3>
                            <div class=""ltn__blog-meta-btn"">
                                <div class=""ltn__blog-meta"">
                                    <ul>
                                        <li class=""ltn");
            WriteLiteral(@"__blog-date""><i class=""far fa-calendar-alt""></i>May 22, 2021</li>
                                    </ul>
                                </div>
                                <div class=""ltn__blog-btn"">
                                    <a href=""blog-details.html"">Read more</a>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <!-- Blog Item -->
                <div class=""col-lg-12"">
                    <div class=""ltn__blog-item ltn__blog-item-3"">
                        <div class=""ltn__blog-img"">
                            <a href=""blog-details.html"">");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "a8ce9c59a1ae72386ae5ef5eeabb464c67c1ceb429628", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_10);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"</a>
                        </div>
                        <div class=""ltn__blog-brief"">
                            <div class=""ltn__blog-meta"">
                                <ul>
                                    <li class=""ltn__blog-author"">
                                        <a href=""#""><i class=""far fa-user""></i>by: Admin</a>
                                    </li>
                                    <li class=""ltn__blog-tags"">
                                        <a href=""#""><i class=""fas fa-tags""></i>Room</a>
                                    </li>
                                </ul>
                            </div>
                            <h3 class=""ltn__blog-title""><a href=""blog-details.html"">Renovating a Living Room? Experts Share Their Secrets</a></h3>
                            <div class=""ltn__blog-meta-btn"">
                                <div class=""ltn__blog-meta"">
                                    <ul>
                                        <li c");
            WriteLiteral(@"lass=""ltn__blog-date""><i class=""far fa-calendar-alt""></i>June 24, 2021</li>
                                    </ul>
                                </div>
                                <div class=""ltn__blog-btn"">
                                    <a href=""blog-details.html"">Read more</a>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <!-- Blog Item -->
                <div class=""col-lg-12"">
                    <div class=""ltn__blog-item ltn__blog-item-3"">
                        <div class=""ltn__blog-img"">
                            <a href=""blog-details.html"">");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "a8ce9c59a1ae72386ae5ef5eeabb464c67c1ceb432550", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_11);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"</a>
                        </div>
                        <div class=""ltn__blog-brief"">
                            <div class=""ltn__blog-meta"">
                                <ul>
                                    <li class=""ltn__blog-author"">
                                        <a href=""#""><i class=""far fa-user""></i>by: Admin</a>
                                    </li>
                                    <li class=""ltn__blog-tags"">
                                        <a href=""#""><i class=""fas fa-tags""></i>Trends</a>
                                    </li>
                                </ul>
                            </div>
                            <h3 class=""ltn__blog-title""><a href=""blog-details.html"">7 home trends that will shape your house in 2021</a></h3>
                            <div class=""ltn__blog-meta-btn"">
                                <div class=""ltn__blog-meta"">
                                    <ul>
                                        <li clas");
            WriteLiteral(@"s=""ltn__blog-date""><i class=""far fa-calendar-alt""></i>June 24, 2021</li>
                                    </ul>
                                </div>
                                <div class=""ltn__blog-btn"">
                                    <a href=""blog-details.html"">Read more</a>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <!--  -->
            </div>
        </div>
    </div>
    <!-- BLOG AREA END -->");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Service>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
