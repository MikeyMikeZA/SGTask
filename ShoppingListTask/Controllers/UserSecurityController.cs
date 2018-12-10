using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShoppingListTask.Models;

namespace ShoppingListTask.Controllers
{
    public class UserSecurityController : Controller
    {


        // GET: UserSecurity
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        // This would be best implemented with an application wide repository.
        // As it stands, it could be at risk of attempted access via the http protocol
        [ChildActionOnly]
        [HttpGet]
        public ApplicationUser GetUser()
        {
            ApplicationUser au = new ApplicationUser() { UserName = Session["User"].ToString() };
            return au;
        }

       
        [ChildActionOnly]
        public ActionResult _UserStatusManager()
        {
            return PartialView(GetUser());
        }

        [HttpPost]
        public ActionResult ProcessLogin(ApplicationUser user, FormCollection fc)
        // If the user clicks Log In, simply store their random name
        // into a session variable and later, ultimately, into each 
        // of their entries in the grand shopping basket
        // Ideally there would be a timer triggered (and reset) by rendering the 
        // layout page (the template for all pages).  Better yet, stick such code in 
        // _ViewStart (the first template page used by Razor regardless of any other layout
        //  page requests our code might make) that would display a dialogue box warning the 
        // user they are about to be logged out and lose their session variable (not that 
        // they would be interested in that detail).  Luckily for us, we chose to store their
        // shopping basket in a database and not in a session variable, so they can 
        // log back in and see their precious order again, even at a different workstation.
        {
            if (ModelState.IsValid)
            {
                Session["User"] = user.UserName;
                TempData["LoginStatusMessage"] = "Thanks for logging in!";
                return RedirectToAction("Index", "Home");
            }

            // This is an easy cop-out given that errors produced by a partial view
            // are clumsy to pass back to the host page
            TempData["LoginStatusMessage"] = "Your user id must be between 5 and 20 characters long";
            return RedirectToAction("Index", "Home");
        }
    }
}