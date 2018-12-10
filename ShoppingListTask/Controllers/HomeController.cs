using ShoppingListTask.Models;
using ShoppingListTask.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShoppingListTask.Controllers
{
    public class HomeController : Controller
    {
        IShoppingListTaskRepository rep = new ShoppingListTaskRepository();

        public HomeController()
        {
            if (rep.GetUser().UserName == "Anonymous")
              TempData["LoginStatusMessage"] = "Please change the user id to access your personal shopping basket";
        }

        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.ItemCount = rep.BasketItemCount();
            return View();
        }

        [HttpPost]
        public ActionResult UpdateItem(ShoppingBasketItem sbi)
        {
            rep.UpdateItem(sbi);
            TempData["Status"] = $"Item has been added to your basket which now contain(s) {rep.BasketItemCount()} items";
            return RedirectToAction("Index");
        }

    }
}