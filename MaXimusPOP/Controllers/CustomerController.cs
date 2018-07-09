using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MaXimusPOP.Models;
using MaXimusPOP.Models.forms;
using MaXimusPOP.Models.View;
using MaXimusPOP.Tools;

namespace MaXimusPOP.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        [HttpGet]
        public ActionResult Login()
        {
            return View(new CustomerLogin());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(CustomerLogin model)
        {
            if (ModelState.IsValid)
            {
                CustomerSession user = model.CheckUser(model);

                if (user != null)
                {
                    SessionManager.Instance.LoggedUser = user;
                    return RedirectToAction("Index", "Home");
                }
            }
            return View(new CustomerLogin() { Mail = model.Mail });
        }
        [HttpGet]
        public ActionResult Register()
        {
            if (SessionManager.Instance.IsAuthenticated)
                return RedirectToAction(nameof(ErrorConnected));

            return View(new CustomerRegister());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(CustomerRegister model)
        {
            if (ModelState.IsValid)
            {
                CustomerSession user = model.RegisterInDB();

                if (user != null)
                {
                    SessionManager.Instance.LoggedUser = user;
                    return RedirectToAction("Index", "Home");
                }
            }

            return View(new CustomerRegister());
        }

        [AuthorizationManager]
        public ActionResult ErrorConnected()
        {
            return View();
        }

        public ActionResult Logout()
        {
            SessionManager.Instance.LoggedUser = null;
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Cart()
        {
            Dictionary<Product, int> group = SessionManager.Instance.LoggedUser.CurrentProduct
                .GroupBy(p => p)
                .ToDictionary(g => g.Key, g => g.Count());

            Panier panier = new Panier();
            panier.Contenu = group;

            return View(panier);
        }


        public ActionResult AddToCart(int? productid)
        {

            using (Capsule db = new Capsule())
            {
                Product product = db.Products.Where(x => x.ProductId == productid).FirstOrDefault();

                if (product != null)
                {
                    SessionManager.Instance.LoggedUser.CurrentProduct.Add(product);
                }
            }

            return RedirectToAction("Achat", "Achat","Achat");
        }
    }
}