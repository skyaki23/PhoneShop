using PhoneShop.Models;
using System.Collections.Generic;

namespace PhoneShop.ViewModels
{
    public class HomeViewModel
    {
        /// <summary>
        /// 產品品牌List
        /// </summary>
        public List<Category> Categories { get; set; }
        /// <summary>
        /// 產品List
        /// </summary>
        public List<Product> Products { get; set; }
        /// <summary>
        /// 搜尋關鍵字
        /// </summary>
        public string SearchTerm { get; set; }
        /// <summary>
        /// 產品最高價格
        /// </summary>
        public int MaximumPrice { get; set; }
        /// <summary>
        /// 產品品牌ID
        /// </summary>
        public int? CategoryID { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        public int? SortBy { get; set; }
        /// <summary>
        /// 產品分頁功能
        /// </summary>
        public Pager Pager { get; set; }
        /// <summary>
        /// 產品輪播圖List
        /// </summary>
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