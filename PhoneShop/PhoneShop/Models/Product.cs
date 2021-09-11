using System.ComponentModel.DataAnnotations;

namespace PhoneShop.Models
{
    public class Product : BaseEntity
    {
        /// <summary>
        /// 產品價格
        /// </summary>
        [Range(1, 100000)]
        public int Price { get; set; }
        /// <summary>
        /// 產品品牌ID
        /// </summary>
        public int CategoryID { get; set; }
        /// <summary>
        /// 產品品牌資訊
        /// </summary>
        public virtual Category Category { get; set; } // virtual   lazy load
        /// <summary>
        /// 產品圖片路徑
        /// </summary>
        public string ImageURL { get; set; }
    }
}