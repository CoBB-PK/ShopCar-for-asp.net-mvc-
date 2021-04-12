using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShopCar_pok.Models;
using System.Drawing;
using System.IO;
using System.Text;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;

namespace ShopCar_pok.Controllers
{
    public class LoingInController : Controller
    {
        private readonly AdventureWorksLT2016Context _db;

        public LoingInController(AdventureWorksLT2016Context context) {
            _db = context;
        }

        public IActionResult Loingin() 
        {     
           return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Loingin(Customer customer) {
            if (ModelState.IsValid) //表單驗證
            {
                var ListOne = from m in _db.Customers where m.EmailAddress == customer.EmailAddress && m.LastName == customer.LastName select m;
                Customer _rersult = ListOne.FirstOrDefault();
                if (_rersult == null)
                {
                    ViewData["ErrorMessage"] = "信箱 或 密碼 有誤請重新輸入";
                    return View();
                }
                else {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Email,customer.EmailAddress),
                        new Claim("SF_ID",_rersult.CustomerId.ToString()),
                        new Claim("SelfDefine_LastName",customer.LastName),

                    };
                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var authProperties = new AuthenticationProperties
                    {

                        /* https://docs.microsoft.com/zh-tw/aspnet/core/security/authentication/cookie?view=aspnetcore-5.0 */
                        //AllowRefresh = <bool>,
                        // Refreshing the authentication session should be allowed.

                        ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(5),   // 從現在算起，Cookie何時過期
                        // The time at which the authentication ticket expires. A 
                        // value set here overrides the ExpireTimeSpan option of 
                        // CookieAuthenticationOptions set with AddCookie.

                        //IsPersistent = true,
                        // Whether the authentication session is persisted across 
                        // multiple requests. When used with cookies, controls
                        // whether the cookie's lifetime is absolute (matching the
                        // lifetime of the authentication ticket) or session-based.

                        //IssuedUtc = <DateTimeOffset>,
                        // The time at which the authentication ticket was issued.

                        //RedirectUri = <string>
                        // The full path or absolute URI to be used as an http 
                        // redirect response value.
                    };
                    HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,new ClaimsPrincipal(claimsIdentity),authProperties);

                    //==================================================================================
                    //string str = "";
                    ClaimsPrincipal principal = (ClaimsPrincipal)HttpContext.User;
                    if (null != principal)   {
                        foreach (Claim claim in principal.Claims)   {
                            if (claim.Type == "SelfDefine_LastName") {
                                ViewData["SelfDefine_LastName"] = claim.Value;
                            }
                        }
                    }
                    //return Content(str);
                    //===================================================================================
                    return RedirectToAction("Index", "Home");
                }
            } 


             return View(); 
        }


        public IActionResult Registered() {
            return View();
        }

        public async Task<IActionResult> Logout() {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }

        [Authorize]
        public IActionResult Report() {

            //===========================================================================
            //尋找個別 CustomID 報表分類 但資料庫資料 資料ㄧ樣ㄉ 無法
            //string _ID = "";
            //ClaimsPrincipal principal = (ClaimsPrincipal)HttpContext.User;
            //if (null != principal)
            //{
            //    foreach (Claim claim in principal.Claims)
            //    {
            //        if (claim.Type == "SF_ID")
            //            _ID = claim.Value;
            //        //_ID += "CLAIM TYPE: " + claim.Type + "; CLAIM VALUE: " + claim.Value + "</br>";
            //    }
            //    //return Content(_ID);
            //}
            //else
            //{
            //    return Content("找 不 到 用 戶 ID ~ ~ ~");
            //}
            //=============================================================================
            var RP = from so in _db.SalesOrderHeaders /*where so.CustomerId == Convert.ToInt32(_ID)*/ select new SalesOrderHeader
            {
                SalesOrderId = so.SalesOrderId,
                OrderDate = so.OrderDate,
                SalesOrderNumber = so.SalesOrderNumber,
                PurchaseOrderNumber = so.PurchaseOrderNumber,
                CustomerId = so.CustomerId,
                ShipMethod = so.ShipMethod,
                SalesOrderDetails = so.SalesOrderDetails
            };
            if (RP == null) {
                return Content(" 暫 無 資 料 ");
            }
            else {
                return View(RP.ToList());
            }
            
        }

        [Authorize]
        public IActionResult ProductDetail(int? id) {
            if (id == null) {
                return Content(" 無 資 料 ");
            }
            var PD = from De in _db.SalesOrderHeaders where De.SalesOrderId == id select new SalesOrderHeader
            {
                SalesOrderId = De.SalesOrderId,
                OrderDate = De.OrderDate,
                SalesOrderNumber = De.SalesOrderNumber,
                PurchaseOrderNumber = De.PurchaseOrderNumber,
                CustomerId = De.CustomerId,
                ShipMethod = De.ShipMethod,
                SalesOrderDetails = De.SalesOrderDetails
            }; ;
            return View(PD.FirstOrDefault());
        }
        
        [Authorize]
        public IActionResult ProductDetailEdit(int? id) {

            if (id == null) {
                return Content(" 查 無 資 料 ");
            }
            var PDE = from pde in _db.SalesOrderDetails where pde.SalesOrderDetailId == id select pde;
            return View(PDE.FirstOrDefault());
        }

        /* 
            !!!!!!!!!!!!!!!!!!!!!!!! 2 key 1 Value 待解決 !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
         */ 
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ProductDetailEdit(SalesOrderDetail sod ) {
            if (ModelState.IsValid)
            {

                SalesOrderHeader SOH  = _db.SalesOrderHeaders.Find(sod.SalesOrderId);
                

             //_db.SalesOrderDetails.Find();
            /*    if (SalesOrderDetail == null)
                {
                    return Content(" 目 前 找 無 資 料 "+sod.SalesOrderDetailId +sod.SalesOrderId);
                }
                else
                {
                    SalesOrderDetail.OrderQty = sod.OrderQty;
                    SalesOrderDetail.UnitPrice = sod.UnitPrice;
                    SalesOrderDetail.LineTotal = sod.OrderQty * sod.UnitPrice;
                    _db.SaveChanges();
                    return RedirectToAction("ProductDetail", "LoingIn");
                }*/
            }
            else {
                ModelState.AddModelError("Value1", "自 訂 錯 誤 訊 息 (1)");
                return View();
            }
            return View();
        }

        [Authorize]
        public IActionResult Creat() {
            string _ID = "";
            ClaimsPrincipal principal = (ClaimsPrincipal)HttpContext.User;
            if (null != principal)
            {
                foreach (Claim claim in principal.Claims)
                {
                    if (claim.Type == "SF_ID")
                        _ID = claim.Value;
                        //_ID += "CLAIM TYPE: " + claim.Type + "; CLAIM VALUE: " + claim.Value + "</br>";
                }
                return Content(_ID);
            }
            else {
                return Content("找 不 到 用 戶 ID ~ ~ ~");
            }
            
            var ListOne = from m in _db.Customers where m.CustomerId == Convert.ToInt32(_ID) select m;

            Customer result = ListOne.FirstOrDefault();

            return Content(_ID);
            
            
        }


    }
}
