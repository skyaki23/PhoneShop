using PhoneShop.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PhoneShop.ViewModels
{
    public class CategorySearchViewModel
    {
        public List<Category> Categories { get; set; }
        public string SearchTerm { get; set; }
    }

    public class NewCategoryViewModel
    {
        [Required]
        [MinLength(1), MaxLength(50)]
        public string Name { get; set; }    
        public string ImageURL { get; set; }
    }

    public class EditCategoryViewModel
    {
        public int ID { get; set; }
        [Required]
        [MinLength(1), MaxLength(50)]
        public string Name { get; set; }
        public string ImageURL { get; set; }
    }
}