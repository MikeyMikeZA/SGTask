using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShoppingListTask.Models
{
    public class ApplicationUser
    {
        [Required(ErrorMessage = "You cannot use a blank ID.")]
        [MinLength(5, ErrorMessage = "The User ID must be at least 5 characters long")]
        [MaxLength(20, ErrorMessage = "The User ID must be 20 characters or fewer in length")]
        public string UserName { get; set; }
    }
}