#pragma checksum "E:\C#-30day\MCV\ShopCar-pok\ShopCar-pok\ShopCar-pok\Views\Product\List.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f6f7dd279f3ceea88a3adfc54ba9746e2317ca68"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Product_List), @"mvc.1.0.view", @"/Views/Product/List.cshtml")]
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
#line 1 "E:\C#-30day\MCV\ShopCar-pok\ShopCar-pok\ShopCar-pok\Views\_ViewImports.cshtml"
using ShopCar_pok;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\C#-30day\MCV\ShopCar-pok\ShopCar-pok\ShopCar-pok\Views\_ViewImports.cshtml"
using ShopCar_pok.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f6f7dd279f3ceea88a3adfc54ba9746e2317ca68", @"/Views/Product/List.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a10732327a53a273128de45efea637a7e39783c1", @"/Views/_ViewImports.cshtml")]
    public class Views_Product_List : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<ShopCar_pok.Models.ProductCategory>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "E:\C#-30day\MCV\ShopCar-pok\ShopCar-pok\ShopCar-pok\Views\Product\List.cshtml"
  
    ViewData["Title"] = "List";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>List</h1>\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n                ");
#nullable restore
#line 13 "E:\C#-30day\MCV\ShopCar-pok\ShopCar-pok\ShopCar-pok\Views\Product\List.cshtml"
           Write(Html.ActionLink("PriductCategoryID", "List", new{ sortOrder = ViewBag.PriductCategoryID}));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 16 "E:\C#-30day\MCV\ShopCar-pok\ShopCar-pok\ShopCar-pok\Views\Product\List.cshtml"
           Write(Html.ActionLink("Name", "List", new { sortOrder = ViewBag.Name }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n");
            WriteLiteral("            <th></th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 33 "E:\C#-30day\MCV\ShopCar-pok\ShopCar-pok\ShopCar-pok\Views\Product\List.cshtml"
 foreach (var item in Model) {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n            <td>\r\n                ");
#nullable restore
#line 36 "E:\C#-30day\MCV\ShopCar-pok\ShopCar-pok\ShopCar-pok\Views\Product\List.cshtml"
           Write(Html.DisplayFor(modelItem => item.ProductCategoryId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 39 "E:\C#-30day\MCV\ShopCar-pok\ShopCar-pok\ShopCar-pok\Views\Product\List.cshtml"
           Write(Html.DisplayFor(modelItem => item.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n");
            WriteLiteral("            <td>\r\n");
            WriteLiteral("                ");
#nullable restore
#line 54 "E:\C#-30day\MCV\ShopCar-pok\ShopCar-pok\ShopCar-pok\Views\Product\List.cshtml"
           Write(Html.ActionLink("Go ", "Product", new { id = item.ProductCategoryId }, new { @class = "btn btn-info" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            WriteLiteral("            </td>\r\n        </tr>\r\n");
#nullable restore
#line 58 "E:\C#-30day\MCV\ShopCar-pok\ShopCar-pok\ShopCar-pok\Views\Product\List.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<ShopCar_pok.Models.ProductCategory>> Html { get; private set; }
    }
}
#pragma warning restore 1591