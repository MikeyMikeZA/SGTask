using System;
using System.Collections.Generic;

namespace ShoppingListTask.Models.Repository
{
    public interface IShoppingListTaskRepository : IDisposable
    // This is our interface to encourage Dependency Injection and allow
    // us to swap the repository and consequently the data source used by our
    // applications controllers.  Very Useful for user acceptance testing as well
    // as we can easily arrange for the web.config to contain a switch that lets
    // us inject a false data source derived from a completely coded object, 
    // so a user can test the interface, but the live
    // database is safe ("live" possibly being a much loved and especially configured
    // test DB not necessarily production level "live", but still, we don't a
    // random user testing for aesthetics and odd bits of functionality with off the cuff data
    // and trashing it!)
    //
    // Very important though is this interface make's sure any future repositories we write
    // have exactly the same functions in them.  Plus if we remove/add functions etc. 
    // to a repository, we have to update the interface (no choice, that is what an interface 
    // does), breaking any other derived repositories until they too offer the updated list of
    // functions/properties/events/delegates etc.
    // 
    // Marvellous opportunity to encourage using IntelliSense integrating XML comments as I did
    // below, I don't have the motivation to do that throughout this demo.
    {
        /// <summary>
        /// Delete and item from the shopping basket entity set.
        /// It requires a complete existing item for it to work.
        /// </summary>
        /// <param name="sbi">An existing item in the shopping basket.  All properties
        /// must be filled in to match the item in the DB.</param>
        void DeleteItem(ShoppingBasketItem sbi);
        List<ShoppingBasketItem> GetItems();
        ApplicationUser GetUser();
        void UpdateItem(ShoppingBasketItem sbi);
        int BasketItemCount();
    }
}