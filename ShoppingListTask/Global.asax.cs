using ShoppingListTask.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace ShoppingListTask
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            // Arrange for the Entity Framework drop the database if you play with 
            // the definitions of the Model assigned to it.  If you don't have the source
            // code, you are stuck with the DB forever, unless you delete it of course
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<ShoppingListTaskEntities>());
        }

        protected void Session_Start()
        {
            Session["User"] = "Anonymous";            
        }
    }
}
