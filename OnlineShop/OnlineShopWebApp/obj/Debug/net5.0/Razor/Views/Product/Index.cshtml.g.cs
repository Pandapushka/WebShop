#pragma checksum "C:\Users\andre\OneDrive\Рабочий стол\OnlineShop_Asp.Net Core\OnlineShop\OnlineShopWebApp\Views\Product\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4a8ebbcd26b130e9220fb20594f1b65aa4f1ee28"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Product_Index), @"mvc.1.0.view", @"/Views/Product/Index.cshtml")]
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
#nullable restore
#line 1 "C:\Users\andre\OneDrive\Рабочий стол\OnlineShop_Asp.Net Core\OnlineShop\OnlineShopWebApp\Views\Product\Index.cshtml"
using OnlineShopWebApp.Areas.Admin.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4a8ebbcd26b130e9220fb20594f1b65aa4f1ee28", @"/Views/Product/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cf10c2d220a227317f4e18ef5f3e3052b096db51", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Product_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ProductViewModel>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "C:\Users\andre\OneDrive\Рабочий стол\OnlineShop_Asp.Net Core\OnlineShop\OnlineShopWebApp\Views\Product\Index.cshtml"
 if (Model == null)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("\t<div>Такого товара нет!</div>\r\n");
#nullable restore
#line 6 "C:\Users\andre\OneDrive\Рабочий стол\OnlineShop_Asp.Net Core\OnlineShop\OnlineShopWebApp\Views\Product\Index.cshtml"
}
else
{

#line default
#line hidden
#nullable disable
            WriteLiteral("\t<div class=\"row\">\r\n\t\t<div class=\"col-6\">\r\n\t\t\t<img class=\"card-img-top\"");
            BeginWriteAttribute("src", " src=\"", 208, "\"", 230, 1);
#nullable restore
#line 11 "C:\Users\andre\OneDrive\Рабочий стол\OnlineShop_Asp.Net Core\OnlineShop\OnlineShopWebApp\Views\Product\Index.cshtml"
WriteAttributeValue("", 214, Model.ImagePath, 214, 16, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n\t\t</div>\r\n\t\t<div class=\"col-6\">\r\n\t\t\t<div class=\"card-body\">\r\n\t\t\t\t<h5 class=\"text-center text-secondary\">");
#nullable restore
#line 15 "C:\Users\andre\OneDrive\Рабочий стол\OnlineShop_Asp.Net Core\OnlineShop\OnlineShopWebApp\Views\Product\Index.cshtml"
                                                  Write(Model.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n\t\t\t\t<h5>");
#nullable restore
#line 16 "C:\Users\andre\OneDrive\Рабочий стол\OnlineShop_Asp.Net Core\OnlineShop\OnlineShopWebApp\Views\Product\Index.cshtml"
               Write(Model.Cost);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n\t\t\t\t<h5>");
#nullable restore
#line 17 "C:\Users\andre\OneDrive\Рабочий стол\OnlineShop_Asp.Net Core\OnlineShop\OnlineShopWebApp\Views\Product\Index.cshtml"
               Write(Model.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n\t\t\t</div>\r\n\t\t\t<div class=\"footer\">\r\n\t\t\t\t<a class=\"btn  btn-secondary button_color mr-2 btn-lg btn-block\"");
            BeginWriteAttribute("href", " href=\"", 519, "\"", 545, 2);
            WriteAttributeValue("", 526, "/cart/add/", 526, 10, true);
#nullable restore
#line 20 "C:\Users\andre\OneDrive\Рабочий стол\OnlineShop_Asp.Net Core\OnlineShop\OnlineShopWebApp\Views\Product\Index.cshtml"
WriteAttributeValue("", 536, Model.Id, 536, 9, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" role=\"button\">\r\n\t\t\t\t\t<h6 class=\"text-white font-weight-light\">Добавить в корзину</h6>\r\n\t\t\t\t</a>\r\n\t\t\t\t<a class=\"btn  btn-secondary mr-2 btn-lg btn-block\" href=\"/home/index\" role=\"button\">Продолжить покупки</a>\r\n\t\t\t</div>\r\n\t\t</div>\r\n\t</div>\r\n");
#nullable restore
#line 27 "C:\Users\andre\OneDrive\Рабочий стол\OnlineShop_Asp.Net Core\OnlineShop\OnlineShopWebApp\Views\Product\Index.cshtml"
}

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ProductViewModel> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
