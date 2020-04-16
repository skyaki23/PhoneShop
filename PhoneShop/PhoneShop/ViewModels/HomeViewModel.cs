using PhoneShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhoneShop.ViewModels
{
    public class HomeViewModel
    {
        public int MaximumPrice { get; set; }
        public List<Category> Categories { get; set; }
        public List<Product> Products { get; set; }
        public int? SortBy { get; set; }
        public int? CategoryID { get; set; }
        public Pager Pager { get; set; }
        public string SearchTerm { get; set; }
        public List<Product> CarouselProducts { get; set; }
    }

    public class FilterProductsViewModel
    {
        public List<Product> Products { get; set; }
        public Pager Pager { get; set; }
        public int? SortBy { get; set; }
        public int? CategoryID { get; set; }
        public string SearchTerm { get; set; }
    }

    public class ShoppingCartViewModel
    {
        public List<int> CartProductIDs { get; set; }
        public List<Product> CartProducts { get; set; }
        public Member User { get; set; }
    }
}