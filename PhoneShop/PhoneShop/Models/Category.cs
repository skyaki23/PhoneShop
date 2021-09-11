using System.Collections.Generic;

namespace PhoneShop.Models
{
    public class Category : BaseEntity
    {
        /// <summary>
        /// 品牌圖片路徑
        /// </summary>
        public string ImageURL { get; set; }
        /// <summary>
        /// 品牌產品資訊List
        /// </summary>
        public List<Product> Products { get; set; }
    }
}