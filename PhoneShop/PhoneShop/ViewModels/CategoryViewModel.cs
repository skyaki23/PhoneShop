using PhoneShop.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PhoneShop.ViewModels
{
    public class CategorySearchViewModel
    {
        /// <summary>
        /// 品牌List
        /// </summary>
        public List<Category> Categories { get; set; }
        /// <summary>
        /// 搜尋關鍵字
        /// </summary>
        public string SearchTerm { get; set; }
    }

    public class NewCategoryViewModel
    {
        /// <summary>
        /// 品牌名稱
        /// </summary>
        [Required]
        [MinLength(1), MaxLength(50)]
        public string Name { get; set; }
        /// <summary>
        /// 品牌圖片路徑
        /// </summary>
        public string ImageURL { get; set; }
    }

    public class EditCategoryViewModel
    {
        /// <summary>
        /// 品牌ID
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// 品牌名稱
        /// </summary>
        [Required]
        [MinLength(1), MaxLength(50)]
        public string Name { get; set; }
        /// <summary>
        /// 品牌圖片路徑
        /// </summary>
        public string ImageURL { get; set; }
    }
}