using ShoppingListTask.Models;
using ShoppingListTask.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShoppingListTask.Controllers
{
    public class ShoppingBasketController : Controller
    {
        ShoppingListTaskRepository rep = new ShoppingListTaskRepository();

        // GET: ShoppingBasket
        [HttpGet]
        public ActionResult Index()
        {           
            return View(rep.GetItems());
        }

       [HttpGet]
       public ActionResult PayForItems()
        {
            return View();
        }

      
    }
}