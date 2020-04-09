using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PhoneShop.Models
{
    public class Product : BaseEntity
    {
        [Range(1, 100000)]
        public int Price { get; set; }
        public int CategoryID { get; set; }
        public virtual Category Category { get; set; } // virtual   lazy load
        public string ImageURL { get; set; }
    }
}