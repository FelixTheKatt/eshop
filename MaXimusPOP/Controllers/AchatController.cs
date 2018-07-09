using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MaXimusPOP.Models;
using MaXimusPOP.Models.View;

namespace MaXimusPOP.Controllers
{
    public class AchatController : Controller
    {
        // GET: Achat
        public ActionResult Achat(string name, int page = 0 , int limit = 8)
        {

            using (Capsule db = new Capsule())
            {
                Page<Product> model = new Page<Product>();

                model.PageNumber = page;

                model.Limit = limit;

                IEnumerable<Product> temp = db.Products;

                if (! string.IsNullOrWhiteSpace(name))
                {
                    temp = temp.Where(x => x.Name.ToLower().Contains(name.ToLower()));
                }

                model.Items = temp
                    .OrderBy(p => p.Name)
                    .Skip(page * limit)
                    .Take(limit)
                    .ToList();

                model.Total = db.Products.Count();

                return View(model);
            }
        }
    }
}