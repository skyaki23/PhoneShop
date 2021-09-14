using PhoneShop.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PhoneShop.ViewModels
{
    public class ProductSearchViewModel
    {
        /// <summary>
        /// 產品List
        /// </summary>
        public List<Product> Products { get; set; }
        /// <summary>
        /// 搜尋關鍵字
        /// </summary>
        public string SearchTerm { get; set; }
        /// <summary>
        /// 產品分頁功能
        /// </summary>
        public Pager Pager { get; set; }
    }

    public class NewProductViewModel
    {
        /// <summary>
        /// 產品名稱
        /// </summary>
        [Required]
        [MinLength(1), MaxLength(50)]
        public string Name { get; set; }
        /// <summary>
        /// 產品價格
        /// </summary>
        public int Price { get; set; }
        /// <summary>
        /// 產品品牌ID
        /// </summary>
        public int CategoryID { get; set; }
        /// <summary>
        /// 產品圖片路徑
        /// </summary>
        public string ImageURL { get; set; }
        /// <summary>
        /// 產品品牌List
        /// </summary>
        public List<Category> Categories { get; set; }
    }

    public class EditProductViewModel
    {
        /// <summary>
        /// 產品ID
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// 產品名稱
        /// </summary>
        [Required]
        [MinLength(1), MaxLength(50)]
        public string Name { get; set; }
        /// <summary>
        /// 產品價格
        /// </summary>
        public int Price { get; set; }
        /// <summary>
        /// 產品品牌ID
        /// </summary>
        public int CategoryID { get; set; }
        /// <summary>
        /// 產品圖片路徑
        /// </summary>
        public string ImageURL { get; set; }
        /// <summary>
        /// 產品品牌List
        /// </summary>
        public List<Category> Categories { get; set; }
    }
}