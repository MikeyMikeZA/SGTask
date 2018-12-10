using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShoppingListTask.Models
{
    public class ShoppingBasketItem
    {
        [Key]
        public int ID { get; set; }
     
        public string UserName { get; set; }

        [Required(ErrorMessage = "Please supply a description")]
        [MaxLength(50, ErrorMessage = "Describe your product using 50 characters or fewer")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Please fill in how many of these products you need")]
        [Range(0, 20, ErrorMessage = "We can only supply 20 items per order")]
        public int Quantity { get; set; }
    }
}