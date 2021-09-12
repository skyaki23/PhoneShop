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
        public int ID { get; set; }
        [Required]
        [MinLength(1), MaxLength(50)]
        public string Name { get; set; }
        public string ImageURL { get; set; }
    }
}