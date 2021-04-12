using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShopCar_pok.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace ShopCar_pok.Controllers
{
    public class ProductController : Controller
    {
        private readonly AdventureWorksLT2016Context _db;

        public ProductController(AdventureWorksLT2016Context context)
        {
            _db = context;
        }

        public IActionResult List(String sortOrder) {
            ViewBag.PriductCategoryID = String.IsNullOrEmpty(sortOrder) ? "ID" : "ID-D";
            ViewBag.Name = String.IsNullOrEmpty(sortOrder) ? "Name" : "Name-D";
            IQueryable<ProductCategory> ListAll = from m in _db.ProductCategories select m;
            if (ListAll == null)
            {
                return Content(" 沒 有 資 料 ");
            }
            else {
                switch (sortOrder)
                {
                    case "ID":
                        ListAll = ListAll.OrderByDescending(s => s.ProductCategoryId);
                        break;
                    case "ID-D":
                        ListAll = ListAll.OrderBy(s => s.ProductCategoryId);
                        break;
                    case "Name-D":
                        ListAll = ListAll.OrderBy(s => s.Name);
                        break;
                }
                return View(ListAll.ToList());
            }
        }

        public IActionResult Product(int? id ,string searchString) {
            if (id == null) {
                return Content(" 抱 歉 ~  目 前 找 不 到 資 料 ! ! !");
            }

            IQueryable<Product> Pd = from m in _db.Products where m.ProductCategoryId == id  select m;
            if (Pd == null)
            {
                return Content(" 沒 有 資 料 ");
            }
            else {
                if (!String.IsNullOrEmpty(searchString))
                {
                    Pd = Pd.Where(s => s.Name.Contains(searchString));
                }
                return View(Pd.ToList());
            }
        }

        
        public IActionResult Details(int? id) {
            if (id == null) {
                return Content("No Details");
            }

            var ProductDetail = from m in _db.Products where m.ProductId == id select m;
            if (ProductDetail == null)
            {
                return Content("No Data ! ! !");
            }
            else {
                return View(ProductDetail.FirstOrDefault());
            }
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
