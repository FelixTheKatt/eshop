using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MaXimusPOP.Models;
using MaXimusPOP.Models.View;

namespace MaXimusPOP.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //Capsule db = new Capsule();
            //db.Categories.ToList();
            using (Capsule db = new Capsule())
            {
                HomeIndex model = new HomeIndex();
                model.BestSellingProducts = db.Products
                    .OrderBy(p => p.ProductId)
                    .Take(1)
                    .ToList();
                return View(model);
            }            
        }
    }
}