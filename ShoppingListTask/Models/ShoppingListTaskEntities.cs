namespace ShoppingListTask.Models
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class ShoppingListTaskEntities : DbContext
    {
        // Your context has been configured to use a 'ShoppingListTak' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'ShoppingListTask.Models.ShoppingListTak' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'ShoppingListTak' 
        // connection string in the application configuration file.
        public ShoppingListTaskEntities()
            : base("name=ShoppingListTask")
        {
        }

        //  This is a giant shopping trolley that hold all the baskets for all the users.
        //  Ideally, we would use the repository pattern to implement a function to return
        //   only the items that belong to the currently visible user. 

        public virtual DbSet<ShoppingBasketItem> ShoppingBasket {get; set; }
    }


}