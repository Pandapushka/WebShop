#pragma checksum "C:\Users\andre\OneDrive\Рабочий стол\OnlineShop_Asp.Net Core\OnlineShop\OnlineShopWebApp\Views\Order\Success.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "053e9f35866fb0c6e03c1c047a75da662c93b721"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Order_Success), @"mvc.1.0.view", @"/Views/Order/Success.cshtml")]
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
#line 1 "C:\Users\andre\OneDrive\Рабочий стол\OnlineShop_Asp.Net Core\OnlineShop\OnlineShopWebApp\Views\_ViewImports.cshtml"
using OnlineShopWebApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\andre\OneDrive\Рабочий стол\OnlineShop_Asp.Net Core\OnlineShop\OnlineShopWebApp\Views\_ViewImports.cshtml"
using OnlineShopWebApp.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\andre\OneDrive\Рабочий стол\OnlineShop_Asp.Net Core\OnlineShop\OnlineShopWebApp\Views\_ViewImports.cshtml"
using OnlineShop.Db;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\andre\OneDrive\Рабочий стол\OnlineShop_Asp.Net Core\OnlineShop\OnlineShopWebApp\Views\_ViewImports.cshtml"
using OnlineShopWebApp.Helpers;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"053e9f35866fb0c6e03c1c047a75da662c93b721", @"/Views/Order/Success.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cf10c2d220a227317f4e18ef5f3e3052b096db51", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Order_Success : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<OrderVM>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<div class=\"text-center\">\r\n    <h4>");
#nullable restore
#line 4 "C:\Users\andre\OneDrive\Рабочий стол\OnlineShop_Asp.Net Core\OnlineShop\OnlineShopWebApp\Views\Order\Success.cshtml"
   Write(Model.UserOrder.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(", ваш заказ успешно создан!</h4>\r\n</div>\r\n<div class=\"text-center\">\r\n    <a class=\"btn btn-outline-secondary btn-lg\" href=\"/home/index\" role=\"button\">На главную</a>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<OrderVM> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
