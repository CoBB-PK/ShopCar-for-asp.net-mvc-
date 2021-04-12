using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShopCar_pok.Models;
using Microsoft.AspNetCore;
using System.IO;

namespace ShopCar_pok.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WebAPIController : ControllerBase
    {
        private readonly AdventureWorksLT2016Context _db;

        public WebAPIController(AdventureWorksLT2016Context context) {
            _db = context;
        }

        [HttpGet]
        public FileContentResult GetImage(int id) {
            Product RequestPhoto = _db.Products.FirstOrDefault(p => p.ProductId == id);
            if (RequestPhoto != null)
            {
                return File(RequestPhoto.ThumbNailPhoto, "image/jpeg");
            }
            else {
                return null;
            }
        }
    }
}
