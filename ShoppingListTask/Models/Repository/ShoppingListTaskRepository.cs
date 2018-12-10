using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingListTask.Models.Repository
{
    public class ShoppingListTaskRepository : IShoppingListTaskRepository
    {
        // The repository presented here would need to be tested with unit testing thoroughly:
        // although client and server side validation is provided by MVC,
        // one can't trust one's own code (or one's equally forgetful colleagues) so best to check
        // that all values passed via objects to the repository make sense.
        // I have not validated the data in this task for brevity's sake.

        ShoppingListTaskEntities ctx = new ShoppingListTaskEntities();

        public ApplicationUser GetUser()
        {
            return new ApplicationUser() { UserName = HttpContext.Current.Session["User"].ToString() };
        }

        public List<ShoppingBasketItem> GetItems()
        {
            // There should be try catch blocks around this sort of code because of the
            // implied accessibility of the SQL server, or we could rely on the general
            // error page but not as elegant from a UI or programmer perspective (shorter
            // though !)
            string userName = GetUser().UserName; // temporary copy of username to avoid repeatedly
                                                  // accessing the Session object
            return ctx.ShoppingBasket.Where(sbi => sbi.UserName == userName).ToList();
        }

        public void DeleteItem(ShoppingBasketItem sbi)
        {
            ctx.ShoppingBasket.Attach(sbi);
            ctx.Entry(sbi).State = System.Data.Entity.EntityState.Deleted;
            ctx.SaveChanges();
        }

        public void UpdateItem(ShoppingBasketItem sbi)
        {
            sbi.UserName = this.GetUser().UserName;
            ShoppingBasketItem existingItem = ctx.ShoppingBasket.
                            SingleOrDefault(i => i.UserName == sbi.UserName &&
                                            i.Description == sbi.Description);


            if (existingItem != null)
            {
                // Item is already in the shopping basket
                // Of course, we should provide a status indicator to the caller,
                // perhaps the item that you are deleting couldn't be found in the basket in
                // the first place.  I'll leave that one for another day.
                if (sbi.Quantity == 0)
                {
                    /* Oh well, user has decided not to take their imaginary item.
                     * terrible shame, it was going to be free after all */
                    this.DeleteItem(sbi);
                }
                else
                {
                    /* Add the new quantity to the quantity already in the basket */
                    existingItem.Quantity += sbi.Quantity;
                }
            }

            else
            {
                // A new order has been placed into the basket
                ctx.ShoppingBasket.Add(sbi);
            }

            ctx.SaveChanges();
        }

        public int BasketItemCount()
        {
            string userName = this.GetUser().UserName;
            int count = ctx.ShoppingBasket.Count(i => i.UserName == userName);
            if (count == 0)
                return 0;
            return ctx.ShoppingBasket.Sum(i => i.UserName == userName ? i.Quantity : 0);
        }

        bool Disposed = false;

        public void Dispose()
        {
            // Chain our repository's dispose method to that of the Entity Framework, this will help
            // the garbage collector remove physically unused objects ('ghosts') as quickly
            // as possible, reducing the number of garbage collection cycles that might
            // otherwise be required.  Still, you don't want to dispose the disposed
            // (the user might have politely called dispose manually and the GC might try to
            //  then do so a second or more time at a later stage, causing attempt to access
            //  null reference variables), hence
            // the simple boolean protection logic.
            if (!Disposed)
            {
                ctx.Dispose();
                ctx = null;
                this.Disposed = true;
            }
        }
    }
}