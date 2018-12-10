namespace ShoppingListTask
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using global::ShoppingListTask.Models;
    

    public class ShoppingListTask : DbContext
    {
   
        public ShoppingListTask()
            : base("name=ShoppingList")
        {
        }

        // This is a giant shopping trolley rather than a basket. It contains the items ordered
        // by all users.  Queries are used to retrieve the rows that relevant to the user.
        // This would ideally be done via the consistency offered by the repository pattern
        // but I suspect that implementing it here would be a bit too much.
        public virtual DbSet<ShoppingBasketItem> ShoppingBasket { get; set; }
    }

    
}