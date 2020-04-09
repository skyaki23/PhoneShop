using PhoneShop.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PhoneShop.ViewModels
{
    public class ProductSearchViewModel
    {
        public List<Product> Products { get; set; }
        public string SearchTerm { get; set; }
    }

    public class NewProductViewModel
    {
        [Required]
        [MinLength(1), MaxLength(50)]
        public string Name { get; set; }
        public int Price { get; set; }
        public int CategoryID { get; set; }
        public string ImageURL { get; set; }
        public List<Category> Categories { get; set; }
    }

    public class EditProductViewModel
    {
        public int ID { get; set; }
        [Required]
        [MinLength(1), MaxLength(50)]
        public string Name { get; set; }
        public int Price { get; set; }
        public int CategoryID { get; set; }
        public string ImageURL { get; set; }
        public List<Category> Categories { get; set; }
    }
}